#include <stdio.h>
#include <stdlib.h>

int main()
{
    int n;
    scanf("%d", &n);

    int iteration = 1;
    int last_number = 0;

    while(n != last_number) {
        for(int i = 0; i < iteration; i++) {
            printf("%d ", ++last_number);
            if(last_number == n) {
                break;
            }
        }
        iteration++;
        printf("\n");
    }

    return 0;
}
