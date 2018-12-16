/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using System;
using Dolittle.Concepts;
using FluentValidation;

namespace Concepts.SignUps
{
    public class CountryId : ConceptAs<Guid>
    {
        public static readonly CountryId Empty = Guid.Empty;
        public static implicit operator CountryId(Guid value)
        {
            return new CountryId { Value = value };
        }

        public static implicit operator CountryId(string value)
        {
            return new CountryId { Value = Guid.Parse(value) };
        }
    }
    public class CountryIdInputValidator : AbstractValidator<CountryId>
    {
        public CountryIdInputValidator()
        {
            RuleFor(_ => (Guid)_)
                .NotEmpty().WithMessage("CountryId cannot be blank");
        }
    }

    public static class CountryIdValidatorExtensions
    {
        public static IRuleBuilderOptions<T, CountryId> MustBeValidCountryId<T>(this IRuleBuilder<T, CountryId> ruleBuilder)
        {
            ruleBuilder.NotNull().WithMessage("CountryId is required");
            return ruleBuilder.SetValidator(new CountryIdInputValidator());
        }
    }
}