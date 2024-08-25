using JpMorgans_chayCo_PersonalLoan.DataBaseLogic;
using JpMorgans_chayCo_PersonalLoanBusinessEntities.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JpMorgans_chayCo_PersonalLoan.RepositoryLayer
{
    public class CustomerRegistrationRepository:ICustomerRegistrationRepository
    {
        public HotelmanagementContext _HotelmanagementConn;

        public CustomerRegistrationRepository(HotelmanagementContext hotelmanagementConn)
        {
            this._HotelmanagementConn = hotelmanagementConn;
        }

        public async Task<bool> AddCustomerDetails(CustomerRegidtation customerDetail)
        {
            await _HotelmanagementConn.CustomerRegidtations.AddAsync(customerDetail);
            _HotelmanagementConn.SaveChanges();
            return true;
        }

        public async Task<bool> DeleteCustomerDetilsById(int Id)
        {
            CustomerRegidtation nb = _HotelmanagementConn.CustomerRegidtations.SingleOrDefault(e => e.Cid == Id);
            if (nb != null)
            {
                _HotelmanagementConn.CustomerRegidtations.Remove(nb);
                _HotelmanagementConn.SaveChanges();
                return true;
            }
            else return false;
        }

        public async Task<List<CustomerRegidtation>> GetAllCustomerDetails()
        {
            var rm = _HotelmanagementConn.CustomerRegidtations.ToList();
            if (rm.Count == 0)
                return null;
            else return rm;
        }

        public async Task<CustomerRegidtation> GetCustomerDetailsById(int Id)
        {
            var rm = await _HotelmanagementConn.CustomerRegidtations.Where(e => e.Cid == Id).FirstOrDefaultAsync();

            if (rm == null)
                return null;
            else
                return rm;
        }

        public async Task<bool> UpdateCustomerDetils(CustomerRegidtation customerDetail)
        {
            _HotelmanagementConn.Update(customerDetail);
            await _HotelmanagementConn.SaveChangesAsync();
            return true;
        }
    }
}
