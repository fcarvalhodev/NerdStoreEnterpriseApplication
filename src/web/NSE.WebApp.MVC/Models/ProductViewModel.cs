using System;

namespace NSE.WebApp.MVC.Models
{
    public class ProductViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsActivate { get; set; }
        public decimal Value { get; set; }
        public DateTime DataCreated { get; set; }
        public string Image { get; set; }
        public int QuantityInStock { get; set; }
    }
}
