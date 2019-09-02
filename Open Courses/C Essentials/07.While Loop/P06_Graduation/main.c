#include <stdio.h>
#include <stdlib.h>

int main()
{
    char student[20];
    scanf("%s", student);

    int n = 1;
    double average_grade = 0.0;

    while(n <= 12) {
        double grade;
        scanf("%lf", &grade);

        if(grade < 4.00) {
            continue;
        }

        average_grade += grade;
        n++;
    }

    average_grade /= 12.0;
    if(average_grade >= 4.00) {
        printf("%s graduated. Average grade: %.2lf", student, average_grade);
    }

    return 0;
}
