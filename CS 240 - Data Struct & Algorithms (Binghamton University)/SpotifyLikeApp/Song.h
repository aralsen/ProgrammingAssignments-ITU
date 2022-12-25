#ifndef Song_H
#define Song_H

#include <iostream>
#include "Duration.h"
#include "Timestamp.h"
#include <vector>

using namespace std;

class Song {
private:
    string title;
    string artist;
    Duration duration;
    bool explicit_{};
    Timestamp timestamp;
public:
    Song() = default;
    Song(string &Title) {
        title = Title;
    }
    Song(string &Title, string &Artist, Duration Duration, bool Explicit, Timestamp timestamp1)
    {
        title = Title;
        artist = Artist;
        duration = Duration;
        explicit_ = Explicit;
        timestamp = timestamp1;
    }
public:
    //getters
    string getTitle() const {return title;}
    string getArtist()const {return artist;}
    Duration getDuration()const {return duration;}
    int getSongDurationMinute() {return  duration.getMinute();}
    int getSongDurationSecond() {return duration.getSecond();}
    bool isExplicit() const {return explicit_;}

    //setters
    void setTitle( const string& );
    void setArtist( const string& );
    void setDuration(int minute, int second);
    void setExplicit( bool status );

    virtual void print() const;

    friend std::ostream& operator<<(std::ostream &os, const Song &s);
    friend bool operator==(const Song&, const Song&);
    bool operator==(const Song&);
    friend bool operator<(const Song&, const Song&);
    friend bool operator>(const Song&, const Song&);
};

#endif