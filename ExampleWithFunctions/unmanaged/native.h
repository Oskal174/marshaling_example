#pragma once

#ifdef NATIVE_EXPORTS // Совпадает с символом, который по умолчанию в настройках символов препроцессора
#define MATHLIBRARY_API __declspec(dllexport)
#else
#define MATHLIBRARY_API __declspec(dllimport)
#endif

// Функция сложения, которую мы экспортируем из библиотеки
extern "C" MATHLIBRARY_API int fast_add(const int a, const int b);
