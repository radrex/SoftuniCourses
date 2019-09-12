#include <iostream>
#include <climits>

int main()
{
    int n;
    std::cin >> n;

    int min_number = INT_MAX;
    int max_number = INT_MIN;

    while(n-- > 0) {
        int number;
        std::cin >> number;

        if(number < min_number) {
            min_number = number;
        }

        if(number > max_number) {
            max_number = number;
        }
    }

    std::cout << min_number << ' ' << max_number << std::endl;

    return 0;
}
