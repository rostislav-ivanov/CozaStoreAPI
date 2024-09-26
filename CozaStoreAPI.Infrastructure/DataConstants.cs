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

        public static class Message
        {
            public const int FirstNameMaxLength = 50;
            public const int LastNameMaxLength = 50;
            public const int EmailMaxLength = 100;
            public const int SubjectMaxLength = 200;
            public const int ContentMaxLength = 1000;
        }

        public static class City
        {
            public const int NameMaxLength = 100;
        }

        public static class Office
        {
            public const int NameMaxLength = 300;
        }

        public static class Order
        {
            public const int TrackingNumberMaxLength = 30;
            public const string TrackingNumberPattern = @"^[A-Za-z0-9]{5,}$";
            public const int FirstNameMaxLength = 100;
            public const int LastNameMaxLength = 100;
            public const int PhoneNumberMaxLength = 50;
        }

        public static class StatusOrder
        {
            public const int NameMinLength = 1;
            public const int NameMaxLength = 100;
        }
    }
}
