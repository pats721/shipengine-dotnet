using System;

using FluentValidation;

namespace ShipEngine
{

    sealed public class ShipEngineConfigValidator : AbstractValidator<ShipEngineConfig>
    {
        public static readonly Uri DefaultBaseUri = new Uri("https://api.shipengine.com");

        public static readonly int DefaultPageSize = 10;
        public static readonly int MaxPageSize = 100;
        public static readonly int MinPageSize = 1;


        public ShipEngineConfigValidator()
        {
            RuleFor(c => c.ApiKey).NotEmpty();
            RuleFor(c => c.BaseUri).NotEmpty();
            RuleFor(c => c.PageSize).Cascade(CascadeMode.Stop).LessThanOrEqualTo(MaxPageSize).GreaterThanOrEqualTo(MinPageSize);
            RuleFor(c => c.UserAgent).NotEmpty();
        }
    }
}