namespace P04_PasswordValidator
{
    using System;

    class P04_PasswordValidator
    {
        static void Main(string[] args)
        {
            string password = Console.ReadLine();
            ValidatePassword(password);
        }

        public static void ValidatePassword(string password)
        {
            bool isPasswordLengthValid = ValidatePasswordLength(password);
            bool isPasswordCompositionValid = ValidatePasswordComposition(password);
            bool isPasswordDigitsCountValid = ValidatePasswordDigitCount(password);

            if (isPasswordLengthValid && isPasswordCompositionValid && isPasswordDigitsCountValid)
            {
                Console.WriteLine("Password is valid");
            }
            else
            {
                if (!isPasswordLengthValid)
                {
                    Console.WriteLine("Password must be between 6 and 10 characters");
                }

                if (!isPasswordCompositionValid)
                {
                    Console.WriteLine("Password must consist only of letters and digits");
                }

                if (!isPasswordDigitsCountValid)
                {
                    Console.WriteLine("Password must have at least 2 digits");
                }
            }
        }

        public static bool ValidatePasswordLength(string password)
        {
            return (password.Length >= 6 && password.Length <= 10);
        }

        public static bool ValidatePasswordComposition(string password)
        {

            foreach (char digit in password)
            {
                if (!(digit >= 48 && digit <= 57) && !(digit >= 65 && digit <= 90) && !(digit >= 97 && digit <= 122))
                {
                    return false;
                }
            }

            return true;
        }

        public static bool ValidatePasswordDigitCount(string password)
        {
            int digitCount = 0;
            foreach (char digit in password)
            {
                if (digit >= 48 && digit <= 57)
                {
                    digitCount++;
                }
            }

            return digitCount < 2 ? false : true;
        }
    }
}