#include "PasswordGenerator.h"

namespace pg {
    PasswordGenerator::PasswordGenerator(int size) {
        srand(time(nullptr));
        this->size = size+1;
    }


    PasswordGenerator::~PasswordGenerator() {
    };

    string PasswordGenerator::getStringPassword() {
        string alph = "AaBbCcDdEeFfGgHhIiJjKkLlMmNnOoPpQqRrSsTtUuVvWwXxYyZz";
        string result;
        for (int i = 0; i < this->size; i++) {
            result += alph[rand() % alph.size()];
        }
        return result;
    }
}