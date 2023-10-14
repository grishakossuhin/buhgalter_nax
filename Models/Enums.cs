namespace BuhUchetApi.Models
{
    public class Enums
    {
        public enum Roles
        {
            /// <summary>
            /// Бухгалетр
            /// </summary>
            Accountant = 0,
            /// <summary>
            /// Материально ответственное лицо
            /// </summary>
            Financially = 1,
            /// <summary>
            /// Администратор
            /// </summary>
            Admin = 2
        }

        public enum States
        {
            Created = 0,
            Signed = 1,
            Updated = 2
        }

        public enum Groups
        {
            First = 1,
            Second = 2,
            Third = 3,
            Fourth = 4,
            Fiveth = 5,
            Sixth = 6,
            Seventh = 7,
            Eighth = 8,
            Nineth = 9,
            Tenth = 10
        }
    }
}
