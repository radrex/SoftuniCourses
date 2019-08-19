#include <stdio.h>
#include <stdlib.h>
#include <string.h>

int main()
{
    char password[60];
    scanf("%s", password);

    if(strcmp(password, "s3cr3t!P@ssw0rd") == 0) {
        printf("Welcome");
    }
    else {
        printf("Wrong password!");
    }

    return 0;
}
