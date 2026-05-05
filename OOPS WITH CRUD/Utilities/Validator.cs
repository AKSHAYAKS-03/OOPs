using System.Text.RegularExpressions;

namespace OOPS_WITH_CRUD.Utilities
{
    public static class Validator
    {
        private static readonly Regex EmailRegex = new Regex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", RegexOptions.Compiled);
        private static readonly Regex PhoneRegex = new Regex(@"^(\+91|0)?[6-9][0-9]{9}$", RegexOptions.Compiled);

        public static bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email)) return false;
            return EmailRegex.IsMatch(email);
        }

        public static bool IsValidPhone(string phone)
        {
            if (string.IsNullOrWhiteSpace(phone)) return false;
            return PhoneRegex.IsMatch(phone);
        }

        public static bool IsValidMessage(string message)
        {
            if (string.IsNullOrWhiteSpace(message)) return false;
            return message.Length <= 1000;
        }
    }
}
