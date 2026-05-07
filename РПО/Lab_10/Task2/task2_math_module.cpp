// Задание 2. Реализация математического модуля
#include "task2_math_module.h"

long long factorial(int n) {
    long long result = 1;
    for (int i = 2; i <= n; i++)
        result *= i;
    return result;
}

int gcd(int a, int b) {
    while (b != 0) {
        int temp = b;
        b = a % b;
        a = temp;
    }
    return a;
}

int lcm(int a, int b) {
    return a / gcd(a, b) * b;
}
