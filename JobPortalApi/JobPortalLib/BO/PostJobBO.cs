using System;
using System.Collections.Generic;
using System.Text;

namespace JobPortalLib.BO
{
    public class PostJobBO
    {
        public long JobID { get; set; }
        public Nullable<long> CompanyID { get; set; }
        public string JobTitle { get; set; }
        public Nullable<long> GroupFunctionID { get; set; }
        public string RoleFunction { get; set; }
        public string JobDescription { get; set; }
        public string JobFilePath { get; set; }
        public Nullable<decimal> Salary { get; set; }
        public string Currency { get; set; }
        public Nullable<System.DateTime> PostedDate { get; set; }
        public Nullable<System.DateTime> DeadlineDate { get; set; }
        public string JobStatus { get; set; }
        public Nullable<System.DateTime> ApprovedDate { get; set; }
        public Nullable<long> ApprovedBy { get; set; }
        public string JobPosition { get; set; }
        public Nullable<System.DateTime> DateModified { get; set; }
        public string Location { get; set; }
        public string CountryID { get; set; }
        public string OtherDetails { get; set; }
        public Nullable<bool> Multilocation { get; set; }
        public string InterviewProcess { get; set; }
        public Nullable<System.DateTime> interviewdate { get; set; }
        public string NumPanels { get; set; }
        public string StartTimeHR { get; set; }
        public string StartTimeMin { get; set; }
        public Nullable<decimal> Maxsalary { get; set; }
        public string Salrange { get; set; }
        public Nullable<System.DateTime> JobPostedNewDate { get; set; }
        public Nullable<bool> SendMail { get; set; }
        public Nullable<System.DateTime> ExpectedDateofShortlist { get; set; }
        public Nullable<long> FromYears { get; set; }
        public Nullable<long> ToYears { get; set; }
        public string EOIRequired { get; set; }
        public string EOIName { get; set; }
        public string EOIDesignation { get; set; }
        public Nullable<bool> SeniorJob { get; set; }
        public Nullable<System.DateTime> NewEDateofS { get; set; }
        public string EOITitle { get; set; }
        public string LocationType { get; set; }
        public Nullable<int> CGPA { get; set; }
        public string DeadlineHR { get; set; }
        public string DeadlineMin { get; set; }
        public Nullable<bool> RecShortlisted { get; set; }
        public Nullable<int> BlueTagged { get; set; }
        public Nullable<bool> FinanceJob { get; set; }
        public Nullable<long> CampusID { get; set; }
        public Nullable<bool> ClassScheduleStatus { get; set; }
        public Nullable<double> TieringDay { get; set; }
        public string MailsentStatus { get; set; }
        public string ToStagingServer { get; set; }
        public Nullable<long> DomesticDayWiseCounters { get; set; }
        public string Term { get; set; }
        public string Division { get; set; }
        public string EmailID { get; set; }
        public string Name { get; set; }
        public Nullable<int> MailStatus { get; set; }
        public bool AfterDeadline { get; set; }
        public bool DuringApplication { get; set; }
        public Nullable<System.DateTime> AdditionalDocDeadline { get; set; }
        public Nullable<long> DomesticDayWiseCountersSub { get; set; }
        public Nullable<long> JobCategoryID { get; set; }
        public Nullable<long> OldJobID { get; set; }
    }
}
