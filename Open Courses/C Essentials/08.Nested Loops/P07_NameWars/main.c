#include <stdio.h>
#include <stdlib.h>
#include <string.h>

int main()
{
    char name[20];
    scanf("%s", name);

    char winner[20];
    int max_value = 0;

    while(strcmp(name, "STOP")) {
        int current_value = 0;
        for(int i = 0; i < strlen(name); i++) {
            current_value += name[i];
        }

        if(max_value < current_value) {
            max_value = current_value;
            strcpy(winner, name);
        }
        scanf("%s", name);
    }

    printf("Winner is %s - %d!", winner, max_value);

    return 0;
}
