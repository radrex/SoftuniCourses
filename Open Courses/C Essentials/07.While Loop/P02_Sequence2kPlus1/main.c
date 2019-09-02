#include <stdio.h>
#include <stdlib.h>

int main()
{
    int n;
    scanf("%d", &n);
    int number = 1;

    while(number <= n){
        printf("%d\n", number);
        number = number * 2 + 1;
    }

    return 0;
}
