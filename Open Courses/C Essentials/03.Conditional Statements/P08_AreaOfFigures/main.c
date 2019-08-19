#include <stdio.h>
#include <stdlib.h>
#include <string.h>

int main()
{
    char shape[9];
    scanf("%s", shape);

    if(strcmp(shape, "square") == 0) {
        double a;
        scanf("%lf", &a);
        printf("%.3f", a * a);
    }
    else if(strcmp(shape, "rectangle") == 0) {
        double a, b;
        scanf("%lf %lf", &a, &b);
        printf("%.3f", a * b);
    }
    else if(strcmp(shape, "circle") == 0) {
        double radius;
        scanf("%lf", &radius);
        printf("%.3f", 3.14159265359 * radius * radius);
    }
    else if(strcmp(shape, "triangle") == 0) {
        double b, h;
        scanf("%lf %lf", &b, &h);
        printf("%.3f", 1.0 / 2.0 * b * h);
    }

    return 0;
}
