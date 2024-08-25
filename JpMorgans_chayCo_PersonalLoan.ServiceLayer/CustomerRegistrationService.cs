using JpMorgans_chayCo_PersonalLoan.DataBaseLogic;
using JpMorgans_chayCo_PersonalLoanBusinessEntities.Interface;
using JpMorgans_chayCo_PersonalLoanBusinessEntities.ModelDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JpMorgans_chayCo_PersonalLoan.ServiceLayer
{
    public class CustomerRegistrationService:ICustomerRegistrationService
    {
        public ICustomerRegistrationRepository _CustomerRegistrationRep;

        public CustomerRegistrationService(ICustomerRegistrationRepository customerRegistrationRep)
        {
            _CustomerRegistrationRep = customerRegistrationRep;
        }

        public async Task<bool> AddCustomerDetails(CustomerRegistrationDto customerDetail)
        {
            CustomerRegidtation obj = new CustomerRegidtation();
            // obj.id = bookingDetail.id; because of identity we cant pass here
            obj.CustomerName = customerDetail.CustomerName;
            obj.FullName = customerDetail.FullName;
            obj.Password = customerDetail.Password;
            obj.Email = customerDetail.Email;


            await _CustomerRegistrationRep.AddCustomerDetails(obj);
            return true;

        }

        public async Task<bool> DeleteCustomerDetilsById(int Id)
        {
            await _CustomerRegistrationRep.DeleteCustomerDetilsById(Id);
            return true;
        }

        public async Task<List<CustomerRegistrationDto>> GetAllCustomerDetails()
        {

            List<CustomerRegistrationDto> objCustomerDto = new List<CustomerRegistrationDto>();
            var result = await _CustomerRegistrationRep.GetAllCustomerDetails();
            foreach (CustomerRegidtation customerobj in result)
            {
                CustomerRegistrationDto obj = new CustomerRegistrationDto();
                obj.Cid = customerobj.Cid;
                obj.CustomerName = customerobj.CustomerName;
                obj.FullName = customerobj.FullName;
                obj.Email = customerobj.Email;
                obj.Password = customerobj.Password;
                objCustomerDto.Add(obj);
            }
            return objCustomerDto;
        }

        public async Task<CustomerRegistrationDto> GetCustomerDetailsById(int Id)
        {
            var bkobj = await _CustomerRegistrationRep.GetCustomerDetailsById(Id);

            CustomerRegistrationDto customerdtoobj = new CustomerRegistrationDto();
            customerdtoobj.Cid = bkobj.Cid;
            customerdtoobj.CustomerName = bkobj.CustomerName;
            customerdtoobj.FullName= bkobj.FullName;
            customerdtoobj.Email = bkobj.Email;
            customerdtoobj.Password = bkobj.Password;

            return customerdtoobj;
        }

        public async Task<bool> UpdateCustomerDetils(CustomerRegistrationDto customerDetail)
        {
            CustomerRegidtation obj = new CustomerRegidtation();
            obj.Cid = customerDetail.Cid;
            obj.CustomerName = customerDetail.CustomerName;
            obj.FullName = customerDetail.FullName;
            obj.Email = customerDetail.Email;
            obj.Password = customerDetail.Password;
          

            await _CustomerRegistrationRep.UpdateCustomerDetils(obj);
            return true;
        }
    }
    }
