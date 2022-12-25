#include "SpotifyLikeApp.h"

int main(int argc, char* argv[]) {
    std::string inputdir_name;
    std::string outputdir_name;

    switch (argc) {
        case 2: cout << "error: working directory name empty. no working directory provided.\n"
                        "using the input songs directory as the working directory" << endl;
                inputdir_name = argv[1];
                outputdir_name = inputdir_name;
                SpotifyLikeApp::run(inputdir_name, outputdir_name);

        case 3:  inputdir_name = argv[1];
                 outputdir_name = argv[2];
                 SpotifyLikeApp::run(inputdir_name, outputdir_name);

        default: cout << "error: incorrect number of command line arguments" << endl;
                 exit(1);
    }
}
