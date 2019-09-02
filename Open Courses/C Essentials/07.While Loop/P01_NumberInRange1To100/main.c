#include <stdio.h>
#include <stdlib.h>

int main()
{
    int number;
    scanf("%d", &number);

    while(number <= 0 || number > 100){
        printf("Invalid number!\n");
        scanf("%d", &number);
    }

    printf("The number is: %d", number);

    return 0;
}
