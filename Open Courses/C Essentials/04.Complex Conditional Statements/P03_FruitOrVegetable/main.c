#include <stdio.h>
#include <stdlib.h>
#include <string.h>

int main()
{
    char product[10];
    scanf("%s", product);

    if(strcmp(product, "banana") == 0 || strcmp(product, "apple") == 0 || strcmp(product, "kiwi") == 0 ||
       strcmp(product, "cherry") == 0 || strcmp(product, "lemon") == 0 || strcmp(product, "grapes") == 0) {
       printf("fruit");
    }
    else if(strcmp(product, "tomato") == 0 || strcmp(product, "cucumber") == 0 || strcmp(product, "pepper") == 0 || strcmp(product, "carrot") == 0) {
        printf("vegetable");
    }
    else {
        printf("unknown");
    }

    return 0;
}
