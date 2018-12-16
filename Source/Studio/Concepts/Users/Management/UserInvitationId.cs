/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using System;
using Dolittle.Concepts;
using FluentValidation;

namespace Concepts.Users.Management
{
    public class UserInvitationId : ConceptAs<Guid>
    {
        public static readonly UserInvitationId Empty = Guid.Empty;
        public static implicit operator UserInvitationId(Guid value)
        {
            return new UserInvitationId { Value = value };
        }

        public static implicit operator UserInvitationId(string value)
        {
            return new UserInvitationId { Value = Guid.Parse(value) };
        }
    }
    public class UserInvitationIdInputValidator : AbstractValidator<UserInvitationId>
    {
        public UserInvitationIdInputValidator()
        {
            RuleFor(_ => (Guid)_)
                .NotEmpty().WithMessage("UserInvitationId cannot be blank");
        }
    }

    public static class UserIdValidatorExtensions
    {
        public static IRuleBuilderOptions<T, UserInvitationId> MustBeValidUserInvitationId<T>(this IRuleBuilder<T, UserInvitationId> ruleBuilder)
        {
            ruleBuilder.NotNull().WithMessage("UserInvitationId is required");
            return ruleBuilder.SetValidator(new UserInvitationIdInputValidator());
        }
    }
}