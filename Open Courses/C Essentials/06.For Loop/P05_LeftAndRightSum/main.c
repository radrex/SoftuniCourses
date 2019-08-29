#include <stdio.h>
#include <stdlib.h>
#include <math.h>

int main()
{
    int n;
    scanf("%d" , &n);

    int sum1 = 0;
    int sum2 = 0;

    for(int i = 1; i <= 2 * n; i++) {
        int num;
        scanf("%d", &num);

        if(i <= n) {
            sum1 += num;
        }
        else {
            sum2 += num;
        }
    }

    if(sum1 == sum2) {
        printf("Yes, sum = %d", sum1);
    }
    else {
        printf("No, diff = %d", abs(sum1 - sum2));
    }

    return 0;
}
