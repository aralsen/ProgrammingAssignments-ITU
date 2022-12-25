#ifndef Library_H
#define Library_H

#include <string>
#include "Song.h"
#include "BST.h"

using namespace std;

class Library {
private:
    BST<Song> songList;
public:
    void addSong(const Song& song);
    void removeSongFromLibraryProc(string &basicString);
    void showSongDetails(const string &basicString);

    bool findSong(string &findSong);

    //getters
    BST<Song>& getSongList() {return songList;}

    void print();
};

#endif