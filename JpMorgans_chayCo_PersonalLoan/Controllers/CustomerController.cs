using JpMorgans_chayCo_PersonalLoanBusinessEntities.Interface;
using JpMorgans_chayCo_PersonalLoanBusinessEntities.ModelDtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JpMorgans_chayCo_PersonalLoan.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        ICustomerRegistrationService _customerRegistrationService;

        public CustomerController(ICustomerRegistrationService customerRegistrationService)
        {
            _customerRegistrationService = customerRegistrationService;
        }

        [HttpGet(Name = "GetCustomer")]
        public async Task<IActionResult> GetCustomer()
        {
            try
            {
                var bookingData = await _customerRegistrationService.GetAllCustomerDetails();
                if (bookingData != null)
                {
                    return StatusCode(StatusCodes.Status200OK, bookingData);
                }
                else
                {
                    return StatusCode(StatusCodes.Status400BadRequest, "Bad input request");
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "System or Server Error");
            }
        }
        [HttpPost]
        [Route("AddCustomerDetails")]
        public async Task<IActionResult> Post([FromBody] CustomerRegistrationDto customerdtoobj)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, ModelState);
                }
                var bookingData = await _customerRegistrationService.AddCustomerDetails(customerdtoobj);
                return StatusCode(StatusCodes.Status201Created, "Booking  Added Succesfully");
            }

            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "System or Server Error");
            }
        }
        [HttpGet]
        [Route("GetCustomerDetailsById/{Id}")]
        public async Task<IActionResult> Get(int Id)
        {
            if (Id < 0)
            {
                return StatusCode(StatusCodes.Status400BadRequest, "Bad input request");
            }
            try
            {
                var bookingData = await _customerRegistrationService.GetCustomerDetailsById(Id);
                if (bookingData == null)
                {
                    return StatusCode(StatusCodes.Status404NotFound, "BookingID Id not found");
                }
                else
                {
                    return StatusCode(StatusCodes.Status200OK, bookingData);
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "System or Server Error");
            }
        }

        [HttpDelete]
        [Route("DeleteCustomerDetilsById/{Id}")]
        public async Task<IActionResult> Delete(int Id)
        {
            if (Id < 0)
            {
                return StatusCode(StatusCodes.Status400BadRequest, "Bad input request");
            }

            try
            {
                var countryData = await _customerRegistrationService.DeleteCustomerDetilsById(Id);
                if (countryData == null)
                {
                    return StatusCode(StatusCodes.Status404NotFound, "Booking Id not found");
                }
                else
                {
                    var Data = await _customerRegistrationService.DeleteCustomerDetilsById(Id);
                    return StatusCode(StatusCodes.Status204NoContent, "booking details deleted successfully");
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "System or Server Error");
            }
        }

        [HttpPut]
        [Route("UpdateBookingDetils")]
        public async Task<IActionResult> PUT([FromBody] CustomerRegistrationDto customerobj)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, ModelState);
                }
                var countryData = await _customerRegistrationService.UpdateCustomerDetils(customerobj);
                return StatusCode(StatusCodes.Status201Created, "booking Details Updated Succesfully");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "System or Server Error");
            }
        }

    }
}
