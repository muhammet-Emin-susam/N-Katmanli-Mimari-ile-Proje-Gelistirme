using MediatR;
using NTierArchitecture.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTierArchitecture.Business.Features.Categories.GetCategories
{
    public sealed record GetCategoriesQuery(): IRequest<List<Category>>;
}
