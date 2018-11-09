using System.Threading.Tasks;
using Material_Sharing.BLL.Interfaces;
using System.Linq;
using System.Text.Encodings.Web;
using Material_Sharing.ViewModel.EmailService;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace Material_Sharing.BLL.Services
{
    public class AuthMessageSenderOptions
    {
        public string SendGridUser { get; set; }
        public string SendGridKey { get; set; }
    }
    public class EmailSenderService : IEmailSenderService
    {
        public EmailSenderService(IOptions<AuthMessageSenderOptions> optionsAccessor)
        {
            Options = optionsAccessor.Value;
        }
        private AuthMessageSenderOptions Options { get; }
        private Task Execute(string apiKey, string subject, string message, string email)
        {
            var client = new SendGridClient(apiKey);
            var msg = new SendGridMessage()
            {
                From = new EmailAddress("auth@materialsharing.com", "Material sharing"),
                Subject = subject,
                PlainTextContent = message,
                HtmlContent = message
            };
            msg.AddTo(new EmailAddress(email));
            return client.SendEmailAsync(msg);
        }

        private Task SendEmailAsync(SendEmailModel sendEmailModel)
        {
            return Execute(Options.SendGridKey,sendEmailModel.Subject,
                sendEmailModel.Message,sendEmailModel.Email);
        }

        public Task SendEmailConfirmationAsync(EmailConfirmationModel emailConfirmationModel)
        {
            var sendEmailModel = new SendEmailModel
            {
                Email = emailConfirmationModel.Email,
                Subject = "Confirm your email",
                Message = $"Please confirm your account by clicking this link: <a href='{HtmlEncoder.Default.Encode(emailConfirmationModel.Link)}'>link</a>"
            };
            return SendEmailAsync(sendEmailModel);
        }

        public Task SendEmailResetPasswordAsync(EmailResetPasswordModel emailResetPasswordModel)
        {
            var sendEmailModel = new SendEmailModel
            {
                Email = emailResetPasswordModel.Email,
                Subject = "Reset Password",
                Message = $"Please reset your password by clicking here: <a href='{emailResetPasswordModel.Link}'>link</a>"
            };
            return SendEmailAsync(sendEmailModel);
        }
    }
}