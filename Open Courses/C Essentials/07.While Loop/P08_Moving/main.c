#include <stdio.h>
#include <stdlib.h>
#include <string.h>

int main()
{
    int width, length, height;
    scanf("%d %d %d", &width, &length, &height);
    int cubic_meters = width * length * height;

    char command[4];
    scanf("%s", command);

    while(!strcmp(command, "Done") == 0) {
        int box = atoi(command);
        cubic_meters -= box;

        if(cubic_meters < 0) {
            printf("No more free space! You need %d Cubic meters more.", abs(cubic_meters));
            return 0;
        }

        scanf("%s", command);
    }

    printf("%d Cubic meters left.", cubic_meters);

    return 0;
}
