#include <stdio.h>
#include <stdlib.h>
#include <string.h>

int main()
{
    double budget;
    scanf("%lf", &budget);
    char season[20];
    scanf("%s", season);

    char place[20], location[20];
    double price = 0.0;

    if(budget <= 1000) {
        strcpy(place, "Camp");
        if(strcmp(season, "Summer") == 0) {
            strcpy(location, "Alaska");
            price = budget * 0.65;
        }
        else if(strcmp(season, "Winter") == 0) {
            strcpy(location, "Morocco");
            price = budget * 0.45;
        }
    }
    else if(budget > 1000 && budget <= 3000) {
        strcpy(place, "Hut");
        if(strcmp(season, "Summer") == 0) {
            strcpy(location, "Alaska");
            price = budget * 0.80;
        }
        else if(strcmp(season, "Winter") == 0) {
            strcpy(location, "Morocco");
            price = budget * 0.60;
        }
    }
    else if(budget > 3000) {
        strcpy(place, "Hotel");
        price = budget * 0.90;
        if(strcmp(season, "Summer") == 0) {
            strcpy(location, "Alaska");
        }
        else if(strcmp(season, "Winter") == 0) {
            strcpy(location, "Morocco");
        }
    }

    printf("%s - %s - %.2lf", location, place, price);

    return 0;
}
