using NSE.Core.DomainObjects;
using System;

namespace NSE.Catalog.API.Models
{
    public class Product : Entity, IAggregateRoot
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsActivate { get; set; }
        public decimal Value { get; set; }
        public DateTime DataCreated { get; set; }
        public string Image { get; set; }
        public int QuantityInStock { get; set; }
    }
}
