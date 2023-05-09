using SNET_CaseStudy.DataAccess;
using SNET_CaseStudy.Entities;
using SNET_CaseStudy.Validation;
using System.Diagnostics.Metrics;

namespace SNET_CaseStudy.Business
{
    public class CustomerService : ICustomerService
    {

        //Validation işlemleri aspectler ile de yapılabilir.
        //Mikroservis mimarisinde bir çok proje için validation gerekliyse ayrı servis yazılsa daha iyi olur.

        private readonly ICustomerDal _customerDataAccess;

        public CustomerService(ICustomerDal customerDal)
        {
            _customerDataAccess = customerDal ?? throw new ArgumentNullException(nameof(customerDal));
        }

        public bool Add(CustomerDto customerDto)
        {
            CustomerValidator.ValidateCustomer(customerDto);

            var customer = new Customer { Name = customerDto.Name, 
                Surname = customerDto.Surname, 
                TCKN = long.Parse(customerDto.TCKN), 
                BirthDate = customerDto.BirthDate,
                IsActive = true};

            return _customerDataAccess.Add(customer);
        }

        public bool SetCustomerStatusPassive(string customerTCKN)
        {
            var customer = new Customer
            {
                TCKN = long.Parse(customerTCKN)
            };

            return _customerDataAccess.SetCustomerStatusPassive(customer);
        }

        public List<CustomerDto> GetCustomerListByFilter(CustomerDto customerDto)
        {
            List<CustomerDto> result = new();
            CustomerDto Dto = new();

            var customer = new Customer
            {
                Name = customerDto.Name,
                Surname = customerDto.Surname,
                TCKN = long.Parse(customerDto.TCKN),
                BirthDate = customerDto.BirthDate,
                IsActive = true
            };


            var customers = _customerDataAccess.GetCustomerListByFilter(customer);
            foreach (var item in customers)
            {
                Dto.Name = item.Name.Substring(0, 2).PadRight(Dto.Name.Length, '*');
                Dto.Surname = item.Surname.Substring(0, 2).PadRight(Dto.Surname.Length, '*');
                Dto.TCKN = new string('*', 7) + item.TCKN.ToString().Substring(7);
                Dto.BirthDate = new string('*', 4) + item.BirthDate.Substring(4);
                result.Add(Dto);
            }
            return result;
        }

        public CustomerDto GetCustomer(string customerTCKN)
        {
            var customer = _customerDataAccess.GetCustomer(long.Parse(customerTCKN));

            return new CustomerDto
            {
                Name = customer.Name,
                Surname = customer.Surname,
                TCKN = customerTCKN,
                BirthDate = customer.BirthDate
            };
        }
    }
}
