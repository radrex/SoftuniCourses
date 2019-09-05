#include <stdio.h>
#include <stdlib.h>

int main()
{
    int magic_number;
    scanf("%d", &magic_number);

    for(int i = 1; i <= 9; i++) {
        for(int j = 1; j <= 9; j++) {
            for(int k = 1; k <= 9; k++) {
                for(int m = 1; m <= 9; m++) {
                    for(int n = 1; n <= 9; n++) {
                        for(int y = 1; y <= 9; y++) {
                            if(i * j * k * m * n * y == magic_number) {
                                printf("%d%d%d%d%d%d ", i, j, k, m, n, y);
                            }
                        }
                    }
                }
            }
        }
    }

    return 0;
}
