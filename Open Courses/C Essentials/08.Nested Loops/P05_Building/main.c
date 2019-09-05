#include <stdio.h>
#include <stdlib.h>

int main()
{
    int floors, rooms;
    scanf("%d %d", &floors, &rooms);

    for(int i = floors; i > 0; i--) {
        for(int j = 0; j < rooms; j++) {
            if(i == floors) {
                printf("L%d%d ", i, j);
            }
            else {
                if(i % 2 != 0) {
                    printf("A%d%d ", i, j);
                }
                else {
                    printf("O%d%d ", i, j);
                }
            }
        }
        printf("\n");
    }

    return 0;
}
