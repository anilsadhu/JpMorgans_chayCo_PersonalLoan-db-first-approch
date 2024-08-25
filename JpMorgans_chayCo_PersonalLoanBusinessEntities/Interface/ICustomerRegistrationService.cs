using JpMorgans_chayCo_PersonalLoanBusinessEntities.ModelDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JpMorgans_chayCo_PersonalLoanBusinessEntities.Interface
{
    public interface ICustomerRegistrationService
    {
        Task<List<CustomerRegistrationDto>> GetAllCustomerDetails();
        Task<CustomerRegistrationDto> GetCustomerDetailsById(int Id);
        Task<bool> AddCustomerDetails(CustomerRegistrationDto customerDetail);
        Task<bool> UpdateCustomerDetils(CustomerRegistrationDto customerDetail);
        Task<bool> DeleteCustomerDetilsById(int Id);
    }
}
