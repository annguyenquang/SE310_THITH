using WebApplication1.Model;

namespace WebApplication1.Core.Entities
{
    public class Account
    {
        public Guid Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public AccountRole Role { get; set; }

    }
}
