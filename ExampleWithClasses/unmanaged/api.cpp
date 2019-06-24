#include <Windows.h>

#include "api.h"

//string returnBufferString;

pg::PasswordGenerator* __stdcall pg_initInstance(int size) {
    return new pg::PasswordGenerator(size);
}


void __stdcall pg_deleteInstance(pg::PasswordGenerator* instance) {
    delete instance;
}


pg::cpchar __stdcall pg_getPassword(pg::PasswordGenerator* instance) {
    static string returnBufferString;
    returnBufferString = instance->getStringPassword();
    return returnBufferString.c_str();
}


sm::Summator* sm_initInstance(int a, int b) {
    return new sm::Summator(a, b);
}


void sm_deleteInstance(sm::Summator* instance) {
    delete instance;
}


int sm_getSum(sm::Summator* instance, int a, int b) {
    return instance->getSum(a, b);
}


int sm_getInnerSum(sm::Summator* instance) {
    return instance->getInnerSum();
}


uint64_t sm_get64Sum(sm::Summator* instance, uint64_t a, uint64_t b) {
    return instance->get64Sum(a, b);
}