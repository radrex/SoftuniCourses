#include <iostream>
#include <cmath>

int main()
{
    float a, b, c, discriminant, x1, x2;
    std::cin >> a >> b >> c;

    discriminant = b*b - 4*a*c;
    x1 = 0.0;
    x2 = 0.0;

    if(discriminant < 0) {
        std::cout << "no roots" << std::endl;
    }
    else if(discriminant > 0) {
        x1 = (-b + sqrt(discriminant)) / (2*a);
        x2 = (-b - sqrt(discriminant)) / (2*a);
        std::cout << x1 << ' ' << x2 << std::endl;
    }
    else {
        x1 = (-b + sqrt(discriminant)) / (2*a);
        std::cout << x1 << std::endl;
    }

    return 0;
}
