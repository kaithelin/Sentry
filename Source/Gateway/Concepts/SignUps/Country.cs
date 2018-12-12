/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using Dolittle.Concepts;
using FluentValidation;

namespace Concepts.SignUps
{
    public class Country : ConceptAs<string>
    {
        public static readonly Country NotSet = string.Empty;

        public static implicit operator Country(string country)
        {
            return new Country { Value = country };
        }
    }

    public class CountryInputValidator : AbstractValidator<Country>
    {
        public CountryInputValidator()
        {
            RuleFor(_ => (string)_)
                .NotEmpty().WithMessage("Country name cannot be blank");
        }
    }

    public static class CountryValidatorExtensions
    {
        public static IRuleBuilderOptions<T, Country> MustBeValidCountry<T>(this IRuleBuilder<T, Country> ruleBuilder)
        {
            ruleBuilder.NotNull().WithMessage("Country name is required");
            return ruleBuilder.SetValidator(new CountryInputValidator());
        }
    }

}