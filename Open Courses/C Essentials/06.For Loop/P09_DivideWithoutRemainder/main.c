#include <stdio.h>
#include <stdlib.h>

int main()
{
    int n;
    scanf("%d", &n);
    double counter_1 = 0;
    double counter_2 = 0;
    double counter_3 = 0;

    for (int i = 0; i < n; i++) {
        int num;
        scanf("%d", &num);

        if (num % 2 == 0) {
            counter_1++;
        }
        if (num % 3 == 0) {
            counter_2++;
        }
        if (num % 4 == 0) {
            counter_3++;
        }
    }

    double percent_1 = (counter_1 / n) * 100;
    double percent_2 = (counter_2 / n) * 100;
    double percent_3 = (counter_3 / n) * 100;

    printf("%.2lf%%\n", percent_1);
    printf("%.2lf%%\n", percent_2);
    printf("%.2lf%%", percent_3);

    return 0;
}
