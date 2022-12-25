#include <utility>
#include <fstream>

#ifndef LINETOKENIZER_H
#define LINETOKENIZER_H

class LineTokenizer {
public:
    LineTokenizer(const std::string& inputdir_name, const std::string& filename) {
        infile = new std::ifstream(filePath(inputdir_name, filename).c_str());
    }
    // nextLine() returns a vector of words that form the next line in the file.
    // If the line in the file is 'just beat it', then nextLine() returns a vector ['just beat it', '\n'].
    // if the vector is empty, it means that EOF has been reached.
    std::vector<std::string> nextLine() {
        std::string line;
        std::vector<std::string> lines;
        if (std::getline(*infile, line)) {
            lines.push_back(line);
        } else {
            // we have read in all lines from file.
            infile->close();
        }
        return lines;
    }

    ~LineTokenizer() {
        delete infile;
        infile = nullptr;
    }

private:
    static std::string filePath(const std::string& dir, const std::string& filename) {
        // creating the filepath.
        std::stringstream ss;
        ss << dir << "/" << filename;
        return ss.str();
    }

    std::ifstream* infile;
};

#endif
