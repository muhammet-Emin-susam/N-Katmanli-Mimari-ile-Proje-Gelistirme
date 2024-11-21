using MediatR;
using NTierArchitecture.Entities.Models;
using NTierArchitecture.Entities.Repositories;

namespace NTierArchitecture.Business.Features.Products.CreateProduct
{
    internal sealed class CreateProductCommandHandler : IRequestHandler<CreateProductCommand>
    {
        private readonly IProductRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateProductCommandHandler(IProductRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            bool isProductNameExist = await _repository.AnyAsync(p => p.Name == request.Name, cancellationToken);
            if (isProductNameExist)
            {
                throw new ArgumentException("Bu ürün daha önce tanımlanmış");
            }
            Product product = new()
            {
                Name = request.Name,
                Price = request.Price,
                Quantity = request.Quantity,
                CategoryID = request.CategoryID
            };
             await _repository.AddAsync(product,cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }

}
