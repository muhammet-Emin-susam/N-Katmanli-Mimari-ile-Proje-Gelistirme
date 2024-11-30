using ErrorOr;
using MediatR;
using NTierArchitecture.Entities.Models;
using NTierArchitecture.Entities.Repositories;

namespace NTierArchitecture.Business.Features.Categories.RemoveCategory
{
    internal sealed class RemoveCategoryByIdCommandHandler : IRequestHandler<RemoveCategoryByIdCommand,ErrorOr<Unit>>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IUnitOfWork _unitOfWork;

        public RemoveCategoryByIdCommandHandler(ICategoryRepository categoryRepository, IUnitOfWork unitOfWork)
        {
            _categoryRepository = categoryRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<ErrorOr<Unit>> Handle(RemoveCategoryByIdCommand request, CancellationToken cancellationToken)
        {
            Category category = await _categoryRepository.GetByIdAsync(p => p.ID == request.ID, cancellationToken);
            if (category is null)
            {
                return Error.Conflict("Kategori bulunamadı!");
            }
            _categoryRepository.Remove(category);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
