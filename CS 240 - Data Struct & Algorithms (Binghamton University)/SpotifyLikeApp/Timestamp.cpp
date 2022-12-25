#include <iomanip>
#include <string>
#include "Timestamp.h"

using namespace std;

unsigned int Timestamp::getSecs() const {
    return secs;
}

void Timestamp::setSecs(unsigned int sec) {
    Timestamp::secs = sec;
}

unsigned int Timestamp::getMins() const {
    return mins;
}

void Timestamp::setMins(unsigned int min) {
    Timestamp::mins = min;
}

unsigned int Timestamp::getHours() const {
    return hours;
}

void Timestamp::setHours(unsigned int hour) {
    Timestamp::hours = hour;
}

unsigned int Timestamp::getMonth() const {
    return month;
}

void Timestamp::setMonth(unsigned int months) {
    Timestamp::month = months;
}

unsigned int Timestamp::getDay() const {
    return day;
}

void Timestamp::setDay(unsigned int days) {
    Timestamp::day = days;
}

unsigned int Timestamp::getYear() const {
    return year;
}

void Timestamp::setYear(unsigned int years) {
    Timestamp::year = years;
}

void Timestamp::init(struct tm *tm_time) {
   secs = (unsigned int) tm_time->tm_sec;
   mins = (unsigned int) tm_time->tm_min;
   hours = (unsigned int) tm_time->tm_hour;
   month = (unsigned int) tm_time->tm_mon + 1;
   day = (unsigned int) tm_time->tm_mday;
   year = (unsigned int) tm_time->tm_year + 1900;
}

Timestamp::Timestamp() {
   now();
}

void Timestamp::now() {
   time_t rightnow = time(0);
   struct tm *tm_time = localtime(&rightnow);
   init(tm_time);
}

string Timestamp::toString() const {
    char buff[100];
    snprintf(buff, sizeof(buff),"%02d/%02d/%04d %02d:%02d:%02d", month, day, year, hours, mins, secs);
    string formatString = buff;
    return formatString;
}

std::ostream &operator<<(ostream &os, const Timestamp &ts) {
    os      << setw(2) << setfill('0') << ts.month << "/"
            << setw(2) << setfill('0') << ts.day << "/"
            << setw(4) << setfill('0') << ts.year << " "

            << setw(2) << setfill('0') << ts.hours << ":"
            << setw(2) << setfill('0') << ts.mins << ":"
            << setw(2) << setfill('0') << ts.secs;

    return os;
}


