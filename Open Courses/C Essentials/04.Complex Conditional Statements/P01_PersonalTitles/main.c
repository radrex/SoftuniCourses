#include <stdio.h>
#include <stdlib.h>

int main()
{
    double age;
    char gender;
    scanf("%lf %c", &age, &gender);

    switch(gender) {
        case 'm':
            if(age > 0 && age < 16) {
                printf("Master");
            }
            else {
                printf("Mr.");
            }
            break;

        case 'f':
            if(age > 0 && age < 16) {
                printf("Miss");
            }
            else {
                printf("Ms.");
            }
            break;

        default:
            break;
    }

    return 0;
}
