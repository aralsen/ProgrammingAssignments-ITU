#include <iostream>
#include "Library.h"

using namespace std;

void Library::addSong(const Song& song) {
    songList.insert(song);
    cout << "success: Added song: " << song << endl;
}

void Library::removeSongFromLibraryProc(string &songTitle) {
    Song* temp = songList.find(Song(songTitle));
    if (temp) {
        songList.remove(*temp);
        return;
    }
    cout << "  error: Could not remove song " << songTitle << " from the library." << endl;
}

void Library::showSongDetails(const string &songTitle) {
    cout << "Song " <<  songTitle << " not found in library\n"
            "   error: Could not find song title " << songTitle << " in library\n";
}

void Library::print() {
    songList.printInorder(cout);
}

bool Library::findSong(string &findSong) {
    Song* temp = songList.find(Song(findSong));

    if (temp) {
        return true;
    }
    return false;
}
