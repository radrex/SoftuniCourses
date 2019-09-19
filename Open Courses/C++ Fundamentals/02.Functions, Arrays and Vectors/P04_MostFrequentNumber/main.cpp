#include <iostream>
#include <algorithm>
#include <vector>

int main()
{
    int arr_length;
    std::cin >> arr_length;

    if(arr_length <= 0) {
        return 0;
    }

    int arr[arr_length] = {0};
    for(int i = 0; i < arr_length; i++) {
        int num;
        std::cin >> num;
        arr[i] = num;
    }

    if(arr_length == 1) {
        std::cout << arr[0] << std::endl;
        return 0;
    }

    int counter = 1;
    int best_count = 0;
    int best_num = 0;

    for(int i = 0; i < arr_length - 1; i++) {
        for(int j = i + 1; j < arr_length; j++) {
            if(arr[i] == arr[j]) {
                counter++;
            }
        }

        if(counter > best_count) {
            best_count = counter;
            best_num = arr[i];
        }

        counter = 1;
    }

    std::vector<int> most_frequent_nums;
    most_frequent_nums.push_back(best_num);

    for(int i = 0; i < arr_length; i++) {
        if(arr[i] == best_num) {
            continue;
        }

        for(int j = i + 1; j < arr_length; j++) {
            if(arr[i] == arr[j]) {
                counter++;
            }
        }

        if(counter == best_count) {
            most_frequent_nums.push_back(arr[i]);
        }

        counter = 1;
    }

    std::sort(most_frequent_nums.begin(), most_frequent_nums.end());
    for(int num : most_frequent_nums) {
        std::cout << num << ' ';
    }

    return 0;
}
