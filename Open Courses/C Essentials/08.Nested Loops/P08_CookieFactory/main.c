#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <stdbool.h>

int main()
{
    int batches;
    scanf("%d", &batches);
    char ingredient[20];

    bool is_flour_found = false;
    bool is_egg_found = false;
    bool is_sugar_found = false;

    for(int i = 1; i <= batches; i++) {
        scanf("%s", ingredient);

        while(strcmp(ingredient, "Bake!")) {
            if(strcmp(ingredient, "flour") == 0) {
                is_flour_found = true;
            }
            else if(strcmp(ingredient, "eggs") == 0) {
                is_egg_found = true;
            }
            else if(strcmp(ingredient, "sugar") == 0) {
                is_sugar_found = true;
            }

            scanf("%s", ingredient);
        }

        if(is_flour_found && is_egg_found && is_sugar_found) {
            printf("Baking batch number %d...\n", i);
            is_flour_found = false;
            is_egg_found = false;
            is_sugar_found = false;
        }
        else {
            printf("The batter should contain flour, eggs and sugar!\n");
            i--;
        }
    }

    return 0;
}
