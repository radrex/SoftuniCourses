#include <stdio.h>
#include <stdlib.h>
#include <math.h>

int main()
{
    double income, grade, minimum_wage;
    scanf("%lf %lf %lf", &income, &grade, &minimum_wage);

    double social_scholarship, excellence_scholarship = 0.0;

    if(income < minimum_wage && grade > 4.50) {
        social_scholarship = minimum_wage * 0.35;
    }

    if(grade >= 5.50) {
        excellence_scholarship = grade * 25;
    }

    if(social_scholarship != 0 && excellence_scholarship != 0) {
        if(social_scholarship > excellence_scholarship) {
            printf("You get a Social scholarship %.0f BGN", floor(social_scholarship));
        }
        else {
            printf("You get a scholarship for excellent results %.0f BGN", floor(excellence_scholarship));
        }
    }
    else if(social_scholarship != 0 && excellence_scholarship == 0) {
        printf("You get a Social scholarship %.0f BGN", floor(social_scholarship));
    }
    else if(social_scholarship == 0 && excellence_scholarship != 0) {
        printf("You get a scholarship for excellent results %.0f BGN", floor(excellence_scholarship));
    }
    else {
        printf("You cannot get a scholarship!");
    }

    return 0;
}
