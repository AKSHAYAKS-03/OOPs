namespace NotificationApp.Models
{
    public class User
    {
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Phone { get; private set; }

        public User(string name, string email, string phone)
        {
            Name = name?.Trim() ?? string.Empty;
            Email = email?.Trim() ?? string.Empty;
            Phone = phone?.Trim() ?? string.Empty;
        }

        // Null-Coalescing Operator = ??
        public void UpdateEmail(string email)
        {
            Email = email?.Trim() ?? string.Empty;
        }

        public void UpdatePhone(string phone)
        {
            Phone = phone?.Trim() ?? string.Empty;
        }
    }
}