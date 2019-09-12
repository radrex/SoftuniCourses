#include <stdio.h>
#include <stdlib.h>
#include <string.h>

int main()
{
    char desired_book[50];
    scanf("%[^\n]", desired_book);

    int n;
    scanf("%d", &n);

    for(int i = 0; i < n; i++) {
        while ((getchar()) != '\n');    // FLUSH the BUFFER
        char book[50];
        scanf("%[^\n]", book);

        if(strcmp(book, desired_book) == 0) {
           printf("You checked %d books and found it.\n", i);
           return 0;
        }
    }

    printf("The book you search is not here!\n");
    printf("You checked %d books.", n);

    return 0;
}
