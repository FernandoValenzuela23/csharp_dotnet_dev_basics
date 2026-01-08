using CQRSDesignPattern.Commands;
using CQRSDesignPattern.Queries;
using MediatR;
namespace CQRSDesignPattern
{
    public class Demo
    {
        private readonly IMediator _mediator;

        public Demo(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task Run()
        {
            await _mediator.Send(new AddProductCommand { Name = "Product 1" });
            await _mediator.Send(new AddProductCommand { Name = "Product 2" });

            var products = await _mediator.Send(new GetAllProductsQuery());
            Console.WriteLine("Products in the database:");
            foreach (var product in products)
            {
                Console.WriteLine($"\t{product.Name}");
            }

        }
    }
}
