#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <stdbool.h>

int main()
{
    char city[20];
    scanf("%s", city);
    double sales;
    scanf("%lf", &sales);

    bool sales_500 = sales >= 0 && sales <= 500;
    bool sales_1000 = sales > 500 && sales <= 1000;
    bool sales_10000 = sales > 1000 && sales <= 10000;
    bool sales_more_than_10000 = sales > 10000;

    if(strcmp(city, "Sofia") == 0) {
        if(sales_500) {
            sales *= 0.05;
        }
        else if(sales_1000) {
            sales *= 0.07;
        }
        else if(sales_10000) {
            sales *= 0.08;
        }
        else if(sales_more_than_10000) {
            sales *= 0.12;
        }
        else {
            printf("error");
            return 0;
        }
    }
    else if (strcmp(city, "Varna") == 0) {
        if(sales_500) {
            sales *= 0.045;
        }
        else if(sales_1000) {
            sales *= 0.075;
        }
        else if(sales_10000) {
            sales *= 0.10;
        }
        else if(sales_more_than_10000) {
            sales *= 0.13;
        }
        else {
            printf("error");
            return 0;
        }
    }
    else if (strcmp(city, "Plovdiv") == 0) {
        if(sales_500) {
            sales *= 0.055;
        }
        else if(sales_1000) {
            sales *= 0.08;
        }
        else if(sales_10000) {
            sales *= 0.12;
        }
        else if(sales_more_than_10000) {
            sales *= 0.145;
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

    printf("%.2f", sales);

    return 0;
}
