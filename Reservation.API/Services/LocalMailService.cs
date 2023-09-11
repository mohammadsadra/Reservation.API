using System;
using System.Linq;
using System.Net;
using System.Net.Mail;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Reservation.API.Controllers;

namespace Reservation.API.Services
{
    public class LocalMailService : IMailService
    {
        private readonly string _mailFrom = string.Empty;
        private readonly string _mailFromPassword = string.Empty;
        private readonly string _mailSMTP = string.Empty;
        private readonly int _mailPort = 0;
        private readonly List<string> _mailTo = new List<string>() { };

        private readonly ILogger<SchoolController> _logger;

        public LocalMailService(ILogger<SchoolController> logger, IConfiguration configuration)
        {
            _logger = logger ?? throw new ArgumentException(nameof(logger));
            _mailFrom = configuration["MailService:mailFromAddress"];
            _mailFromPassword = configuration["MailService:mailFromPassword"];
            _mailSMTP = configuration["MailService:mailSMTP"];

            _logger.LogInformation(configuration["MailService:mailsToAddress"]);
#if DEBUG
            _mailPort = Int32.Parse(configuration["MailService:mailNonSSLPort"]);
#else
            _mailPort = Int32.Parse(configuration["MailService:mailSSLPort"]);
#endif
            _mailTo = configuration.GetSection("MailService:mailsToAddress").Get<List<string>>();
                

        }

        public void LogData()
        {
            _logger.LogInformation($"Mail  From {_mailFrom}  To {_mailTo[0]}  , "
                + $"with {nameof(LocalMailService)}  ,  ");
            _logger.LogInformation($"mailSMTP {_mailSMTP}");
            _logger.LogInformation($"mailPort {_mailPort}");
        }



        public void Email(string subject, string htmlString)
        {
            try
            {
                LogData();
                MailMessage message = new MailMessage();
                SmtpClient smtp = new SmtpClient();
                message.From = new MailAddress(_mailFrom);
                for (int i = 0; i < _mailTo.Count; i++)
                {
                    message.To.Add(new MailAddress(_mailTo[i]));
                }
                //message.To.Add(new MailAddress(_mailTo[0]));
                message.Subject = subject;
                message.IsBodyHtml = true; //to make message body as html  
                message.Body = htmlString;
                smtp.Port = _mailPort;
                smtp.Host = _mailSMTP; 
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential(_mailFrom, _mailFromPassword);
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.Send(message);
            }
            catch (Exception)
            {
                _logger.LogInformation("Error while sending message");

            }
        }
    }
}

