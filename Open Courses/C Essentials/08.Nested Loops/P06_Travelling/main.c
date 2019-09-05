#include <stdio.h>
#include <stdlib.h>
#include <string.h>

int main()
{
    char destination[50];
    scanf("%[^\n]", destination);

    while(strcmp(destination, "End")) {
        double budget;
        scanf("%lf", &budget);

        while(budget > 0) {
            double money;
            scanf("%lf\n", &money);
            budget -= money;
        }

        printf("Going to %s!\n", destination);
        scanf("%[^\n]", destination);
    }

    return 0;
}
