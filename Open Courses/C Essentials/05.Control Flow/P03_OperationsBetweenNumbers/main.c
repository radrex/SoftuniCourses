#include <stdio.h>
#include <stdlib.h>

int main()
{
    int n1, n2;
    scanf("%d %d\n", &n1, &n2);
    char op;
    scanf("%c", &op);
    int result = 0;
    double result_real_number = 0.0;

    switch(op) {
        case '+':
            result = n1 + n2;
            if(result % 2 == 0) {
                printf("%d + %d = %d - even", n1, n2, result);
            }
            else {
                printf("%d + %d = %d - odd", n1, n2, result);
            }
            break;
        case '-':
            result = n1 - n2;
            if(result % 2 == 0) {
                printf("%d - %d = %d - even", n1, n2, result);
            }
            else {
                printf("%d - %d = %d - odd", n1, n2, result);
            }
            break;
        case '*':
            result = n1 * n2;
            if(result % 2 == 0) {
                printf("%d * %d = %d - even", n1, n2, result);
            }
            else {
                printf("%d * %d = %d - odd", n1, n2, result);
            }
            break;
        case '/':
            if(n2 == 0) {
                printf("Cannot divide %d by zero", n1);
                return 0;
            }

            result_real_number = (double)n1 / n2;
            if(result % 2 == 0) {
                printf("%d / %d = %.2lf", n1, n2, result_real_number);
            }
            else {
                printf("%d / %d = %.2lf", n1, n2, result_real_number);
            }
            break;
        case '%':
            if(n2 == 0) {
                printf("Cannot divide %d by zero", n1);
                return 0;
            }

            result_real_number = n1 % n2;
            if(result % 2 == 0) {
                printf("%d %% %d = %.0lf", n1, n2, result_real_number);
            }
            else {
                printf("%d %% %d = %.0lf", n1, n2, result_real_number);
            }
            break;
    }

    return 0;
}
