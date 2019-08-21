#include <stdio.h>
#include <stdlib.h>
#include <math.h>

int main()
{
    int hour, minute, arrival_hour, arrival_minute;
    scanf("%d %d %d %d", &hour, &minute, &arrival_hour, &arrival_minute);

    int exam_time = (hour * 60) + minute;
    int arrival_time = (arrival_hour * 60) + arrival_minute;
    int diff = exam_time - arrival_time;

    if(diff > 30) {
        printf("Early\n");
        if(diff > 59) {
            int hours = diff / 60;
            int mins = diff % 60;
            printf("%d:%02d hours before the start", hours, mins);
        }
        else {
            printf("%d minutes before the start", diff);
        }
    }
    else if(diff < 0) {
        printf("Late\n");
        int minsLate = abs(diff);
        if(minsLate > 59) {
            int hours = minsLate / 60;
            int minutes = minsLate % 60;
            printf("%d:%02d hours after the start", hours, minutes);
        }
        else {
            printf("%d minutes after the start", minsLate);
        }
    }
    else {
        printf("On time\n");
        if(diff > 0) {
            printf("%d minutes before the start", diff);
        }
    }

    return 0;
}
