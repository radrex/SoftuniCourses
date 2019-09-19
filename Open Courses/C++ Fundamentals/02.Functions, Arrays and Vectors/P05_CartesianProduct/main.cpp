#include <iostream>

int main()
{
    int n;
    std::cin >> n;

    if(n <= 0) {
        return 0;
    }

    int arr[n] = {0};
    for(int i = 0; i < n; i++) {
        int num;
        std::cin >> num;
        arr[i] = num;
    }

    if(n == 1) {
        std::cout << arr[0] * arr[0] << std::endl;
        return 0;
    }

    for(int i = 0; i < n; i++) {
        for(int j = 0; j < n; j++) {
            std::cout << arr[i] * arr[j] << ' ';
        }
    }

    return 0;
}
