// Задание 2. Реализация модуля ввода/вывода
#include <iostream>
#include "task2_math_module.h"
#include "task2_io_module.h"

using namespace std;

void printFactorial(int n) {
    cout << "Факториал " << n << " = " << factorial(n) << endl;
}

void printGCD(int a, int b) {
    cout << "НОД(" << a << ", " << b << ") = " << gcd(a, b) << endl;
}

void printLCM(int a, int b) {
    cout << "НОК(" << a << ", " << b << ") = " << lcm(a, b) << endl;
}
