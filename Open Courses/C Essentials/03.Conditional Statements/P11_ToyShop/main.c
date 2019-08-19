#include <stdio.h>
#include <stdlib.h>

int main()
{
    double vacantion_price;
    scanf("%lf", &vacantion_price);
    int puzzles, dolls, bears, minions, trucks;
    scanf("%d %d %d %d %d", &puzzles, &dolls, &bears, &minions, &trucks);

    double sum = puzzles*2.60 + dolls*3 + bears*4.10 + minions*8.20 + trucks*2;
    int toys_count = puzzles + dolls + bears + minions + trucks;

    if(toys_count >= 50) {
        sum *= 0.75;
    }

    sum -= sum * 0.10;

    if(sum >= vacantion_price) {
        sum -= vacantion_price;
        printf("Yes! %.2f lv left.", sum);
    }
    else
    {
        vacantion_price -= sum;
        printf("Not enough money! %.2f lv needed.", vacantion_price);
    }

    return 0;
}
