#include <stdio.h>
#include <stdlib.h>
#include <string.h>

int main()
{
    char fruit[10], day[15];
    scanf("%s %s", fruit, day);
    double quantity;
    scanf("%lf", &quantity);
    double price = 0.0;

    if(strcmp(day, "Monday") == 0 || strcmp(day, "Tuesday") == 0 || strcmp(day, "Wednesday") == 0 ||
       strcmp(day, "Thursday") == 0 || strcmp(day, "Friday") == 0) {

        if(strcmp(fruit, "banana") == 0) {
            price = quantity * 2.50;
        }
        else if(strcmp(fruit, "apple") == 0) {
            price = quantity * 1.20;
        }
        else if(strcmp(fruit, "orange") == 0) {
            price = quantity * 0.85;
        }
        else if(strcmp(fruit, "grapefruit") == 0) {
            price = quantity * 1.45;
        }
        else if(strcmp(fruit, "kiwi") == 0) {
            price = quantity * 2.70;
        }
        else if(strcmp(fruit, "pineapple") == 0) {
            price = quantity * 5.50;
        }
        else if(strcmp(fruit, "grapes") == 0) {
            price = quantity * 3.85;
        }
        else {
            printf("error");
            return 0;
        }
    }
    else if(strcmp(day, "Saturday") == 0 || strcmp(day, "Sunday") == 0) {
        if(strcmp(fruit, "banana") == 0) {
            price = quantity * 2.70;
        }
        else if(strcmp(fruit, "apple") == 0) {
            price = quantity * 1.25;
        }
        else if(strcmp(fruit, "orange") == 0) {
            price = quantity * 0.90;
        }
        else if(strcmp(fruit, "grapefruit") == 0) {
            price = quantity * 1.60;
        }
        else if(strcmp(fruit, "kiwi") == 0) {
            price = quantity * 3.00;
        }
        else if(strcmp(fruit, "pineapple") == 0) {
            price = quantity * 5.60;
        }
        else if(strcmp(fruit, "grapes") == 0) {
            price = quantity * 4.20;
        }
        else {
            printf("error");
            return 0;
        }
    }
    else {
        printf("error");
        return 0;
    }

    printf("%.2f", price);

    return 0;
}
