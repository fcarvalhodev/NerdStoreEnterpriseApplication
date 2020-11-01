using NSE.Core.DomainObjects;
using System;

namespace NSE.Customer.API.Models
{
    public class Customer : Entity, IAggregateRoot
    {
        public Customer(Guid id, string name, string email, string cpf)
        {
            this.Id = id;
            this.Name = name;
            this.Email = new Email(email);
            this.Cpf = new Cpf(cpf);
            this.Excluded = false;
        }

        //EF RELATIONSHIP
        protected Customer()
        {

        }

        public string Name { get; private set; }
        public Email Email { get; private set; }
        public Cpf Cpf { get; private set; }
        public bool Excluded { get; private set; }
        public Address Address { get; private set; }

        public void ChangeEmail(string email)
        {
            this.Email = new Email(email);
        }

        public void SetAddress(Address address)
        {
            this.Address = address;
        }

    }
}
