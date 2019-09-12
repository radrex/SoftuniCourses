#include <stdio.h>
#include <stdlib.h>

int main()
{
    int line1_start, line1_end, line2_start, line2_end;
    scanf("%d %d %d %d", &line1_start, &line1_end, &line2_start, &line2_end);

    for(int i = line1_start; i <= line1_end; i++) {
        for(int j = line1_start; j <= line1_end; j++) {
            for(int k = line2_start; k <= line2_end; k++) {
                for(int g = line2_start; g <= line2_end; g++) {
                    if ((i + g) == (j + k) && (i != j) && (k != g)) {
                        printf("%d%d\n", i, j);
                        printf("%d%d\n\n", k, g);
                    }
                }
            }
        }
    }

    return 0;
}
