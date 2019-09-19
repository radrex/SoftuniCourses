#include <iostream>

int main()
{
    int arr_length;
    std::cin >> arr_length;
    int arr[arr_length] = {0};

    for(int i = 0; i < arr_length; i++) {
        int num;
        std::cin >> num;
        arr[i] = num;
    }

    int best_count = 0;
    int current_count = 1;
    int best_number = arr[0];

    if(arr_length == 1) {
        std::cout << arr[0] << std::endl;
        return 0;
    }

    for(int i = 1; i < arr_length; i++) {
        if(arr[i - 1] == arr[i]) {
            current_count++;
        }
        else {
            current_count = 1;
        }

        if(current_count >= best_count) {
            best_count = current_count;
            best_number = arr[i];
        }
    }

    for(int i = 0; i < best_count; i++) {
        std::cout << best_number << ' ';
    }

    return 0;
}
