using SandeepThippareddy.Models;
using System.Threading.Tasks;

namespace SandeepThippareddy.Interfaces
{
    public interface IEmailNotificationService
    {
        Task<bool> SendEmailAsync(ContactModel contactModel);

        //Task<bool> SendEmailAsync(string toEmailAddress, string purpose, string verifyUrl);
    }
}
