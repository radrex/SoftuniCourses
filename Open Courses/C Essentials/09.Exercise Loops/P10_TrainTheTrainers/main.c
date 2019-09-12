#include <stdio.h>
#include <stdlib.h>
#include <string.h>

int main()
{
    int n;
    scanf("%d", &n);

    char presentation[40];
    scanf(" %[^\n]", presentation);
    double students_final = 0.0;
    int course_count = 0;

    while(strcmp(presentation, "Finish")) {
        double average = 0.0;
        for(int i = 0; i < n; i++) {
            double grade;
            scanf("%lf", &grade);
            average += grade;
        }
        average /= n;
        course_count++;
        students_final += average;
        printf("%s - %.2lf.\n", presentation, average);
        scanf(" %[^\n]", presentation);
    }

    printf("Student's final assessment is %.2lf.", students_final / course_count);

    return 0;
}
