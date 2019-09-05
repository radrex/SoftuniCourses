#include <stdio.h>
#include <stdlib.h>

int main()
{
    int n, l;
    scanf("%d %d", &n, &l);

    for(int i = 1; i < n; i++) {
        for(int j = 1; j < n; j++) {
            for(char k = 'a'; k < 'a' + l; k++) {
                for(char m = 'a'; m < 'a' + l; m++) {
                    for(int y = 1; y <= n; y++) {
                        if(y > i && y > j) {
                            printf("%d%d%c%c%d ", i, j, k, m, y);
                        }
                    }
                }
            }
        }
    }

    return 0;
}
