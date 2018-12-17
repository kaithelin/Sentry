/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using Dolittle.Concepts;
using FluentValidation;

namespace Concepts.Users.Management
{
    public class Email : ConceptAs<string>
    {
        public static readonly Email NotSet = string.Empty;

        public static implicit operator Email(string email)
        {
            return new Email { Value = email.ToLower().Trim() };
        }
    }

    public class EmailInputValidator : AbstractValidator<Email>
    {
        public EmailInputValidator()
        {
            RuleFor(_ => (string)_)
                .NotEmpty().WithMessage("Email cannot be blank")
                .EmailAddress().WithMessage("Invalid email address");
        }
    }

    public static class EmailValidatorExtensions
    {
        public static IRuleBuilderOptions<T, Email> MustBeValidEmail<T>(this IRuleBuilder<T, Email> ruleBuilder)
        {
            ruleBuilder.NotNull().WithMessage("Email is required");
            return ruleBuilder.SetValidator(new EmailInputValidator());
        }
    }
}