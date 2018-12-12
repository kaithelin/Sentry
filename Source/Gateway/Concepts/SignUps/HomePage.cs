/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using Dolittle.Concepts;
using FluentValidation;

namespace Concepts.SignUps
{
    public class HomePage : ConceptAs<string>
    {
        public static readonly HomePage NotSet = string.Empty;

        public static implicit operator HomePage(string homepage)
        {
            return new HomePage { Value = homepage.ToLower().Trim() };
        }
    }

    public class HomePageInputValidator : AbstractValidator<HomePage>
    {
        public HomePageInputValidator()
        {
            RuleFor(_ => (string)_)
                .NotEmpty().WithMessage("HomePage cannot be blank");
        }
    }

    public static class HomePageValidatorExtensions
    {
        public static IRuleBuilderOptions<T, HomePage> MustBeValidHomePage<T>(this IRuleBuilder<T, HomePage> ruleBuilder)
        {
            ruleBuilder.NotNull().WithMessage("HomePage is required");
            return ruleBuilder.SetValidator(new HomePageInputValidator());
        }
    }
}