#include <stdio.h>
#include <stdlib.h>
#include <string.h>

int main()
{
    char product[10], city[10];
    scanf("%s %s", product, city);
    double quantity;
    scanf("%lf", &quantity);
    double price = 0;

    if(strcmp(city, "Sofia") == 0) {
        if(strcmp(product, "coffee") == 0) {
            price = quantity * 0.50;
        }
        else if(strcmp(product, "water") == 0) {
            price = quantity * 0.80;
        }
        else if(strcmp(product, "beer") == 0) {
            price = quantity * 1.20;
        }
        else if(strcmp(product, "sweets") == 0) {
            price = quantity * 1.45;
        }
        else if(strcmp(product, "peanuts") == 0) {
            price = quantity * 1.60;
        }
    }
    else if(strcmp(city, "Plovdiv") == 0) {
        if(strcmp(product, "coffee") == 0) {
            price = quantity * 0.40;
        }
        else if(strcmp(product, "water") == 0) {
            price = quantity * 0.70;
        }
        else if(strcmp(product, "beer") == 0) {
            price = quantity * 1.15;
        }
        else if(strcmp(product, "sweets") == 0) {
            price = quantity * 1.30;
        }
        else if(strcmp(product, "peanuts") == 0) {
            price = quantity * 1.50;
        }
    }
    else if(strcmp(city, "Varna") == 0) {
        if(strcmp(product, "coffee") == 0) {
            price = quantity * 0.45;
        }
        else if(strcmp(product, "water") == 0) {
            price = quantity * 0.70;
        }
        else if(strcmp(product, "beer") == 0) {
            price = quantity * 1.10;
        }
        else if(strcmp(product, "sweets") == 0) {
            price = quantity * 1.35;
        }
        else if(strcmp(product, "peanuts") == 0) {
            price = quantity * 1.55;
        }
    }

    printf("%g", price);

    return 0;
}
