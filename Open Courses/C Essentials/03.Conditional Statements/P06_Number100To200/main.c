#include <stdio.h>
#include <stdlib.h>

int main()
{
    int num;
    scanf("%d", &num);

    if(num < 100) {
        printf("Less than 100");
    }
    else if(num >= 100 && num <= 200) {
        printf("Between 100 and 200");
    }
    else {
        printf("Greater than 200");
    }

    return 0;
}
