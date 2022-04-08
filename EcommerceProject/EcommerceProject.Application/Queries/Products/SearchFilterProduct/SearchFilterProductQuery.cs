using EcommerceProject.Domain.AggregatesModel.ProductAggregate;
using EcommerceProject.Domain.SharedKermel;
using EcommerceProject.Infrastructure.CQRS.Command;
using EcommerceProject.Infrastructure.CQRS.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceProject.Application.Queries.Products.SearchFilterProduct
{
    internal class SearchFilterProductQuery : IQuery<IEnumerable<Product>>
    {
        //public string? Name { get; init; }
        //public MoneyValue? Price { get; init; }
        //public string? TradeMark { get; init; }
        //public string? Origin { get; init; }
        //public string? Discription { get; init; }
    }
}
