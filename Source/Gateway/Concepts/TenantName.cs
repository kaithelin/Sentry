/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using Dolittle.Concepts;
using Concepts.SignUps;
using FluentValidation;

namespace Concepts
{
    public class TenantName : ConceptAs<string>
    {
        public static readonly TenantName NotSet = string.Empty;

        public static implicit operator TenantName(string tenantName)
        {
            return new TenantName { Value = tenantName };
        }
    }
    public class TenantNameInputValidator : AbstractValidator<TenantName>
    {
        public TenantNameInputValidator()
        {
            RuleFor(_ => (string)_)
                .NotEmpty().WithMessage("TenantName cannot be blank");
        }
    }

    public static class TenantNameValidatorExtensions
    {
        public static IRuleBuilderOptions<T, TenantName> MustBeValidTenantName<T>(this IRuleBuilder<T, TenantName> ruleBuilder)
        {
            ruleBuilder.NotNull().WithMessage("TenantName is required");
            return ruleBuilder.SetValidator(new TenantNameInputValidator());
        }
    }
}
