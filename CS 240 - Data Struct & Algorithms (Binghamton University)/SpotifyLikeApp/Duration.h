#ifndef DURATION
#define DURATION

class Duration {
private:
    int mm{},ss{};
public:
    Duration() = default;

    Duration(int minute, int second)
    {
        mm = minute;
        ss = second;
    }
public:
    friend std::ostream& operator<<(std::ostream& os, const Duration& dt);

    //getters
    int getMinute() const {return mm;}
    int getSecond() const {return ss;}

    //setters
    void setMinute(int min) {mm= min;}
    void setSecond(int sec) {ss = sec;}
};

#endif
 