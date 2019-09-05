#include <stdio.h>
#include <stdlib.h>
#include <math.h>

int main()
{
    int n;
    scanf("%d", &n);

    int value = 1;
    for(int i = 0; i <= n; i+=2) {
        printf((i == 0) ? "1\n" : "%d\n", value);
        value <<= 2;
    }

    return 0;
}
