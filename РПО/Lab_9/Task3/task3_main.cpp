// Задание 3. Основная программа, использующая модуль строк
#include <iostream>
#include <windows.h>
#include "task3_string_module.h"

using namespace std;

int main() {
    SetConsoleOutputCP(CP_UTF8);
    SetConsoleCP(CP_UTF8);

    string str = "Hello World from CPP";

    cout << "Строка: " << str << endl;
    cout << "Количество слов: " << countWords(str) << endl;
    cout << "Перевернутая строка: " << reverseString(str) << endl;
    cout << "Количество гласных: " << countVowels(str) << endl;

    return 0;
}
