#include <stdio.h>
#include <stdlib.h>
#include <string.h>

int main()
{
    double budget;
    scanf("%lf", &budget);
    char season[20];
    scanf("%s", season);

    double price = 0.0;
    char car[20], car_class[20];

    if(budget <= 100) {
        strcpy(car_class, "Economy class");
        if(strcmp(season, "Summer") == 0) {
            strcpy(car, "Cabrio");
            price = budget * 0.35;
        }
        else if(strcmp(season, "Winter") == 0) {
            strcpy(car, "Jeep");
            price = budget * 0.65;
        }
    }
    else if(budget >= 100 && budget <= 500) {
        strcpy(car_class, "Compact class");
        if(strcmp(season, "Summer") == 0) {
            strcpy(car, "Cabrio");
            price = budget * 0.45;
        }
        else if(strcmp(season, "Winter") == 0) {
            strcpy(car, "Jeep");
            price = budget * 0.80;
        }
    }
    else if(budget > 500) {
        strcpy(car_class, "Luxury class");
        strcpy(car, "Jeep");
        price = budget * 0.90;
    }

    printf("%s\n", car_class);
    printf("%s - %.2lf", car, price);

    return 0;
}
