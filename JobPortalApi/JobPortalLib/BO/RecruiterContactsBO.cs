using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace JobPortalLib.BO
{
    public class RecruiterContactsBO
    {
        public long ContactID { get; set; }
        public Nullable<long> CompanyID { get; set; }
        //[Required(ErrorMessage = "Please Select Title.")]
        public string Title { get; set; }
        //[Required(ErrorMessage = "Please Enter First Name.")]
        public string FirstName { get; set; }
       // [Required(ErrorMessage = "Please Enter Last Name.")]
        public string LastName { get; set; }
        public string Designation { get; set; }        
        public string OfficePh { get; set; }
        public string OfficeExt { get; set; }      
        public string Mobile { get; set; }
        public string ResPh { get; set; }
        public string Fax { get; set; }
        //[Required(ErrorMessage = "Please Enter EmailID.")]
        public string EmailID { get; set; }
        //[Required(ErrorMessage = "Please Select Send Mail.")]
        public Nullable<bool> SendMail { get; set; }
        public string MobileCCode { get; set; }
        public string OfficeCCode { get; set; }
        public string OfficeACode { get; set; }
        public string FaxCCode { get; set; }
        public string FaxACode { get; set; }
     //   [Required(ErrorMessage = "Please Select ContactSequence.")]
        public Nullable<int> ContactSequence { get; set; }
    }
}
 