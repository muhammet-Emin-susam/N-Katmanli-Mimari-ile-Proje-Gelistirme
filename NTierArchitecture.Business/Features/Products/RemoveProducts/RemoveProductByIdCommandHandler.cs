using MediatR;
using NTierArchitecture.Entities.Models;
using NTierArchitecture.Entities.Repositories;

namespace NTierArchitecture.Business.Features.Products.RemoveProducts
{
    internal sealed class RemoveProductByIdCommandHandler : IRequestHandler<RemoveProductByIdCommand>
    {
        private readonly IProductRepository _productRepository;
        private readonly IUnitOfWork _unitOfWork;

        public RemoveProductByIdCommandHandler(IProductRepository productRepository, IUnitOfWork unitOfWork)
        {
            _productRepository = productRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(RemoveProductByIdCommand request, CancellationToken cancellationToken)
        {
            Product product = await _productRepository.GetByIdAsync(p => p.ID == request.ID, cancellationToken);
            if (product is null)
            {
                throw new ArgumentException("Ürün bulunamadı");
            }
            _productRepository.Remove(product);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
