#include <stdio.h>
#include <stdlib.h>
#include <string.h>

int main()
{
    int degrees;
    scanf("%d", &degrees);
    char day_time[20];
    scanf("%s", day_time);
    char outfit[20], shoes[20];

    if(strcmp(day_time, "Morning") == 0) {
        if(degrees >= 10 && degrees <= 18) {
            strcpy(outfit, "Sweatshirt");
            strcpy(shoes, "Sneakers");
        }
        else if(degrees > 18 && degrees <= 24) {
            strcpy(outfit, "Shirt");
            strcpy(shoes, "Moccasins");
        }
        else if(degrees >= 25) {
            strcpy(outfit, "T-Shirt");
            strcpy(shoes, "Sandals");
        }
    }
    else if(strcmp(day_time, "Afternoon") == 0) {
        if(degrees >= 10 && degrees <= 18) {
            strcpy(outfit, "Shirt");
            strcpy(shoes, "Moccasins");
        }
        else if(degrees > 18 && degrees <= 24) {
            strcpy(outfit, "T-Shirt");
            strcpy(shoes, "Sandals");
        }
        else if(degrees >= 25) {
            strcpy(outfit, "Swim Suit");
            strcpy(shoes, "Barefoot");
        }
    }
    else if(strcmp(day_time, "Evening") == 0) {
        if(degrees >= 10 && degrees <= 18) {
            strcpy(outfit, "Shirt");
            strcpy(shoes, "Moccasins");
        }
        else if(degrees > 18 && degrees <= 24) {
            strcpy(outfit, "Shirt");
            strcpy(shoes, "Moccasins");
        }
        else if(degrees >= 25) {
            strcpy(outfit, "Shirt");
            strcpy(shoes, "Moccasins");
        }
    }

    printf("It's %d degrees, get your %s and %s.", degrees, outfit, shoes);

    return 0;
}
