using CQRSDesignPattern.Db;
using CQRSDesignPattern.Queries;
using MediatR;

namespace CQRSDesignPattern.Handlers
{
    public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery,List<Product>>
    {
        private readonly List<Product> _dbProduct;

        public GetAllProductsQueryHandler(List<Product> dbProduct)
        {
            _dbProduct = dbProduct;
        }

        public Task<List<Product>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            // Return the list of products from the in-memory database
            return Task.FromResult(_dbProduct);
        }

    }
}
