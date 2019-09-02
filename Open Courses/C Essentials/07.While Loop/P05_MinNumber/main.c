#include <stdio.h>
#include <stdlib.h>
#include <limits.h>

int main()
{
    int n;
    scanf("%d", &n);
    int min_number = INT_MAX;

    while(n-- > 0) {
        int number;
        scanf("%d", &number);

        if(min_number > number) {
            min_number = number;
        }
    }

    printf("%d", min_number);

    return 0;
}
