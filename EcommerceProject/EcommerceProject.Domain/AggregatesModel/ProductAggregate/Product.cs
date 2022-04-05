using EcommerceProject.Domain.SeedWork;
using EcommerceProject.Domain.SharedKermel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceProject.Domain.AggregatesModel.ProductAggregate
{
    // Aggregate root
    public class Product : AggregateRoot<Guid>
    {
        public string Name { get; }
        public MoneyValue Price { get; }
        public int ProductNumber { get; private set; }
        public string TradeMark { get; }
        public string Origin { get; }
        public string Discription { get; }
        public Product(string name, MoneyValue price, int productNumber, string tradeMark, string origin, string discription)
        {
            this.Id = Guid.NewGuid();
            this.Name = name;
            this.Price = price;
            this.ProductNumber = productNumber;
            this.TradeMark = tradeMark;
            this.Origin = origin;
            this.Discription = discription;
        }
        public void ChangeProductNumber(int productNumber)
        {
            ProductNumber = productNumber;
        }
    }
}
