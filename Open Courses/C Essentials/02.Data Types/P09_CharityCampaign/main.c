#include <stdio.h>
#include <stdlib.h>

int main()
{
    int days, workers, cakes, waffles, pancakes;
    scanf("%d %d %d %d %d", &days, &workers, &cakes, &waffles, &pancakes);

    double amount = ((cakes * 45 + waffles * 5.80 + pancakes * 3.20) * workers) * days;
    amount *= 0.875;

    printf("%.2f", amount);

    return 0;
}
