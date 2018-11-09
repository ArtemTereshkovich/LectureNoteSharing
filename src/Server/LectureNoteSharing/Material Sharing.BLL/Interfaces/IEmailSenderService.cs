using System.Threading.Tasks;
using Material_Sharing.ViewModel.EmailService;

namespace Material_Sharing.BLL.Interfaces
{
    public interface IEmailSenderService
    {
        Task SendEmailConfirmationAsync(EmailConfirmationModel emailConfirmationModel);
        Task SendEmailResetPasswordAsync(EmailResetPasswordModel emailResetPasswordModel);
    }
}