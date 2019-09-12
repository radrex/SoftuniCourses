#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <stdbool.h>
#include <ctype.h>

void toLower(char* text) {
    for(int i = 0; i < strlen(text); i++) {
        text[i] = tolower(text[i]);
    }
}

int main()
{
    char command[10];
    scanf("%s", command);

    int primes_sum = 0;
    int non_primes_sum = 0;

    toLower(command);
    while(strcmp(command, "stop")) {
        int num = atoi(command);

        if(num < 0) {
            printf("Number is negative.\n");
            scanf("%s", command);
            toLower(command);
            continue;
        }

        bool is_prime = true;
        if(num == 1) {
            is_prime = false;
        }
        else {
            for(int i = num; i >= 2; i--) {
                if(num % i == 0 && i != num) {
                    is_prime = false;
                    break;
                }
            }
        }

        if(is_prime) {
            primes_sum += num;
        }
        else {
            non_primes_sum += num;
        }

        scanf("%s", command);
        toLower(command);
    }

    printf("Sum of all prime numbers is: %d\n", primes_sum);
    printf("Sum of all non prime numbers is: %d", non_primes_sum);

    return 0;
}
