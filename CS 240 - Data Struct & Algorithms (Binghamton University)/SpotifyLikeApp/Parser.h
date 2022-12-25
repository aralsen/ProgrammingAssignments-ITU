#ifndef _PARSER_H_
#define _PARSER_H_

#include <string>
#include <iostream>
#include <sstream>
#include <vector>

static const char *WHITESPACE = " \t\n\r";

class Parser {
   public:
      Parser(std::string line) : operation(""), args() {
          std::string arg;
          std::stringstream is;
          trim_whitespace(line);
          is.str(line);
          if (is >> operation) {
              while (is >> arg) {
                  arg.erase(0, arg.find_first_not_of(WHITESPACE));
                  args.push_back(arg);
              }
          }
      }

      std::string getOperation() {return operation;};
      std::vector<std::string> getArgs() {return args;};

      static void trim_whitespace(std::string &s) {
         s.erase(0, s.find_first_not_of(WHITESPACE));
         s.erase(s.find_last_not_of(WHITESPACE) + 1);
      }
   private:
      std::string operation;
      std::vector<std::string> args;
};
#endif
