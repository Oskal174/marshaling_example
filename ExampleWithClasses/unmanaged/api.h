#pragma once

#include "PasswordGenerator.h"
#include "Summator.h"

#ifdef BACKEND_EXPORTS 
#define BACKEND_API __declspec(dllexport)
#else
#define BACKEND_API __declspec(dllimport)
#endif


extern "C" BACKEND_API pg::PasswordGenerator* __stdcall pg_initInstance(int size);
extern "C" BACKEND_API void __stdcall pg_deleteInstance(pg::PasswordGenerator* instance);
extern "C" BACKEND_API void __stdcall pg_generate(pg::PasswordGenerator* instance);
extern "C" BACKEND_API pg::cpchar __stdcall pg_getPassword(pg::PasswordGenerator* instance);

extern "C" BACKEND_API sm::Summator* sm_initInstance(int a, int b);
extern "C" BACKEND_API void sm_deleteInstance(sm::Summator* instance);
extern "C" BACKEND_API int sm_getSum(sm::Summator* instance, int a, int b);
extern "C" BACKEND_API int sm_getInnerSum(sm::Summator* instance);
extern "C" BACKEND_API uint64_t sm_get64Sum(sm::Summator* instance, uint64_t a, uint64_t b);
