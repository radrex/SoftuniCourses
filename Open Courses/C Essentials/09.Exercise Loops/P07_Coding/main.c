#include <stdio.h>
#include <stdlib.h>
#include <string.h>

int main()
{
    char code[10];
    scanf("%s", code);

    for(int i = strlen(code) - 1; i >= 0; i--) {
        if(code[i] == '0') {
            printf("ZERO\n");
        }
        else {
            int n = code[i] - '0';
            char symbol = n + 33;
            while(n-- > 0) {
                printf("%c", symbol);
            }
            printf("\n");
        }
    }

    return 0;
}
