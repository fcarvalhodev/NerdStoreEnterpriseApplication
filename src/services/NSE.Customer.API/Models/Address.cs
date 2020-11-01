using NSE.Core.DomainObjects;
using System;

namespace NSE.Customer.API.Models
{
    public class Address : Entity
    {
        public Address(string street, string number, string complement, string district, string zipCode, string city, string state)
        {
            this.Street = street;
            this.Number = number;
            this.Complement = complement;
            this.District = district;
            this.ZipCode = zipCode;
            this.City = city;
            this.State = state;            
        }

        public string Street { get; private  set; }
        public string Number { get; private set; }
        public string Complement { get; private set; }
        public string District { get; private set; }
        public string ZipCode { get; private set; }
        public string City { get; private set; }
        public string State { get; private set; }

        //EF RELATIONSHIP 1-1
        public Guid CustomerId { get; private set; }
        public Customer Customer { get; protected set; }

    }
}
