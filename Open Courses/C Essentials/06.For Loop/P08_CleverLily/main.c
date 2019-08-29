#include <stdio.h>
#include <stdlib.h>
#include <math.h>

int main()
{
    int age;
    scanf("%d", &age);
    double washingMachinePrice;
    scanf("%lf", &washingMachinePrice);
    int toyPrice;
    scanf("%d", &toyPrice);

    int moneyYears = 0;
    int toyYears = 0;
    double money = 0.0;

    for (int i = 1; i <= age; i++) {
        if (i % 2 == 0) {
            moneyYears++;
        }
        else {
            toyYears++;
        }
    }

    for (int i = 1; i <= moneyYears; i++) {
        money += 10 * i;
    }

    money += (toyYears * toyPrice) - moneyYears;
    double diff = fabs(washingMachinePrice - money);

    if (money >= washingMachinePrice) {
        printf("Yes! %.2lf", diff);
    }
    else {
        printf("No! %.2lf", diff);
    }

    return 0;
}
