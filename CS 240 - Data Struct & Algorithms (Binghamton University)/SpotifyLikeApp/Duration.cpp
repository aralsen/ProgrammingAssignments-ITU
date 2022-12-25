#include <iostream>
#include <iomanip>
#include "Duration.h"

using namespace std;

ostream& operator<<(ostream& os, const Duration& dt)
{
    os  << setw(2) << setfill('0') << dt.mm << ":"
        << setw(2) << setfill('0') << dt.ss;

    return os;
}