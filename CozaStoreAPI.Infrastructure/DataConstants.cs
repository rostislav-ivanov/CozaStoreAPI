namespace CozaStoreAPI.Infrastructure
{
    public static class DataConstants
    {
        public static class AppUser
        {
            public const int FirstNameMaxLength = 50;
            public const int LastNameMaxLength = 50;
            public const int EmailMaxLength = 100;
            public const int ShippingCityMaxLength = 50;
            public const int ShippingOfficeMaxLength = 200;
        }

        public static class Image
        {
            public const int ImagePathMaxLength = 2048;
        }

        public static class Review
        {
            public const int TitleMaxLength = 200;
            public const int CommentMaxLength = 1000;
            public const int RatingMinValue = 1;
            public const int RatingMaxValue = 5;
        }
    }
}
