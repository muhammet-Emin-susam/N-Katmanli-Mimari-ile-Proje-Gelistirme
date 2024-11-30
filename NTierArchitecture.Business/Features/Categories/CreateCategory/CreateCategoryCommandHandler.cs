using AutoMapper;
using ErrorOr;
using MediatR;
using NTierArchitecture.Entities.Models;
using NTierArchitecture.Entities.Repositories;

namespace NTierArchitecture.Business.Features.Categories.CreateCategory
{
    internal sealed class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, ErrorOr<Unit>>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateCategoryCommandHandler(IUnitOfWork unitOfWork, ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ErrorOr<Unit>> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var isCategoryNameExist = await _categoryRepository.AnyAsync(p => p.Name == request.Name, cancellationToken);
            if (isCategoryNameExist)
            {
                return Error.Conflict("NameIsExists","Bu kategori daha önce oluşturulmuştur.");
            }
            Category category = _mapper.Map<Category>(request);
            await _categoryRepository.AddAsync(category, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);  
            return Unit.Value;
        }
    }
}
