using CQRSDesignPattern.Commands;
using CQRSDesignPattern.Db;
using MediatR;

namespace CQRSDesignPattern.Handlers
{
    public class AddProductCommandHandler : IRequestHandler<AddProductCommand, Unit>
    {
        private readonly List<Product> _dbProduct;

        public AddProductCommandHandler(List<Product> dbProduct)
        {
            _dbProduct = dbProduct;
        }

        public Task<Unit> Handle(AddProductCommand command, CancellationToken cancellationToken)
        {
            var product = new Product
            {
                Id = _dbProduct.Count + 1,
                Name = command.Name
            };

            _dbProduct.Add(product);

            return Task.FromResult(Unit.Value);
        }
    }
}
