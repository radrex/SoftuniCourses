#include <stdio.h>
#include <stdlib.h>

int main()
{
    int num;
    scanf("%d", &num);

    if(!(num >= 100 && num <= 200) && num != 0) {
        printf("invalid");
    }

    return 0;
}
