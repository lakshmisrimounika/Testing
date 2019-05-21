using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace JobPortalLib.BO
{
    public class LoginBO
    {
        public long CompanyID { get; set; }

        public string Name { get; set; }
        [Required(ErrorMessage = "Please Enter LoginID.")]
        public string LoginID { get; set; }
        [Required(ErrorMessage = "Please Enter Password.")]
        public string Password { get; set; }
        public string Token { get; set; }
    }
}
