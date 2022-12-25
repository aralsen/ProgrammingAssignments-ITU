#include "System.h"
#include "Parser.h"

class SpotifyLikeApp {
private:
    static System system;
private:
    static void insertSongToLibraryProc(vector<string> *songInfo);
    static void listAllSongsFromSystem();
    static void listAllUsersFromSystem();
    static void exitProc();
    static void doWorkForOption(const string &option, vector<string> args, const string& outputdir);
public:
    [[noreturn]] static void run(const string&, const string&);
};