#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <math.h>

int main()
{
    char year[10];
    scanf("%s", year);
    int holidays, travels;
    scanf("%d %d", &holidays, &travels);
    double games = ((48 - travels) * 0.75) + travels + (holidays * (2.0 / 3.0));

    if(strcmp(year, "leap") == 0) {
        games *= 1.15;
    }

    printf("%.0f", floor(games));

    return 0;
}
