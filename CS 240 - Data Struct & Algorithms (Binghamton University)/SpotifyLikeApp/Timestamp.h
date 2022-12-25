#ifndef TIMESTAMP_H
#define TIMESTAMP_H

class Timestamp {
    private:
        unsigned int  secs{}, mins{}, hours{};
        unsigned int month{}, day{}, year{};
	public:
		Timestamp();
    public:
		void init(struct tm*);
        void now();
		std::string toString() const;
        friend std::ostream& operator<<(std::ostream& os, const Timestamp& dt);

        //getters
        unsigned int getSecs() const;
        unsigned int getMins() const;
        unsigned int getHours() const;
        unsigned int getMonth() const;
        unsigned int getDay() const;
        unsigned int getYear() const;

        //setters
        void setSecs(unsigned int secs);
        void setMins(unsigned int mins);
        void setHours(unsigned int hours);
        void setMonth(unsigned int month);
        void setDay(unsigned int day);
        void setYear(unsigned int year);
};

#endif
