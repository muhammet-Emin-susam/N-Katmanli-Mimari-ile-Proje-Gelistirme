using AutoMapper;
using MediatR;
using NTierArchitecture.Entities.Models;
using NTierArchitecture.Entities.Repositories;

namespace NTierArchitecture.Business.Features.Products.UpdateProducts
{
    internal sealed class UpdateProductsCommandHandler : IRequestHandler<UpdateProductsCommand,Unit>
    {
        private readonly IProductRepository _productRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public UpdateProductsCommandHandler(IProductRepository productRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _productRepository = productRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateProductsCommand request, CancellationToken cancellationToken)
        {
            Product product = await _productRepository.GetByIdAsync(p => p.ID == request.ID, cancellationToken);
            if (product is null)
            {
                throw new ArgumentException("Ürün bulunamadı.");
            }
            if (product.Name != request.Name)
            {
                bool isProductNameIsExists = await _productRepository.AnyAsync(p => p.Name == request.Name, cancellationToken);
                if (isProductNameIsExists)
                {
                    throw new ArgumentException("Bu ürün adı daha önce kullanılmış!");
                }
            }
            _mapper.Map(request,product);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
