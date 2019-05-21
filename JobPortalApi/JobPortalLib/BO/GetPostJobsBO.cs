using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace JobPortalLib.BO
{
    public class GetPostJobsBO
    {
        [Required(ErrorMessage = "Please Enter CompanyID.")]
        public long CompanyID { get; set; }
    }
}
