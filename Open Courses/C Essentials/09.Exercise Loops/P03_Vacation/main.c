#include <stdio.h>
#include <stdlib.h>
#include <string.h>

int main()
{
    double vacation_cost, budget;
    scanf("%lf %lf", &vacation_cost, &budget);

    int days = 0;
    int spending_days = 0;

    while(spending_days < 5 && budget < vacation_cost) {
        char action[5];
        scanf("%s", action);
        double amount;
        scanf("%lf", &amount);

        if(strcmp(action, "spend") == 0) {
            if(budget > amount) {
                budget -= amount;
            }
            else {
                budget = 0;
            }
            days++;
            spending_days++;
        }
        else if(strcmp(action, "save") == 0) {
            budget += amount;
            days++;
            spending_days = 0;
        }
    }

    if(spending_days == 5) {
        printf("You can't save the money.\n");
        printf("%d", days);
    }

    if (budget >= vacation_cost) {
        printf("You saved the money for %d days.", days);
    }

    return 0;
}
