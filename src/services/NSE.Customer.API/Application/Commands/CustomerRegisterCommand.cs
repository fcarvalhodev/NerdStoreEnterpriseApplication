using FluentValidation;
using NSE.Core.Messages;
using System;

namespace NSE.Customer.API.Application.Commands
{
    public class CustomerRegisterCommand : Command
    {

        public CustomerRegisterCommand(Guid id, string name, string email, string cpf)
        {
            this.AggregateId = id;
            this.Id = id;
            this.Name = name;
            this.Email = email;
            this.Cpf = cpf;
        }

        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Cpf { get; private set; }

        public override bool IsValid()
        {
            ValidationResult = new CustomerRegisterValidation().Validate(this);
            return ValidationResult.IsValid;
        }

    }

    public class CustomerRegisterValidation: AbstractValidator<CustomerRegisterCommand>
    {
        public CustomerRegisterValidation()
        {
            RuleFor(me => me.Id)
                .NotEqual(Guid.Empty)
                .WithMessage("Id do cliente inválido");

            RuleFor(me => me.Name)
                .NotEmpty()
                .WithMessage("O nome do cliente não foi informado");


            RuleFor(me => me.Cpf)
                .Must(HasCpfValid)
                .WithMessage("O CPF informado não é válido.");

            RuleFor(me => me.Email)
                .Must(HasEmailValid)
                .WithMessage("O CPF informado não é válido.");

        }

        protected static bool HasCpfValid(string cpf)
        {
            return Core.DomainObjects.Cpf.IsCpf(cpf);
        }

        protected static bool HasEmailValid(string email)
        {
            return Core.DomainObjects.Email.Validar(email);
        }


    }
}
