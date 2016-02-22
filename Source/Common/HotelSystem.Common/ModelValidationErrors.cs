namespace HotelSystem.Common
{
    public static class ModelValidationErrors
    {
        public const string InvalidModel = "Invalid model's data!";

        public const string ValidationErrorForLength = "The {0} must no longer than {2} characters.";

        public const string ValidationErrorForRange = "The {0} must be between {2} and {1} characters.";

        public const string EditDeletedEntity = "Cannot edit deleted entity";
    }
}
