// Задание 3. Реализация модуля для работы со строками
#include "task3_string_module.h"

int countWords(const std::string& str) {
    int count = 0;
    bool inWord = false;
    for (int i = 0; i < str.length(); i++) {
        if (str[i] != ' ') {
            if (!inWord) {
                count++;
                inWord = true;
            }
        } else {
            inWord = false;
        }
    }
    return count;
}

std::string reverseString(const std::string& str) {
    std::string result = "";
    for (int i = str.length() - 1; i >= 0; i--)
        result += str[i];
    return result;
}

int countVowels(const std::string& str) {
    int count = 0;
    std::string vowels = "aeiouAEIOU";
    for (int i = 0; i < str.length(); i++) {
        if (vowels.find(str[i]) != std::string::npos)
            count++;
    }
    return count;
}
