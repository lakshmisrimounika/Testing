using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace JobPortalLib.BO
{
    public class RecruiterBO
    {
        public long CompanyID { get; set; }
        [Required(ErrorMessage = "Please Enter Company Name.")]
        public string CompanyName { get; set; }
       // [Required(ErrorMessage = "Please Enter LoginID.")]
        public string LoginID { get; set; }
       // [Required(ErrorMessage = "Please Enter Password.")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Please Enter Address1.")]
        public string Address1 { get; set; }
       [Required(ErrorMessage = "Please Enter Address2.")]
        public string Address2 { get; set; }
        [Required(ErrorMessage = "Please Enter City.")]
        public string City { get; set; }
        [Required(ErrorMessage = "Please Select Country.")]
        public string Country { get; set; }
        [Required(ErrorMessage = "Please Enter Website.")]
        public string Website { get; set; }
       // [Required(ErrorMessage = "Please Enter Industry GroupID.")]
        public Nullable<long> IndustryGrpID { get; set; }
        [Required(ErrorMessage = "Please Select Recruiter Industry.")]
        public string Industry { get; set; }
      //  [Required(ErrorMessage = "Please Enter Registration Date.")]
        public Nullable<System.DateTime> RegDate { get; set; }
       // [Required(ErrorMessage = "Please Enter Status.")]
        public Nullable<bool> Status { get; set; }
        public Nullable<long> BDID { get; set; }
        public Nullable<System.DateTime> LastLoginDate { get; set; }
       // [Required(ErrorMessage = "Please Select Recruiter Signed PDF.")]
        public Nullable<bool> RecSignedPDF { get; set; }
        public Nullable<System.DateTime> ApprovedDate { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }
        [Required(ErrorMessage = "Please Enter ZipCode.")]
        public string ZipCode { get; set; }
       // [Required(ErrorMessage = "Please Select Disabled.")]
        public Nullable<bool> Disabled { get; set; }
        public string No_interviewers { get; set; }
        public Nullable<double> TieringDay { get; set; }
        //[Required(ErrorMessage = "Please Select Accept Policies.")]
        public Nullable<bool> AcceptPolicies { get; set; }
        public Nullable<System.DateTime> AcceptedDateTime { get; set; }
        public string InternationalDomestic { get; set; }
        public string OldNewCompany { get; set; }
        public Nullable<int> ZoneID { get; set; }
        public Nullable<bool> DisableMailer { get; set; }
        public string InvoiceStatus { get; set; }
        public string CompYear { get; set; }
        public string CompID { get; set; }
        public Nullable<long> UpdatedBy { get; set; }
        public Nullable<long> ApprovedBy { get; set; }
        public Nullable<long> Coordinator { get; set; }
        public string StatusRemarks { get; set; }
        public Nullable<long> CampusID { get; set; }
        public Nullable<long> CoordinatorID { get; set; }
        public Nullable<System.DateTime> PlacementDate { get; set; }
        public string ToStagingServer { get; set; }
        public string Grade { get; set; }
        //[Required(ErrorMessage = "Please Enter Selection Type.")]
        public Nullable<bool> SelectionType { get; set; }
        public string PAN { get; set; }
        public string TAN { get; set; }
        public string ST { get; set; }
        public string PANDoc { get; set; }
        public string TANDoc { get; set; }
        public string STDoc { get; set; }
        public string SAPID { get; set; }
        public byte[] PANDocument { get; set; }
        public byte[] TANDocument { get; set; }
        public byte[] STDocument { get; set; }
        public string SalesOrderNo { get; set; }
        public string ProformaInvoiceNo { get; set; }
        public string FinalInvoiceNo { get; set; }
        public string InvoiceRaisedStatus { get; set; }
        public string AmountReceived { get; set; }
        public Nullable<System.DateTime> DateOfReceipt { get; set; }
        public Nullable<long> CompanyCategoryID { get; set; }
        public Nullable<long> ProcessCoordinatorID { get; set; }
        public string CompanyFilePath { get; set; }
        public Nullable<long> ExpectedAO { get; set; }
        public Nullable<long> ActualAO { get; set; }
        //[Required(ErrorMessage = "Please Select Tution Waiver.")]
        public Nullable<bool> TutionWaiver { get; set; }
       
        public string Token { get; set; }
    }
}
