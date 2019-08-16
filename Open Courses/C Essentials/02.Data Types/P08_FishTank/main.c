#include <stdio.h>
#include <stdlib.h>

int main()
{
    int length, width, height;
    double percent;
    scanf("%d %d %d %lf", &length, &width, &height, &percent);

    int volume = length * width * height;
    double liters = (volume * 0.001) * (1 - percent * 0.01);

    printf("%.3f", liters);

    return 0;
}
