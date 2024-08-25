using JpMorgans_chayCo_PersonalLoan.DataBaseLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JpMorgans_chayCo_PersonalLoanBusinessEntities.Interface
{
    public interface ICustomerRegistrationRepository
    {
        Task<List<CustomerRegidtation>> GetAllCustomerDetails();
        Task<CustomerRegidtation> GetCustomerDetailsById(int Id);
        Task<bool> AddCustomerDetails(CustomerRegidtation customerDetail);
        Task<bool> UpdateCustomerDetils(CustomerRegidtation customerDetail);
        Task<bool> DeleteCustomerDetilsById(int Id);


    }
}
