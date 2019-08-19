#include <stdio.h>
#include <stdlib.h>
#include <string.h>

int main()
{
    char animal[50];
    scanf("%s", animal);

    if(strcmp(animal, "dog") == 0) {
        printf("mammal");
    }
    else if(strcmp(animal, "crocodile") == 0 ||
            strcmp(animal, "tortoise") == 0 ||
            strcmp(animal, "snake") == 0) {
        printf("reptile");
    }
    else if(strcmp(animal, "cat") == 0) {
        printf("unknown");
    }

    return 0;
}
