#include <stdio.h>
#include <stdlib.h>

int main()
{
    char architect[50];
    int buildings;
    scanf("%s %d", architect, &buildings);

    printf("The architect %s will need %d hours to complete %d project/s.", architect, buildings * 3, buildings);

    return 0;
}
