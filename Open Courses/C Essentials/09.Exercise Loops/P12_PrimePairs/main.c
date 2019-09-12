#include <stdio.h>
#include <stdlib.h>
#include <stdbool.h>
#include <math.h>

bool is_prime(int number) {
    if(number <= 1) return false;
    if(number == 2) return true;
    if(number % 2 == 0) return false;

    int boundary = (int)floor(sqrt(number));

    for(int i = 3; i <= boundary; i+=2) {
        if(number % i == 0) {
            return false;
        }
    }
    return true;
}

int main()
{
    int first_pair, second_pair, first_pair_end, second_pair_end;
    scanf("%d %d %d %d", &first_pair, &second_pair, &first_pair_end, &second_pair_end);

    for(int x1 = first_pair; x1 <= first_pair + first_pair_end; x1++) {
        for(int x2 = second_pair; x2 <= second_pair + second_pair_end; x2++) {
            if(is_prime(x1) && is_prime(x2)) {
                printf("%d%d\n", x1, x2);
            }
        }
    }

    return 0;
}
