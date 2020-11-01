using FluentValidation.Results;
using MediatR;
using Microsoft.AspNetCore.Razor.TagHelpers;
using NSE.Core.Messages;
using NSE.Customer.API.Models.Repository;
using System.Threading;
using System.Threading.Tasks;

namespace NSE.Customer.API.Application.Commands
{
    public class CustomerCommandHandler : CommandHandler,
        IRequestHandler<CustomerRegisterCommand, ValidationResult>
    {
        private readonly ICustomerRepository _customerRepository;
        public CustomerCommandHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<ValidationResult> Handle(CustomerRegisterCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid())
                return message.ValidationResult;

            var customer = new Models.Customer(message.Id, message.Name, message.Email, message.Cpf);

            var customerExists = await _customerRepository.GetByCpf(customer.Cpf.Number);

            if (customerExists != null)
            {
                //TODO - Globalization
                AddError("Este CPF já está em uso.");
                return ValidationResult;
            }

            _customerRepository.Add(customer);

            return await PersistData(_customerRepository.UnitOfWork);
        }
    }
}
