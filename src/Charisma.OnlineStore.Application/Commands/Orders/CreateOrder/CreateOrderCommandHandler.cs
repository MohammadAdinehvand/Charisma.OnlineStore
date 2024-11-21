using Charisma.OnlineStore.Domain.DomainServices;
using Charisma.OnlineStore.Domain.Factories;
using Charisma.OnlineStore.Domain.Models.OrderAggregate;
using Charisma.OnlineStore.Domain.Models.ProductAggregate;
using Charisma.OnlineStore.Domain.Repositories;
using Charisma.OnlineStore.Domain.ValueObjects;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Charisma.OnlineStore.Application.Commands.Orders.CreateOrder
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IOrderFactory _orderFactory;
        private readonly IPricingService _pricingService;
        private readonly IProductRepository _productRepository;

        public CreateOrderCommandHandler(IOrderRepository orderRepository, IOrderFactory orderFactory, IPricingService pricingService, IProductRepository productRepository)
        {
            _orderRepository = orderRepository;
            _orderFactory = orderFactory;
            _pricingService = pricingService;
            _productRepository = productRepository;
        }


        public async Task Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            Address address = new Address(request.Street, request.City, request.State, request.Country,request.ZipCode);
            IEnumerable<Product> products = await _productRepository.GetByIdAsync(request.OrderItems.Select(x => x.ProductId).ToList());

            List<OrderItem> orderItems = new List<OrderItem>();
            foreach (var item in products)
            {
                var unit = request.OrderItems.FirstOrDefault(x => x.ProductId == item.Id).Units;
                orderItems.Add(new OrderItem(item.Id, item.Name, item.UnitPrice, unit));
            }
            var order = await _orderFactory.CreateAsync(DateTime.Now, request.BuyerId, address, orderItems);
            _pricingService.AddProfitMarginToOrder(order, 100);

            await _orderRepository.AddAsync(order);

        }
    }
}
