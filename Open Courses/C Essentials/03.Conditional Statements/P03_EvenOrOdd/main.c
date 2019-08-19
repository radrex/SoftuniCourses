#include <stdio.h>
#include <stdlib.h>

int main()
{
    int num;
    scanf("%d", &num);

    if(num % 2 == 0) {
        printf("even");
    }
    else {
        printf("odd");
    }

    return 0;
}
