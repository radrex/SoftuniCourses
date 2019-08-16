#include <stdio.h>
#include <stdlib.h>

int main()
{
    double radius;
    scanf("%lf", &radius);

    double area = 3.14159265359 * radius * radius;
    double perimeter = 2 * 3.14159265359 * radius;

    printf("%.2f\n", area);
    printf("%.2f", perimeter);

    return 0;
}
