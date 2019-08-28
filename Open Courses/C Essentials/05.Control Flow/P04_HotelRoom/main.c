#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <stdbool.h>

int main()
{
    char month[20];
    scanf("%s", month);
    int nights;
    scanf("%d", &nights);
    double studio_price = 0.0;
    double apartment_price = 0.0;

    bool more_than_7 = nights > 7 && nights <= 14;
    bool more_than_14 = nights > 14;

    if(strcmp(month, "May") == 0 || strcmp(month, "October") == 0) {
        studio_price = 50.00;
        apartment_price = 65.00;

        if(more_than_7) {
            studio_price *= 0.95;
        }

        if(more_than_14) {
            studio_price *= 0.70;
            apartment_price *= 0.90;
        }
    }
    else if(strcmp(month, "June") == 0 || strcmp(month, "September") == 0) {
        studio_price = 75.20;
        apartment_price = 68.70;

        if(more_than_14) {
            studio_price *= 0.80;
            apartment_price *= 0.90;
        }
    }
    else if(strcmp(month, "July") == 0 || strcmp(month, "August") == 0) {
        studio_price = 76.00;
        apartment_price = 77.00;

        if(more_than_14) {
            apartment_price *= 0.90;
        }
    }

    printf("Apartment: %.2lf lv.\n", apartment_price * nights);
    printf("Studio: %.2lf lv.", studio_price * nights);

    return 0;
}
