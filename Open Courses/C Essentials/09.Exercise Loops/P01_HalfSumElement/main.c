#include <stdio.h>
#include <stdlib.h>
#include <limits.h>
#include <math.h>

int main()
{
    int n;
    scanf("%d", &n);
    int sum = 0;
    int max = INT_MIN;

    while(n-- > 0) {
        int num;
        scanf("%d", &num);

        sum += num;
        if(num > max) {
            max = num;
        }
    }

    if(sum - max == max) {
        printf("Yes\n");
        printf("Sum = %d", sum - max);
    }
    else {
        printf("No\n");
        printf("Diff = %d", abs(max - (sum - max)));
    }

    return 0;
}
