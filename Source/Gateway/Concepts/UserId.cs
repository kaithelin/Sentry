/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System;
using Dolittle.Concepts;
using FluentValidation;

namespace Concepts
{
    public class UserId : ConceptAs<Guid>
    {
        public static readonly UserId Empty = Guid.Empty;
        public static implicit operator UserId(Guid value)
        {
            return new UserId { Value = value };
        }

        public static implicit operator UserId(string value)
        {
            return new UserId { Value = Guid.Parse(value) };
        }
    }
    public class UserIdInputValidator : AbstractValidator<UserId>
    {
        public UserIdInputValidator()
        {
            RuleFor(_ => (Guid)_)
                .NotEmpty().WithMessage("UserId cannot be blank");
        }
    }

    public static class UserIdValidatorExtensions
    {
        public static IRuleBuilderOptions<T, UserId> MustBeValidUserId<T>(this IRuleBuilder<T, UserId> ruleBuilder)
        {
            ruleBuilder.NotNull().WithMessage("UserId is required");
            return ruleBuilder.SetValidator(new UserIdInputValidator());
        }
    }
}