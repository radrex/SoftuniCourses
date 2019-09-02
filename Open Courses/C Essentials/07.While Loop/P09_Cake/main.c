#include <stdio.h>
#include <stdlib.h>
#include <string.h>

int main()
{
    int width, length;
    scanf("%d %d", &width, &length);
    int cake_size = width * length;

    char command[4];
    scanf("%s", command);

    while(!strcmp(command, "STOP") == 0) {
        int pieces = atoi(command);
        cake_size -= pieces;

        if(cake_size < 0) {
            printf("No more cake left! You need %d pieces more.", abs(cake_size));
            return 0;
        }

        scanf("%s", command);
    }

    printf("%d pieces are left.", cake_size);

    return 0;
}
