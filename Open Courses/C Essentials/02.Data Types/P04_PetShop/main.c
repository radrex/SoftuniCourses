#include <stdio.h>
#include <stdlib.h>

int main()
{
    int zoo_dogs, my_dogs;
    scanf("%d %d", &zoo_dogs, &my_dogs);

    double total_cost = zoo_dogs * 2.50 + my_dogs * 4.0;
    printf("%.2f lv.", total_cost);

    return 0;
}
