#include <iostream>

bool are_equal(int arr1[], int length1, int arr2[], int lenght2) {
    if(length1 > lenght2 || length1 < lenght2) {
        return false;
    }

    for(int i = 0; i < length1; i++) {
        if(arr1[i] != arr2[i]) {
            return false;
        }
    }
    return true;
}

int main()
{
    int arr1_length;
    std::cin >> arr1_length;
    int arr1[arr1_length] = {0};

    for(int i = 0; i < arr1_length; i++) {
        int num;
        std::cin >> num;
        arr1[i] = num;
    }

    int arr2_length;
    std::cin >> arr2_length;
    int arr2[arr2_length] = {0};

    for(int i = 0; i < arr2_length; i++) {
        int num;
        std::cin >> num;
        arr2[i] = num;
    }

    bool condition = are_equal(arr1, arr1_length, arr2, arr2_length);
    std::cout << (condition ? "equal": "not equal") << std::endl;

    return 0;
}

