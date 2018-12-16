/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using Dolittle.Concepts;
using FluentValidation;

namespace Concepts.SignUps
{
    public class CountryName : ConceptAs<string>
    {
        public static readonly CountryName NotSet = string.Empty;

        public static implicit operator CountryName(string country)
        {
            return new CountryName { Value = country };
        }
    }

    public class CountryNameInputValidator : AbstractValidator<CountryName>
    {
        public CountryNameInputValidator()
        {
            RuleFor(_ => (string)_)
                .NotEmpty().WithMessage("Country name cannot be blank");
        }
    }

    public static class CountryNameValidatorExtensions
    {
        public static IRuleBuilderOptions<T, CountryName> MustBeValidCountryName<T>(this IRuleBuilder<T, CountryName> ruleBuilder)
        {
            ruleBuilder.NotNull().WithMessage("Country name is required");
            return ruleBuilder.SetValidator(new CountryNameInputValidator());
        }
    }
}