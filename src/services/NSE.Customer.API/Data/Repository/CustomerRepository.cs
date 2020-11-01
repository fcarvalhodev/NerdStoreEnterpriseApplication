using Microsoft.EntityFrameworkCore;
using NSE.Core.Data;
using NSE.Customer.API.Models.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NSE.Customer.API.Data.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly CustomerContext _customerContext;

        public IUnitOfWork UnitOfWork => _customerContext;

        public CustomerRepository(CustomerContext customerContext) 
        {
            _customerContext = customerContext;
        }

        public void Add(Models.Customer customer)
        {
            _customerContext.Add(customer);
        }

        public async Task<IEnumerable<Models.Customer>> GetAll()
        {
            return await _customerContext.Customer.AsNoTracking().ToListAsync();
        }

        public async Task<Models.Customer> GetByCpf(string cpf)
        {
            return await _customerContext.Customer.FirstOrDefaultAsync(me => me.Cpf.Number.Equals(cpf));
        }

        public void Dispose()
        {
            _customerContext.Dispose();
        }
    }
}
