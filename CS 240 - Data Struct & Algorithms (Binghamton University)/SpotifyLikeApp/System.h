#ifndef SYSTEM_H
#define SYSTEM_H

#include "Library.h"
#include "User.h"
#include "SongEntry.h"

class System {
private:
    Library systemLib;
    PrimaryUser primaryUser;
    BST<User> users;
    BST<SongEntry> recList;
    vector<SongEntry*> maxHeap;
public:
    void maxHeapify(int i);
    vector<string> extractTopSongs(int val);  //returns the max elements
    void increaseKey(string& songName, int val); //listen +1 on the heap
    void addSongToRecList(string& songName, int count);
    void showRecList();
    void showTopSongs(int val);

    void addUser(const User&);
    void addPrimaryUser(const PrimaryUser& pu);
    void addSongToPUlib(string& songName);

    void buildFriendship(string& user1, string& user2);
    void removeFriendship(string& user1, string& user2);
    void showUserFriends(string&);
    void printSystemUsers();

    vector<User*> BFS(int R);
    bool isUserEFN(string& username, int R);
    bool findSystemUser(string& findUser);
    bool findSystemSong(string& findSongTitle);
    bool findInRecoList(string& findSongEntry);

    PrimaryUser& getPrimaryUser() {return primaryUser;};
    Library& getSystemLibrary() {return systemLib;};

    void removeSongFromPuLib(string& songTitle);
};

#endif
