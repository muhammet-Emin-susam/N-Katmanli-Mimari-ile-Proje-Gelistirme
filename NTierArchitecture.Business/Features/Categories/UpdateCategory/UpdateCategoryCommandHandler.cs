using MediatR;
using NTierArchitecture.Entities.Models;
using NTierArchitecture.Entities.Repositories;

namespace NTierArchitecture.Business.Features.Categories.UpdateCategory
{
    internal sealed class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateCategoryCommandHandler(ICategoryRepository categoryRepository, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _categoryRepository = categoryRepository;
        }


        public async Task Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            Category category = await _categoryRepository.GetByIdAsync(p => p.ID == request.ID, cancellationToken);
            if (category is null)
            {
                throw new ArgumentException("Kategori Bulunamadı");
            }
            if (category.Name != request.Name)
            {
                var isCategoryNameExist = await _categoryRepository.AnyAsync(p => p.Name == request.Name, cancellationToken);

                if (isCategoryNameExist)
                {
                    throw new ArgumentException("Bu kategori daha önce oluşturulmuş");
                }
                category.Name = request.Name;
                await _unitOfWork.SaveChangesAsync(cancellationToken);
            }
        }
    }
}

