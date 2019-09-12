#include <iostream>

int main()
{
    int num1, num2, num3;
    std::cin >> num1 >> num2 >> num3;

    if(num1 == 0 || num2 == 0 || num3 == 0) {
        std::cout << '+' << std::endl;
        return 0;
    }

    if((num1 < 0 && num2 > 0 && num3 > 0) ||
       (num1 > 0 && num2 < 0 && num3 > 0) ||
       (num1 > 0 && num2 > 0 && num3 < 0) ||
       (num1 < 0 && num2 < 0 && num3 < 0)) {
        std::cout << '-' << std::endl;
    }
    else {
        std::cout << '+' << std::endl;
    }

    return 0;
}
