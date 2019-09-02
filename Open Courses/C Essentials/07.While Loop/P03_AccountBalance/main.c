#include <stdio.h>
#include <stdlib.h>

int main()
{
    int contributions;
    scanf("%d", &contributions);

    double total = 0.0;

    while(contributions-- > 0){
        double contribution;
        scanf("%lf", &contribution);

        if(contribution < 0){
            printf("Invalid operation!\n");
            break;
        }

        printf("Increase: %.2lf\n", contribution);
        total += contribution;
    }

    printf("Total: %.2lf", total);

    return 0;
}
