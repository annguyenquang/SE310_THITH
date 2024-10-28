using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Core.Entities;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class AccountController: ControllerBase
    {
        [HttpPost]
        public async Task<Account> Register(Account account)
        {
            // 1. Validate account data (this can be more comprehensive depending on your requirements)
            if (string.IsNullOrWhiteSpace(account.Username) || string.IsNullOrWhiteSpace(account.Password))
            {
                throw new ArgumentException("Username and password are required.");
            }

            // 2. Hash the password
            account.Password = HashPassword(account.Password); // Use a secure hashing function

            // 3. Check if an account with the same username or email already exists
            var existingAccount = await _dbContext.Accounts
                                                  .FirstOrDefaultAsync(a => a.Username == account.Username);
            if (existingAccount != null)
            {
                throw new InvalidOperationException("An account with this username already exists.");
            }

            // 4. Save the account to the database
            _dbContext.Accounts.Add(account);
            await _dbContext.SaveChangesAsync();

            // 5. Return the newly created account
            return account;
        }

        // Example hash function
        private string HashPassword(string password)
        {
            // Implement your password hashing here (e.g., BCrypt, PBKDF2, etc.)
            return SomeHashingFunction(password);
        }

    }
}
