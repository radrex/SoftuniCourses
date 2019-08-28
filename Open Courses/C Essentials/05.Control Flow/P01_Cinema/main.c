#include <stdio.h>
#include <stdlib.h>
#include <string.h>

int main()
{
    char ticket[20];
    scanf("%s", ticket);
    int rows, columns;
    scanf("%d %d", &rows, &columns);
    double price = 0.0;

    if(strcmp(ticket, "Premiere") == 0) {
        price = 12.00;
    }
    else if(strcmp(ticket, "Normal") == 0) {
        price = 7.50;
    }
    else if(strcmp(ticket, "Discount") == 0) {
        price = 5.00;
    }

    printf("%.2lf leva", (rows * columns) * price);

    return 0;
}
