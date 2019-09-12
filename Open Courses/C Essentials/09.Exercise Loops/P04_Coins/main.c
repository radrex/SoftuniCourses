#include <stdio.h>
#include <stdlib.h>
#include <math.h>

int main()
{
    double coins;
    scanf("%lf", &coins);
    int coins_count = 0;

    while(coins > 0) {
        if(coins >= 2.00) {
            coins -= 2.00;
        }
        else if(coins >= 1.00) {
            coins -= 1.00;
        }
        else if(coins >= 0.50) {
            coins -= 0.50;
        }
        else if(coins >= 0.20) {
            coins -= 0.20;
        }
        else if(coins >= 0.10) {
            coins -= 0.10;
        }
        else if(coins >= 0.05) {
            coins -= 0.05;
        }
        else if(coins >= 0.02) {
            coins -= 0.02;
        }
        else if(coins >= 0.01) {
            coins -= 0.01;
        }

        coins_count++;
        coins = round(coins * 100) / 100;
    }

    printf("%d", coins_count);
    return 0;
}
