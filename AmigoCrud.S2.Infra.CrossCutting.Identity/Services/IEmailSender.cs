using System.Threading.Tasks;

namespace AmigoCrud.S2.Infra.CrossCutting.Identity.Services
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string message);
    }
}
