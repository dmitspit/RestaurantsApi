using FluentValidation;

namespace Restaurants.Application.Restaurants.Commands.CreateRestaurant
{
    public class CreateRestaurantCommandValidator : AbstractValidator<CreateRestaurantCommand>
    {
        public CreateRestaurantCommandValidator()
        {
            RuleFor(dto => dto.Name).Length(3, 100);
            RuleFor(dto => dto.Description).NotEmpty().WithMessage("Descriptions is required");
            RuleFor(dto => dto.Category).NotEmpty();
            RuleFor(dto => dto.ContactEmail).EmailAddress().WithMessage("Please provide a valid email address");
        }
    }
}
