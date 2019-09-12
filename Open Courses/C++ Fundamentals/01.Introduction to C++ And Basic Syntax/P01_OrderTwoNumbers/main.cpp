#include <iostream>

int main()
{
    int num1, num2;
    std::cin >> num1 >> num2;

    if(num1 <= num2) {
        std::cout << num1 << " " << num2 << std::endl;
    }
    else if(num1 > num2) {
        std::cout << num2 << " " << num1 << std::endl;
    }

    return 0;
}
