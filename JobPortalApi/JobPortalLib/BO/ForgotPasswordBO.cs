using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace JobPortalLib.BO
{
    public class ForgotPasswordBO
    {
        [Required(ErrorMessage = "Please Enter EmailID.")]
        public string EmailID { get; set; }
        public string FromEmailID { get; set; }
        public string Password { get; set; }
    }
}
