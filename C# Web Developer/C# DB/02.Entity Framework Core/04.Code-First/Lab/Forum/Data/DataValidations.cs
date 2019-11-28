namespace Forum.Data
{
    public class DataValidations
    {
        public static class Category
        {
            public const int NameMaxLength = 30;
        }

        public static class User
        {
            public const int UsernameMaxLength = 30;
        }

        public static class Reply
        {
            public const int ContentMaxLength = 5000;
        }

        public static class Post
        {
            public const int TitleMaxLength = 100;
            public const int ContentMaxLength = 5000;
        }

        public static class Tag
        {
            public const int NameMaxLength = 30;
        }
    }
}
