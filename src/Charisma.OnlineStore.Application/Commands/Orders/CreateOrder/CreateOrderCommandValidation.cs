using FluentValidation;


namespace Charisma.OnlineStore.Application.Commands.Orders.CreateOrder
{
    public class CreateOrderCommandValidation : AbstractValidator<CreateOrderCommand>
    {
        public class OrderItemValidator : AbstractValidator<CreateOrderCommand.OrderItem>
        {
            public OrderItemValidator()
            {

                RuleFor(orderItem => orderItem.ProductId)
                    .GreaterThan(0).WithMessage("ProductId must be greater than zero.");


                RuleFor(orderItem => orderItem.Units)
                    .GreaterThan(0).WithMessage("Units must be greater than zero.");
            }
        }
        public CreateOrderCommandValidation()
        {
    
            RuleFor(command => command.BuyerId)
                .GreaterThan(0).WithMessage("BuyerId must be greater than zero.");

 
            RuleFor(command => command.Street)
                .NotEmpty().WithMessage("Street is required.")
                .MaximumLength(100).WithMessage("Street must not exceed 100 characters.");


            RuleFor(command => command.City)
                .NotEmpty().WithMessage("City is required.")
                .MaximumLength(50).WithMessage("City must not exceed 50 characters.");

            RuleFor(command => command.State)
                .NotEmpty().WithMessage("State is required.")
                .MaximumLength(50).WithMessage("State must not exceed 50 characters.");

            RuleFor(command => command.Country)
                .NotEmpty().WithMessage("Country is required.")
                .MaximumLength(50).WithMessage("Country must not exceed 50 characters.");

            RuleFor(command => command.ZipCode)
                .NotEmpty().WithMessage("ZipCode is required.")
                .Matches(@"^\d{5}(-\d{4})?$").WithMessage("ZipCode must be a valid format.");


            RuleFor(command => command.OrderItems)
                    .NotEmpty().WithMessage("OrderItems must contain at least one item.")
                    .Must(items => items.Select(i => i.ProductId).Distinct().Count() == items.Count)
                    .WithMessage("OrderItems must not contain duplicate ProductIds.")
                    .ForEach(item =>
                    {
                        item.SetValidator(new OrderItemValidator());
                    });
        }
    }
}
