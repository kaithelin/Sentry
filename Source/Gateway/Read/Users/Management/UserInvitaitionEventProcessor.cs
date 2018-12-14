using Dolittle.Events.Processing;
using Events.Users.Managment;

namespace Read.Users.Management
{
    public class UserInvitaitionEventProcessor : ICanProcessEvents
    {
        
        [EventProcessor("68364fa5-d26c-9652-f426-4658a3279f23")]
        public void Process(UserAcceptedInvitation @event)
        { 
            
        }
        
        [EventProcessor("45bfd3f7-4c27-82f8-2a8b-51700c206d95")]
        public void Process(UserDeniedInvitaition @event)
        { 
            
        }        
    }
}