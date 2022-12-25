#include <iostream>
#include <dirent.h>
#include <vector>
#include <sstream>
#include "SpotifyLikeApp.h"
#include "LineTokenizer.h"

using namespace std;
System SpotifyLikeApp::system;

std::vector<std::string> getSongInfoFilenames(const std::string& inputdir_name) {
    if (inputdir_name.empty()) return std::vector<std::string>();
    DIR* dir;
    struct dirent* dir_entry;
    std::vector<std::string> filenames;
    if ((dir = opendir(inputdir_name.c_str())) != nullptr) {
        while ((dir_entry = readdir(dir)) != nullptr) {
            if (std::string(dir_entry->d_name).find(".song-info.txt") != std::string::npos) {
                filenames.emplace_back(dir_entry->d_name);
            }
        }
        closedir(dir);
    }
    return filenames;
}

void loadSongInfoLineByLineToVector(LineTokenizer& lt, vector<string>* song_infos) {
    std::vector<std::string> vector_line;
    while (!(vector_line = lt.nextLine()).empty()) {
        for (const std::string& s : vector_line) {
            song_infos->push_back(s);
        }
    }
}

void SpotifyLikeApp::insertSongToLibraryProc(vector<string> *songInfo) {
    string title = songInfo->at(0);
    string artist = songInfo->at(1);

    string duration = songInfo->at(2);
    int duration_min, duration_sec;

    string isExplicit = songInfo->at(3);
    bool isExplicitBool = false;

    string timeAdded = songInfo->at(4);
    unsigned int hour, minute, second;

    string dateAdded;

    if (songInfo->size() > 5) {
        dateAdded = songInfo->at(5);
    }

    unsigned int month, day, year;

    Timestamp newTimestamp;

    title = title.erase(title.find_last_not_of(" \n\r\t")+1);

    artist = artist.erase(artist.find_last_not_of(" \n\r\t")+1);

    duration = duration.erase(duration.find_last_not_of(" \n\r\t")+1);
    try{
        if (duration.substr(2,1) != ":" | (duration.length() > 5)
            | (stoi(duration.substr(0,2))>59) | (stoi(duration.substr(3,2))>59))
        {
            cout<<"Illegal time duration format: "<<duration<<endl;
            duration = "00:00";
        }
    }
    catch(exception e){
        cout<<"Illegal time duration format: "<<duration<<endl;
        duration = "00:00";
    }

    duration_min = stoi(duration.substr(0,2));
    duration_sec = stoi(duration.substr(3,2));

    if (isExplicit == "y") {
        isExplicitBool = true;
    }

    timeAdded = timeAdded.erase(timeAdded.find_last_not_of(" \n\r\t")+1);
    try {
        if (timeAdded.substr(2,1) != ":"
            | timeAdded.substr(5,1) != ":"
            |(timeAdded.length() > 8)
            |stoi(timeAdded.substr(0, 2)) > 24
            |stoi(timeAdded.substr(3, 2)) > 59
            |stoi(timeAdded.substr(6, 2)) > 59)
        {
            cout << "Illegal time value: " << timeAdded << " - using current time" << endl;
            timeAdded = Timestamp().toString().substr(11, 8);
        }
    }
    catch(exception e){
        cout << "Illegal time value: " << timeAdded << " - using current time" << endl;
        timeAdded = Timestamp().toString().substr(11, 8);
    }

    hour = stoi(timeAdded.substr(0,2));
    minute = stoi(timeAdded.substr(3,2));
    second = stoi(timeAdded.substr(6,2));

    newTimestamp.setHours(hour);
    newTimestamp.setMins(minute);
    newTimestamp.setSecs(second);

    dateAdded = dateAdded.erase(dateAdded.find_last_not_of(" \n\r\t")+1);
    try {
        if (dateAdded.substr(2,1) != "/"
            | dateAdded.substr(5,1) != "/"
            |(dateAdded.length() > 11)
            |stoi(dateAdded.substr(0, 2)) > 13 | stoi(dateAdded.substr(3, 2)) > 31
            |stoi(dateAdded.substr(6, 4)) < 1970 | stoi(dateAdded.substr(6, 4)) > 2025)
        {
            cout << "Bad Date value: " << dateAdded << " - using today's date." << endl;
            dateAdded = Timestamp().toString().substr(0, 10);
        }
    }
    catch(exception e){
        cout << "Bad Date value: " << dateAdded << " - using today's date." << endl;
        dateAdded = Timestamp().toString().substr(0, 10);
    }

    month = stoi(dateAdded.substr(0,2));
    day = stoi(dateAdded.substr(3,2));
    year = stoi(dateAdded.substr(6,4));

    newTimestamp.setMonth(month);
    newTimestamp.setDay(day);
    newTimestamp.setYear(year);

    system.getSystemLibrary().addSong(Song(title, artist, Duration(duration_min, duration_sec), isExplicitBool, newTimestamp));
}

void SpotifyLikeApp::listAllSongsFromSystem() {
    system.getSystemLibrary().print();
}

void SpotifyLikeApp::listAllUsersFromSystem() {
    system.printSystemUsers();
}

void SpotifyLikeApp::exitProc() {
    exit(0);
}

void SpotifyLikeApp::doWorkForOption(const string &option, vector<string> args, const string& workingdir) {
    if (args.size() > 1) {
        string info;
        for (int i = 1; i < args.size(); ++i) {
            info.append(args.at(i) + " ");
        }
        info = info.erase(info.find_last_not_of(" \n\r\t")+1);
        args.at(1) = info;
    }
    /*///////////////////////////////////////  ADD PROCESS  //////////////////////////////////////////////////////*/
    if (option == "add") {
        if (args.empty())
        {
            cout << " error: Improper use of add. Use one of:\n"
                    " error:    add fsong <song title>\n"
                    " error:    add user <username>\n";
        }
        else if (args.at(0) == "fsong")
        {
            if (args.size() <= 1) {
                cout << " error: Must specify a song title - nothing added\n";
            }
            else {
                std::vector<std::string> song_info_files = getSongInfoFilenames(workingdir);

                //INFO PROCESS
                for (const std::string& s : song_info_files) {
                    auto* songInfos = new vector<string>();
                    LineTokenizer newLineTokenizer(workingdir, s);
                    loadSongInfoLineByLineToVector(newLineTokenizer, songInfos);
                    if (songInfos->at(0) == args.at(1)) {
                        insertSongToLibraryProc(songInfos);
                        break;
                    }
                }
            }
        }
        else if (args.at(0) == "user") {
            if (args.size() <= 1) {
                cout << " error: Must specify a user name - nothing added\n";
            }
            else {
                string userName = args.at(1);
                system.addUser(User(userName));
            }
        }
    }
    /*///////////////////////////////////////  FRIEND PROCESS  //////////////////////////////////////////////////////*/
    else if (option =="friend") {
        if (args.empty() || args.size() <= 1)
        {
            cout << " error: Improper use of friend. Use:\n"
                    " error:    friend <user1> <user2>\n";
        }
        else if (!args.at(0).empty() && !args.at(1).empty())
        {
            system.buildFriendship(args.at(0), args.at(1));
        }
    }
    /*//////////////////////////////////////  REMOVE PROCESS  //////////////////////////////////////////////////////*/
    else if (option =="remove") {
        if (args.empty())
        {
            cout << " error: Improper use of remove. Use:\n"
                    " error:    remove song <title>\n"
                    " error:    remove <user1> <user2>\n";
        }
        else if (args.at(0) == "song")
        {
            if (args.size() <= 1) {
                cout << " error: Must specify a song title - nothing removed\n";
            }
            else {
                system.removeSongFromPuLib(args.at(1)); //remove song from primary user library
            }
        }
        else if (!args.at(0).empty() && !args.at(1).empty())
        {
            system.removeFriendship(args.at(0), args.at(1));
            cout << endl;
        }
    }
    /*///////////////////////////////////////  SHOW PROCESS  //////////////////////////////////////////////////////*/
    else if (option =="show") {
        if (args.empty()) {
            cout << " error: Improper use of show. Use:\n"
                    " error:    show pusongs\n"
                    " error:    show songs\n"
                    " error:    show users\n"
                    " error:    show reclist\n"
                    " error:    show friends <username>\n";
        }
        else if (args.at(0) == "pusongs") { //show primary users' library
            system.getPrimaryUser().getPrimaryUserLibrary().print();
        }
        else if (args.at(0) =="songs")
        {
            listAllSongsFromSystem();
        }
        else if (args.at(0) =="users")
        {
            listAllUsersFromSystem();
        }
        else if (args.at(0) =="reclist")
        {
            system.showRecList();
        }
        else if (args.at(0) =="friends")
        {
            if (args.size() <= 1) {
                cout << " error: No user specified - nothing shown.\n";
            }
            else {
                system.showUserFriends(args.at(1));
            }
        }
    }
    /*///////////////////////////////////////  LISTEN PROCESS  //////////////////////////////////////////////////////*/
    else if (option =="listen") {
        if (args.empty()) {
            cout << " error: Improper use of listen. Use:\n"
                    " error:    listen <user name> <song title>\n";
        }
        else if(!args.at(0).empty())
        {
            if (args.size() <= 1) {
                cout << " error: No song specified - nothing listening.\n";
            }
            else {
                 if (system.findSystemUser(args.at(0))) { //user in the system?
                     int listenCount;
                     cout << " listen count -> ";
                     cin >> listenCount;
                     cin.ignore();

                     if (system.isUserEFN(args.at(0),2)) { // in EFN? //EFN set default = 2...
                         if (system.findSystemSong(args.at(1))) { //  song in system library ?
                             if (system.getPrimaryUser().getPrimaryUserLibrary().findSong(args.at(1))) {
                                 cout << "this song is already in primary user lib" << endl;
                             }
                             else {
                                 if (args.at(0) == system.getPrimaryUser().getUserName()) {
                                     system.addSongToPUlib(args.at(1));
                                 }
                                 else {
                                     if (system.findInRecoList(args.at(1))) {
                                         system.increaseKey(args.at(1), listenCount);
                                     }
                                     else {
                                         system.addSongToRecList(args.at(1), listenCount);
                                     }
                                 }
                             }
                         }
                         else {
                             cout << args.at(1) << " this song is not exists in system library " << endl;
                         }
                     }
                     else {
                         cout << args.at(0) << " is not in PU's EFN " << endl;
                     }
                 }
                 else {
                     cout << "This user does not exist." << endl;
                 }
            }
        }
    }
    /*///////////////////////////////////////  RECO PROCESS  //////////////////////////////////////////////////////*/
    else if (option =="recommend") {
        if (args.empty()) {
            cout << " error: Improper use of recommend. Use:\n"
                    " error:    recommend <int value>\n";
        }
        else if (!args.at(0).empty() && args.size() <= 1) {
            system.showTopSongs(stoi(args.at(0)));
        }
        else if (args.size() > 1) {
            cout << "Invalid command " << endl;
        }
    }
    /*///////////////////////////////////////  EXIT PROCESS  //////////////////////////////////////////////////////*/
    else if (option =="exit") {
        exitProc();
    }
    /*///////////////////////////////////////  COMMAND ERROR PROCESS  ///////////////////////////////////////////////*/
    else {
        cout << " Command not recognized, please try again\n";
    }
}

[[noreturn]] void SpotifyLikeApp::run(const string& inputdir, const string& outputdir) {
    cout << "CA5 working..." << endl;
    cout << "AT START, Songs adding to Library from Input Directory -> " << inputdir << "\n" << endl;

    std::vector<std::string> song_info_files = getSongInfoFilenames(inputdir);

    //INFO PROCESS
    for (const std::string& s : song_info_files) {
        auto* songInfos = new vector<string>();
        LineTokenizer newLineTokenizer(inputdir, s);
        loadSongInfoLineByLineToVector(newLineTokenizer, songInfos);

        insertSongToLibraryProc(songInfos);
    }

    cout << "\nAT START, SONGS ADDED TO Library FROM INPUT DIRECTORY -> " << inputdir << endl;

    /*//////////////////////////// PRİMARY USER PROCESS ////////////////////////////////////*/
    string primary_user_name;
    cout << "What is your primary user name " << endl;
    cin >> primary_user_name;
    cout << "Primary user name is -> " << primary_user_name << endl;
    system.addPrimaryUser(PrimaryUser(primary_user_name));
    cin.ignore();
    /*//////////////////////////// PRİMARY USER PROCESS ////////////////////////////////////*/

    for (;;) {
        string line;

        cout << endl << R"(["add" "friend" "remove" "recommend" "show" "listen" "exit"] )" << endl;
        cout << " Command: ";
        getline(cin, line);

        Parser command(line);

        string op;
        vector<string> args;

        op = command.getOperation();
        args = command.getArgs();

        doWorkForOption(op, args, outputdir);
    }
}
