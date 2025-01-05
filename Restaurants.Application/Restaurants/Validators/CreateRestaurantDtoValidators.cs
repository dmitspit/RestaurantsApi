using FluentValidation;

using Restaurants.Application.Restaurants.Dtos.RestaurantDtos;

namespace Restaurants.Application.Restaurants.Validators
{
    public class CreateRestaurantDtoValidators : AbstractValidator<CreateRestaurantDto>
    {
        public CreateRestaurantDtoValidators()
        {
            RuleFor(dto => dto.Name).Length(3, 100);
            RuleFor(dto => dto.Description).NotEmpty().WithMessage("Descriptions is required");
            RuleFor(dto => dto.Category).NotEmpty();
            RuleFor(dto => dto.ContactEmail).EmailAddress().WithMessage("Please provide a valid email address");
        }
    }
}
