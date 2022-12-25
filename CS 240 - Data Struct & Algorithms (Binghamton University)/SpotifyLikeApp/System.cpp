#include <iostream>
#include "System.h"

void System::addUser(const User& user) {
    if (users.find(user)) {
        cout << " duplicate user, cannot add to the system " << endl;
        return;
    }

    users.insert(user);
    cout << "Success added new user to the system named -> " << user << endl;
}

void System::addPrimaryUser(const PrimaryUser& pu) {
    primaryUser = pu;
    users.insert(pu);
}

void System::addSongToPUlib(string &songName) {
    Song* temp1 = systemLib.getSongList().find(Song(songName));

    if (temp1) {
        primaryUser.getPrimaryUserLibrary().addSong(*temp1); //added to PU's library
        systemLib.getSongList().remove(*temp1); //removed from system library
    }
    else {
        cout << "cannot find this song in the system library " << endl;
    }
}

void System::addSongToRecList(string &songName, int count) {
    recList.insert(SongEntry(songName, count));

    SongEntry* songEntry = recList.find(SongEntry(songName));
    maxHeap.push_back(songEntry);

    int index = maxHeap.size() - 1;
    while ((index - 1) / 2 >= 0 && maxHeap.at((index - 1) / 2)->getCount() < maxHeap.at(index)->getCount()) {
        SongEntry* temp = maxHeap[(index - 1) / 2];
        maxHeap[(index - 1) / 2] = maxHeap[index];
        maxHeap[index] = temp;
        index = (index - 1) / 2;
    }
}

void System::buildFriendship(string &user1, string &user2) {
    User* temp1 = users.find(User(user1));
    User* temp2 = users.find(User(user2));

    if (temp1 && temp2)
    {
        temp1->addFriend(temp2);
        return;
    }
    else {
        cout <<" cannot add " << endl;
    }
}

bool System::findSystemUser(string &findUser) {
    if (users.find(User(findUser))) {
        return true;
    }

    return false;
}

bool System::findInRecoList(string &findSongEntry) {
    if (recList.find(SongEntry(findSongEntry))) {
        return true;
    }

    return false;
}

bool System::findSystemSong(string &findSongTitle) {
    if (systemLib.findSong(findSongTitle)) {
        return true;
    }

    return false;
}

void System::showUserFriends(string &user1) {
    User* temp1 = users.find(User(user1));
    if (temp1) {
        temp1->showFriends();
        return;
    }
    else {
        cout << "User doesn't exists!" << endl;
    }
}

void System::printSystemUsers() {
    users.printInorder(cout);
}

void System::removeFriendship(string &user1, string &user2) {
    User* temp1 = users.find(User(user1));
    User* temp2 = users.find(User(user2));

    if (temp1 && temp2)
    {
        temp1->removeFriend(temp2);
        temp2->removeFriend(temp1);
        return;
    }
    else {
        cout <<" cannot remove ";
    }
}

vector<User*> System::BFS(int R) {
    vector<string> visited;
    vector<User*> queue;
    vector<int> distance;

    string primaryUserName = primaryUser.getUserName();
    distance.push_back(0);
    visited.push_back(primaryUser.getUserName());
    queue.push_back(users.find(User(primaryUser.getUserName())));

    int front = 0;

    while (front != queue.size()) {
        if (distance[front] == R) break;
        User* currVertex = queue[front++];
        //cout << "Visited " << currVertex->getUserName() << " ";

        for (int i = 0; i < currVertex->getFriendList().size(); ++i) {
            User* adjVertex = currVertex->getFriendList().at(i);
            bool isVisited = false;

            for (const string& user: visited) {
                if (adjVertex->getUserName() == user) {
                    isVisited = true;
                    break;
                }
            }

            if (!isVisited) {
                visited.push_back(adjVertex->getUserName());
                queue.push_back(adjVertex);
                distance.push_back(distance[front-1] + 1);
            }

        }
    }

    return queue;
}

bool System::isUserEFN(string &username, int R) {
    vector<User*> queue = BFS(R);
    User* temp = users.find(User(username));

    for (User* user: queue) {
        if (user == temp) {
            return true;
        }
    }

    return false;
}

void System::maxHeapify(int i) {
    int size = maxHeap.size();
    int largest = i;
    int l = 2 * i + 1;
    int r = 2 * i + 2;

    if (l < size && maxHeap[l]->getCount() > maxHeap[largest]->getCount())
        largest = l;
    if (r < size && maxHeap[r]->getCount() > maxHeap[largest]->getCount())
        largest = r;

    if (largest != i)
    {
        SongEntry* temp1 = maxHeap[i];
        maxHeap[i] = maxHeap[largest];
        maxHeap[largest] = temp1;

        maxHeapify(largest);
    }
}

void System::increaseKey(string& songName, int val) {
    SongEntry* temp = recList.find(songName);

    if (temp) {
        temp->increaseCount(val);
        this->maxHeapify(maxHeap.size() - 1);
        return;
    }
}

vector<string> System::extractTopSongs(int val) {
    vector<string> songTitles;

    if (maxHeap.empty()) {
        cout << " Heap is empty " << endl;
        return vector<string>();
    }

    for (int i = 0; i < val; i++) {
        songTitles.push_back(maxHeap[0]->getTitle());

        SongEntry* temp = maxHeap[0];
        maxHeap[0] = maxHeap[maxHeap.size() - 1];
        maxHeap[maxHeap.size() - 1] = temp;
        maxHeap.pop_back();
        maxHeapify(0);
    }

    return songTitles;
}

void System::showTopSongs(int val) {
    if (recList.size() < val) {
        val = recList.size();
    }

    vector<string> topSongs = extractTopSongs(val);

    for (string& songName : topSongs) {
        cout << songName  <<  " added to primary user library " << endl;
        SongEntry *temp1 = recList.find(SongEntry(songName));
        if (temp1) {
            primaryUser.getPrimaryUserLibrary().addSong(*temp1);
            recList.remove(*temp1);
        }
        Song* temp2 = systemLib.getSongList().find(Song(songName));
        if (temp2) {
            systemLib.getSongList().remove(*temp2);
        }
    }
}

void System::showRecList() {
    recList.printInorder(cout);
}

void System::removeSongFromPuLib(string& songTitle) {
    Song* temp = primaryUser.getPrimaryUserLibrary().getSongList().find(Song(songTitle));
    if (temp) {
        systemLib.getSongList().insert(*temp);
        primaryUser.getPrimaryUserLibrary().removeSongFromLibraryProc(songTitle);
        cout << songTitle << " is removed from Primary User Library" << endl;
    }
}
