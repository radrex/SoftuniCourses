#include <stdio.h>
#include <stdlib.h>
#include <string.h>

int main()
{
    char text[50];
    gets(text);
    int sum = 0;

    for(int i = 0; i < strlen(text); i++) {
        switch(text[i]) {
        case 'a':
            sum += 1;
            break;

        case 'e':
            sum += 2;
            break;

        case 'i':
            sum += 3;
            break;

        case 'o':
            sum += 4;
            break;

        case 'u':
            sum += 5;
            break;
        }
    }

    printf("%d", sum);

    return 0;
}
