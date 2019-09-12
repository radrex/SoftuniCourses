#include <stdio.h>
#include <stdlib.h>

int main()
{
    int start, end;
    scanf("%d %d", &start, &end);

    for(int i = start; i <= end; i++) {
        int odd_sum = 0;
        int even_sum = 0;

        char num_as_text[7];
        sprintf(num_as_text, "%d", i);

        for(int j = 0; j < 6; j++) {
            int digit = num_as_text[j] - '0';
            if(j % 2 == 0) {
                even_sum += digit;
            }
            else {
                odd_sum += digit;
            }
        }

        if(odd_sum == even_sum) {
            printf("%d ", i);
        }
    }

    return 0;
}
