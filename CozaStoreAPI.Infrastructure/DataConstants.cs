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

        public static class Product
        {
            public const int NameMaxLength = 100;
            public const int DescriptionMaxLength = 2000;
            public const int MaterialMaxLength = 200;
        }

        public static class Image
        {
            public const int ImagePathMaxLength = 300;
        }

        public static class Size
        {
            public const int NameMaxLength = 100;
        }

        public static class Color
        {
            public const int NameMaxLength = 100;
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
            public const int PhoneNumberMaxLength = 20;
        }

        public static class StatusOrder
        {
            public const int NameMinLength = 1;
            public const int NameMaxLength = 100;
        }

        public const string EmailPattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";

        public const string PhonePattern = @"^\+?[0-9\s]*$";

        public static class ErrorMessageConstants
        {
            public const string RequiredField = "The {0} field is required.";
            public const string StringLengthMax = "The {0} must be at most {1} characters long.";
            public const string EmptyList = "The {0} list cannot be empty.";
            public const string LeastOneEntity = "At least one entity must be provided.";
            public const string NegativOrZeroNumber = "The {0} must be a positive number.";
            public const string NegativeDecimalVolue = "The {0} must be a positive number.";
            public const string InvalidEmailAddress = "Invalid email address";
            public const string InvalidPhoneNumber = "Invalid phone number. Only digits and '+' are allowed.";
        }
    }
}
