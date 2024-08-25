using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JpMorgans_chayCo_PersonalLoanBusinessEntities.ModelDtos
{
    public class CustomerRegistrationDto
    {
        public int Cid { get; set; }

        public string? CustomerName { get; set; }

        public string? FullName { get; set; }

        public string? Email { get; set; }

        public string? Password { get; set; }

       

    }
}
