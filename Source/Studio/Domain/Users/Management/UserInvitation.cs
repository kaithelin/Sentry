/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using Dolittle.Domain;
using Dolittle.Runtime.Events;

namespace Domain.Users.Management
{
    public class UserInvitation : AggregateRoot
    {
        public UserInvitation(EventSourceId id) : base(id)
        { 
            
        }
    }
}
