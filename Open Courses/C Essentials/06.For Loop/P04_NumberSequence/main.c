#include <stdio.h>
#include <stdlib.h>
#include <limits.h>

int main()
{
    int n;
    scanf("%d", &n);

    int max = INT_MIN;
    int min = INT_MAX;

    for(int i = 0; i < n; i++) {
        int number;
        scanf("%d", &number);

        if(max < number) {
            max = number;
        }

        if(min > number) {
            min = number;
        }
    }

    printf("Max number: %d\n", max);
    printf("Min number: %d", min);

    return 0;
}
