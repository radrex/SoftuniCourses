namespace PetStore.Data.Models.DataValidation
{
    public static class DataValidation
    {
        public const int NameMaxLength = 30;

        public static class Category
        {
            public const int DescriptionMaxLength = 1000;
        }

        public static class Pet
        {
            public const int DescriptionMaxLength = 1000;
        }

        public static class User
        {
            public const int EmailMaxLength = 100;
        }
    }
}
