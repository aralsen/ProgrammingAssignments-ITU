#ifndef SONGENTRY_H
#define SONGENTRY_H

#include "Song.h"

class SongEntry : public Song {
private:
    int count = 0;
public:
    SongEntry():Song(){};
    SongEntry(string &Title) : Song(Title) {};
    SongEntry(string &Title, int Count) : Song(Title) {
        count = Count;
    };
    SongEntry(string &Title, string &Artist, Duration Duration, bool Explicit, Timestamp timestamp1, int Count)
            : Song(Title, Artist, Duration, Explicit, timestamp1)
    {
        count = Count;
    };
public:
    int getCount() const {return count;};
    void increaseCount(int Count) { count += Count;};

    friend std::ostream& operator<<(std::ostream &os, const SongEntry &se) {
        os  << "Title: " << se.getTitle()
            << ", Count: " << se.count;

        return os;
    }
};


#endif
