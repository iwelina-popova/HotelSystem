namespace HotelSystem.Common
{
    public static class ModelConstraints
    {
        public const int NameMinLength = 2;

        public const int NameMaxLength = 30;

        public const int PasswordMinLength = 6;

        public const int DescriptionMinLength = 50;

        public const int DescriptionMaxLength = 2000;

        public const int EmailMaxLength = 100;

        public const int ContactInfoMaxLength = 20;

        public const int FacebookMaxLength = 100;

        public const int HotelMinStars = 1;

        public const int HotelMaxStars = 5;

        public const int LocationMaxLength = 100;

        public const int RoomMinCapacity = 1;

        public const int RoomMaxCapacity = 10;
    }
}
