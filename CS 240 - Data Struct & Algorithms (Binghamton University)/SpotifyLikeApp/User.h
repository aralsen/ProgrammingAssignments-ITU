#ifndef USER_H
#define USER_H

#include <utility>
#include "Library.h"

class User {
private:
    string name;
    vector<User*> friendList;
public:
    User() = default;
    User(const string& userName) {
        name = userName;
    }
public:
    void addFriend(User*);
    void removeFriend(User*);
    void showFriends();
    void listenSong();

    string& getUserName() {return name;};
    vector<User*>& getFriendList() {return friendList;}

    friend std::ostream& operator<<(std::ostream &os, const User &user);
    friend bool operator==(const User&, const User&);
    friend bool operator<(const User&, const User&);
    friend bool operator>(const User&, const User&);
};

class PrimaryUser : public User {
private:
    Library puLib;
public:
    PrimaryUser():User(){};
    PrimaryUser(const string& Name) : User(Name) {};
public:
    void getRecommandedSongs();
    void showSongs();

    Library& getPrimaryUserLibrary() {return puLib;};
};

#endif
