/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using Dolittle.Concepts;

namespace Concepts.SignedUp
{
    public class Email : ConceptAs<string>
    {
        public static readonly Email NotSet = string.Empty;

        public static implicit operator Email(string email)
        {
            return new Email { Value = email.ToLower().Trim() };
        }
    }

    //public static class ValidatorExtensions
    //{
    //    public static IRuleBuilderOptions<T, Email> MustBeAValidEmail<T>(this IRuleBuilder<T, Email> ruleBuilder)
    //    {
    //        ruleBuilder.NotNull().WithMessage("Invalid email format");
    //        return ruleBuilder.SetValidator(new EmailValidator());
    //    }
    //}
}