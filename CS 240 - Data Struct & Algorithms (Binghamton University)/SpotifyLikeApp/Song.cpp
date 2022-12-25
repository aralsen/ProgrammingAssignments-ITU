#include <iostream>
#include <string>
#include "Song.h"

using namespace std;

void Song::setTitle( const string& x )
{
    title = x;
}

void Song::setArtist( const string& x )
{
    artist = x;
}

void Song::setExplicit(bool status) {
    { explicit_ = status; }
}

void Song::setDuration(int minute, int second) {
    duration = Duration(minute, second);
}

void Song::print() const
{
    cout << "Title: " << title << ", Artist: " << artist  << ", Duration: " << duration << ", Explicit: " << explicit_ << endl;
}

ostream &operator<<(ostream &os, const Song &s)
{
    os  << "Title: " << s.title;

    return os;
}

bool Song::operator==(const Song & otherSong) {
    if (this->title == otherSong.title)
        return true;

    return false;
}

bool operator<(const Song & firstSong, const Song& secondSong) {
    if (firstSong.getTitle().compare(secondSong.getTitle()) > 0)
        return true;
    return false;
}

bool operator>(const Song & firstSong, const Song& secondSong) {
    if (firstSong.getTitle().compare(secondSong.getTitle()) < 0)
        return true;
    return false;
}

bool operator==(const Song & firstSong, const Song & secondSong) {
    if (firstSong.title == secondSong.title)
        return true;

    return false;
}
