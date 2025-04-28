using Automat_Paramedic.Repository;
using MailKit.Security;
using MimeKit;
using SmtpClient = MailKit.Net.Smtp.SmtpClient;

namespace Automat_Paramedic.Service
{
    public class EmailService
    {

        public ApplicationContextFactory _contextFactory { get; }
        public EmailService(ApplicationContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
        }


        public async Task<bool> SendResetPasswordEmailAsync(string email)
        {
            try
            {
                using var _application = _contextFactory.CreateDbContext();
               var user  = _application.Users.FirstOrDefault(x=>x.Email == email);
                if (user == null) throw new Exception("User not found");

                var resetToken = new Random().Next(1000, 9999).ToString("D4"); 
                                                                                   
                var result =
                    user.password  = resetToken.ToString();
                _application.Update(user);
                _application.SaveChangesAsync();
               return await SendResetPasswordEmailAsync(email, resetToken);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in SendResetPasswordEmailAsync: {ex.Message}");
                throw; 
            }
        }
        public async Task<bool> SendResetPasswordEmailAsync(string email, string resetToken)
        {
            var subject = "Password Reset Request";
            var body = $"Your password reset,new code is: {resetToken}";
           return await SendEmailAsync(email, subject, body);
        }
        private async Task<bool> SendEmailAsync(string recipientEmail, string subject, string body)
        {
            var message = new MimeMessage();
            var smtpServer = "smtp.gmail.com";
            var smtpPort = 587;
            var smtpEmail = "timyewlasow@gmail.com";
            var smtpPassword = "ohpqbczbijhibsqa";
            message.From.Add(new MailboxAddress("AutomatParamedic", smtpEmail));
            message.To.Add(new MailboxAddress("", recipientEmail));
            message.Subject = subject;
            message.Body = new TextPart("plain") { Text = body };

            using var client = new SmtpClient();
            try
            {
                await client.ConnectAsync(smtpServer, smtpPort, SecureSocketOptions.StartTls);
                await client.AuthenticateAsync(smtpEmail, smtpPassword);
                await client.SendAsync(message);
                await client.DisconnectAsync(true);
                return true;
            }
            catch (Exception ex)
            {
                return false;
                throw new Exception($"Error sending email: {ex.Message}", ex);
            }
        }
    }
}
