#include <stdio.h>
#include <stdlib.h>
#include <string.h>

int main()
{
    char season[20], group_type[20];
    scanf("%s %s", season, group_type);
    int students, nights;
    scanf("%d %d", &students, &nights);

    double price = 0.0;
    char sport[20];

    if(strcmp(season, "Winter") == 0) {
        if(strcmp(group_type, "boys") == 0) {
            price = students * 9.60 * nights;
            strcpy(sport, "Judo");
        }
        else if(strcmp(group_type, "girls") == 0) {
            price = students * 9.60 * nights;
            strcpy(sport, "Gymnastics");
        }
        else if(strcmp(group_type, "mixed") == 0) {
            price = students * 10.00 * nights;
            strcpy(sport, "Ski");
        }
    }
    else if(strcmp(season, "Spring") == 0) {
        if(strcmp(group_type, "boys") == 0) {
            price = students * 7.20 * nights;
            strcpy(sport, "Tennis");
        }
        else if(strcmp(group_type, "girls") == 0) {
            price = students * 7.20 * nights;
            strcpy(sport, "Athletics");
        }
        else if(strcmp(group_type, "mixed") == 0) {
            price = students * 9.50 * nights;
            strcpy(sport, "Cycling");
        }
    }
    else if(strcmp(season, "Summer") == 0) {
        if(strcmp(group_type, "boys") == 0) {
            price = students * 15.00 * nights;
            strcpy(sport, "Football");
        }
        else if(strcmp(group_type, "girls") == 0) {
            price = students * 15.00 * nights;
            strcpy(sport, "Volleyball");
        }
        else if(strcmp(group_type, "mixed") == 0) {
            price = students * 20.00 * nights;
            strcpy(sport, "Swimming");
        }
    }

    if(students >= 50) {
        price *= 0.50;
    }
    else if(students >= 20 && students < 50) {
        price *= 0.85;
    }
    else if(students >= 10 && students < 20) {
        price *= 0.95;
    }

    printf("%s %.2lf lv.", sport, price);

    return 0;
}
