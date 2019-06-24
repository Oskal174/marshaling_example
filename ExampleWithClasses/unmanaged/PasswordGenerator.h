#pragma once

#include <string>
#include <Windows.h>
#include <random>
#include <ctime>

using std::string;


namespace pg {
    typedef char* pchar;
    typedef const char* cpchar;

    class PasswordGenerator {
    public:
        PasswordGenerator(int size);
        ~PasswordGenerator();

        string getStringPassword();

    private:
        int size;
    };
}