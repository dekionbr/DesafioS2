using System.Threading.Tasks;

namespace AmigoCrud.S2.Infra.CrossCutting.Identity.Services
{
    public interface ISmsSender
    {
        Task SendSmsAsync(string number, string message);
    }
}
