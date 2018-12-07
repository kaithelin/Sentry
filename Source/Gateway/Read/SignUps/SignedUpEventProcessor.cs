using System;
using System.Net.Mail;
using System.Text;
using Dolittle.Events.Processing;
using Events.SignUps;

namespace Read.SignUps
{
    public class SignedUpEventProcessor : ICanProcessEvents
    {
        private readonly EmailProvider _emailProvider;
        public SignedUpEventProcessor()
        {
            _emailProvider = new EmailProvider();
        }

        [EventProcessor("763bd310-fdd4-a150-8811-ad35ca9263ea")]
        public void Process(AskedToJoinTenant @event)
        {
            _emailProvider.SendEmail(@event.TenantOwnerEmail, "Asked to join tenant", "Asked to join tenant");
        }

        [EventProcessor("0837f72d-dd68-6385-f901-900e3b3a537b")]
        public void Process(TenantSignedUp @event)
        {
            _emailProvider.SendEmail(@event.OwnerEmail, "Verify account", "Verify");
        }
    }

    public class EmailProvider
    {
        // @todo: app secret
        private const int Port = 000;
        private const string Host = "smtp.dolittleProvider.com";
        private const bool EnableSsl = true;
        private const int Timeout = 1000;
        private const string UserName = "dolittle@provider.com";
        private const string Password = "dolittlePassword";

        private readonly string _from = "donotreply@dolittle.com";

        public EmailProvider()
        {
        }

        public void SendEmail(string email, string subject, string body)
        {
            try
            {
                using (var client = new SmtpClient
                {
                    Port = Port,
                    Host = Host,
                    EnableSsl = EnableSsl,
                    Timeout = Timeout,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new System.Net.NetworkCredential(UserName, Password)
                })
                { 
                    var mm =
                        new MailMessage(_from, email, subject, body)
                        {
                            BodyEncoding = Encoding.UTF8,
                            DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure
                        };

                client.Send(mm);
                }
            }
            catch (SmtpException ex)
            {
                Console.WriteLine(ex.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
