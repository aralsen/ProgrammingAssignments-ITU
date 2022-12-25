#include <bits/stdc++.h>
#include "User.h"

void User::addFriend(User* newFriend) {
    for (User* user : friendList) {
        if (user == newFriend) {
            cout << "Friend already in friend list " << endl;
            return;
        }
    }

    friendList.push_back(newFriend);
    newFriend->friendList.push_back(this);
    cout << name << " added " << newFriend->name << endl;
}

void User::removeFriend(User *newFriend) {
    bool isFriend = false;

    for (User* user : friendList) {
        if (user == newFriend) {
            isFriend = true;
            break;
        }
    }

    if (isFriend) {
        friendList.erase(remove(friendList.begin(), friendList.end(), newFriend), friendList.end());
        cout << this->name << " removed  " << newFriend->name << " from friends list. ";
    }
}

void User::showFriends() {
    for (User* user : friendList) {
        cout << user->name << endl;
    }
}

std::ostream &operator<<(ostream &os, const User &s) {
    os  << "User Name: " << s.name  << endl;

    return os;
}

bool operator==(const User &firstUser, const User &secondUser) {
    if (firstUser.name == secondUser.name)
        return true;

    return false;
}

bool operator<(const User & firstUser, const User & secondUser) {
    if (firstUser.name.compare(secondUser.name) > 0)
        return true;
    return false;
}

bool operator>(const User & firstUser, const User & secondUser) {
    if (firstUser.name.compare(secondUser.name) < 0)
        return true;
    return false;
}
