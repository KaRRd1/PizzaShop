using Application.Dtos;
using Application.Dtos.Order;
using Domain.Interfaces.Repositories;
using FluentValidation;

namespace Application.Validations.Order;

public class CreateOrderRequestValidator : AbstractValidator<CreateOrderRequest>
{
    private readonly IOrderRepository _orderRepository; 
    
    public CreateOrderRequestValidator(IProductRepository productRepository, IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
        
        RuleFor(order => order.Name).NotEmpty().MaximumLength(18);
        RuleFor(user => user.Phone)
            .Matches(@"^\+7 \(\d{3}\) \d{3}-\d{2}-\d{2}$")
            .WithMessage("Incorrect format. Should be '+7 (xxx) xxx-xx-xx'");
        RuleFor(order => order.Email)
            .EmailAddress()
            .MaximumLength(40);
        
        RuleFor(order => order.Street).NotEmpty().MaximumLength(100);
        RuleFor(order => order.House).NotEmpty().MaximumLength(10);
        RuleFor(order => order.Entrance).ExclusiveBetween(0, 1000);
        RuleFor(order => order.Floor).ExclusiveBetween(0, 100);
        RuleFor(order => order.Apartment).ExclusiveBetween(0, 10000);

        RuleFor(order => order.PaymentMethodId).NotEmpty().MustAsync(PaymentMethodIsExist);
        RuleFor(order => order.Comment).MaximumLength(200);

        RuleFor(order => order.ProductVariations).NotEmpty();
        RuleForEach(order => order.ProductVariations)
            .SetValidator(new OrderProductVariationValidator(productRepository));
    }

    private async Task<bool> PaymentMethodIsExist(int id, CancellationToken cancellationToken)
    {
        return await _orderRepository.PaymentMethodIsExist(id, cancellationToken);
    }
}