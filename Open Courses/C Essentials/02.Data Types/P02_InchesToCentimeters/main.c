#include <stdio.h>
#include <stdlib.h>

int main()
{
    double inches;
    scanf("%lf", &inches);

    double centimeters = inches * 2.54;
    printf("%f", centimeters);

    return 0;
}
