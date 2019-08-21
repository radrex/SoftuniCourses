#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <stdbool.h>

int main()
{
    int days;
    char room_type[30], evaluation[30];
    scanf("%d %[^\n] %[^\n]", &days, room_type, evaluation);

    double price = 0.0;

    bool less_than_10_days = days < 9;
    bool between_10_and_15 = days >= 9 && days <= 14;
    bool more_than_15 = days > 14;
    days--;

    if(strcmp(room_type, "room for one person") == 0) {
        price = days * 18.00;
    }
    else if(strcmp(room_type, "apartment") == 0) {
        if(less_than_10_days) {
            price = (days * 25.00) * 0.70;
        }
        else if(between_10_and_15) {
            price = (days * 25.00) * 0.65;
        }
        else if(more_than_15) {
            price = (days * 25.00) * 0.50;
        }
    }
    else if(strcmp(room_type, "president apartment") == 0) {
        if(less_than_10_days) {
            price = (days * 35.00) * 0.80;
        }
        else if(between_10_and_15) {
            price = (days * 35.00) * 0.85;
        }
        else if(more_than_15) {
            price = (days * 35.00) * 0.80;
        }
    }

    if(strcmp(evaluation, "positive") == 0) {
        price *= 1.25;
    }
    else if(strcmp(evaluation, "negative") == 0) {
        price *= 0.90;
    }

    printf("%.2f", price);

    return 0;
}
