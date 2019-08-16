#include <stdio.h>
#include <stdlib.h>

int main()
{
    double square_meters;
    scanf("%lf", &square_meters);

    double final_price = square_meters * 7.61;
    double discount = final_price * 0.18;
    final_price -= discount;

    printf("The final price is: %.2f lv.\n", final_price);
    printf("The discount is: %.2f lv.", discount);

    return 0;
}
