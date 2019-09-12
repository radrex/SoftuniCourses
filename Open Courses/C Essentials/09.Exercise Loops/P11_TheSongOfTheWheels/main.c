#include <stdio.h>
#include <stdlib.h>

int main()
{
    int control_value;
    scanf("%d", &control_value);
    char password[5];
    password[4] = '\0';
    int pw_count = 0;

    for (int a = 1; a <= 9; a++) {
        for (int b = 1; b <= 9; b++) {
            for (int c = 1; c <= 9; c++) {
                for (int d = 1; d <= 9; d++) {
                    if (control_value == a * b + c * d) {
                        if (a < b && c > d) {
                            printf("%d%d%d%d ", a, b, c, d);
                            pw_count++;
                            if (pw_count == 4) {
                                password[0] = a + '0';
                                password[1] = b + '0';
                                password[2] = c + '0';
                                password[3] = d + '0';
                            }
                        }
                    }
                }
            }
        }
    }

    if(pw_count < 4) {
        printf("\nNo!");
    }
    else {
        printf("\nPassword: %s", password);
    }

    return 0;
}
