using MediatR;
using Microsoft.AspNetCore.Mvc;
using NTierArchitecture.Business.Features.Categories.CreateCategory;
using NTierArchitecture.Business.Features.Categories.GetCategories;
using NTierArchitecture.Business.Features.Categories.RemoveCategory;
using NTierArchitecture.Business.Features.Categories.UpdateCategory;
using NTierArchitecture.Business.Features.Products.CreateProduct;
using NTierArchitecture.Business.Features.Products.GetProducts;
using NTierArchitecture.Business.Features.Products.RemoveProducts;
using NTierArchitecture.Business.Features.Products.UpdateProducts;
using NTierArchitecture.DataAccess.Authorization;
using NTierArchitecture.WebApi.Abstractions;

namespace NTierArchitecture.WebApi.Controllers
{
    public sealed class CategoriesController : ApiController
    {
        public CategoriesController(IMediator mediator) : base(mediator)
        {

        }
        [HttpPost]
        [RoleFilter("Category.Add")]
        public async Task<IActionResult> Add(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
           var response =  await _mediator.Send(request, cancellationToken);

            if (response.IsError)
            {
                return BadRequest(response.FirstError);
            }
            return NoContent();
        }
        [HttpPost]
        [RoleFilter("Category.Update")]
        public async Task<IActionResult> Update(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            if (response.IsError)
            {
                return BadRequest(response.FirstError);
            }
            return NoContent();
        }
        [HttpPost]
        [RoleFilter("Category.Remove")]
        public async Task<IActionResult> RemoveByID(RemoveCategoryByIdCommand request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            if (response.IsError)
            {
                return BadRequest(response.FirstError);
            }
            return NoContent();
        }
        [HttpPost]
        [RoleFilter("Category.GetAll")]
        public async Task<IActionResult> GetAll(GetCategoriesQuery request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);

            return Ok(response);
        }
    }
}
