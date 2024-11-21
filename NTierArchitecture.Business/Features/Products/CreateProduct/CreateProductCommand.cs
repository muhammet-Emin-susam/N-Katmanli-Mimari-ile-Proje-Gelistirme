using MediatR;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTierArchitecture.Business.Features.Products.CreateProduct
{
    public sealed record CreateProductCommand(
        string Name,
        decimal Price,
        int Quantity,
        Guid CategoryID) : IRequest<Unit>;

}
