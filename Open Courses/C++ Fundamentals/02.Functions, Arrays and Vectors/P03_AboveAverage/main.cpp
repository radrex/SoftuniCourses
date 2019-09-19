#include <iostream>
#include <cmath>

int main()
{
    int array_length;
    std::cin >> array_length;
    int arr[array_length] = {0};
    int average = 0;

    for(int i = 0; i < array_length; i++) {
        int num;
        std::cin >> num;
        arr[i] = num;
        average += num;
    }

    average /= array_length;

    for(int num : arr) {
        if(num >= average) {
            std::cout << num << ' ';
        }
    }

    return 0;
}
