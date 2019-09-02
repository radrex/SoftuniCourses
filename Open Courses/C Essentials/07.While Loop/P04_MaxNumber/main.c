#include <stdio.h>
#include <stdlib.h>
#include <limits.h>

int main()
{
    int n;
    scanf("%d", &n);
    int max_number = INT_MIN;

    while(n-- > 0) {
        int number;
        scanf("%d", &number);

        if(max_number < number) {
            max_number = number;
        }
    }

    printf("%d", max_number);

    return 0;
}
