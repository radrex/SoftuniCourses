#include <stdio.h>
#include <stdlib.h>

int main()
{
    int n;
    scanf("%d", &n);

    int odd_sum = 0;
    int even_sum = 0;

    for(int i = 1; i <= n; i++) {
        int num;
        scanf("%d", &num);
        if(i % 2 != 0) {
            odd_sum += num;
        }
        else {
            even_sum += num;
        }
    }

    if(odd_sum == even_sum) {
        printf("Yes\nSum = %d", odd_sum);
    }
    else {
        printf("No\nDiff = %d", abs(odd_sum - even_sum));
    }

    return 0;
}
