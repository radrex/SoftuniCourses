#include <stdio.h>
#include <stdlib.h>
#include <math.h>

int main()
{
    int a, b;
    scanf("%d", &a);
    scanf("%d", &b);

    int hyp_squared = a * a + b * b;
    printf("Hypotenuse is %d.", (int)sqrt(hyp_squared));

    return 0;
}
