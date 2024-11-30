using AutoMapper;
using ErrorOr;
using MediatR;
using NTierArchitecture.Entities.Models;
using NTierArchitecture.Entities.Repositories;

namespace NTierArchitecture.Business.Features.Categories.UpdateCategory
{
    internal sealed class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, ErrorOr<Unit>>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public UpdateCategoryCommandHandler(ICategoryRepository categoryRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }


        public async Task<ErrorOr<Unit>> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            Category category = await _categoryRepository.GetByIdAsync(p => p.ID == request.ID, cancellationToken);
            if (category is null)
            {
                return Error.Conflict("Kategori Bulunamadı");
            }
            if (category.Name != request.Name)
            {
                var isCategoryNameExist = await _categoryRepository.AnyAsync(p => p.Name == request.Name, cancellationToken);

                if (isCategoryNameExist)
                {
                    return Error.Conflict("Bu kategori daha önce oluşturulmuş");
                }
                _mapper.Map(request, category);
                await _unitOfWork.SaveChangesAsync(cancellationToken);
            }
            return Unit.Value;
        }
    }
}

