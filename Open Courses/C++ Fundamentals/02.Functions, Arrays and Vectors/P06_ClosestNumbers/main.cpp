#include <iostream>
#include <cmath>

int main()
{
    int n;
    std::cin >> n;

    if(n == 0) {
        return 0;
    }

    if(n == 1) {
        std::cout << 0 << std::endl;
        return 0;
    }

    int arr[n] = {0};
    for(int i = 0; i < n; i++) {
        int num;
        std::cin >> num;
        arr[i] = num;
    }

    int closest_numbers_diff = INT_MAX;
    for(int i = 0; i < n - 1; i++) {
        for(int j = i + 1; j < n; j++) {
            int diff = abs(arr[i] - arr[j]);
            if(closest_numbers_diff >= diff) {
                closest_numbers_diff = diff;
            }
        }
    }

    std::cout << closest_numbers_diff << std::endl;
    return 0;
}
