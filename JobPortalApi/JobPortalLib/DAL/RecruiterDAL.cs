using JobPortalLib.BO;
using JobPortalLib.DAL.Interfaces;
using Microsoft.ApplicationBlocks.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace JobPortalLib.DAL
{
    public class RecruiterDAL : IRecruiterDAL
    {
        public  string connectionString = string.Empty;
        IConfiguration _configuration;
        public RecruiterDAL(IConfiguration configuration)
        {
            _configuration = configuration;
            connectionString = _configuration.GetSection("ConnectionStrings").GetSection("DefaultConnection").Value; ;
        }
        //SqlConnection sqlConnection = new SqlConnection("data source=.;user id=sa;password=Techwave@123;database=Placements2018");
        //string value = _configuration.GetSection("ConnectionStrings").GetSection("DefaultConnection").Value;
        SqlConnection sqlConnection = null;// new SqlConnection(connectionString);

        RecruiterBO recruiterMaster = new RecruiterBO();
        int rowsAffected = 0;

        // Inserting Recruiter Master details in database
        public async Task<int> AddRecruiter(RecruiterBO recruiterMaster, string Type)
        {
            string _Error = string.Empty;
            int contractID = 0;
            try
            {
                using (sqlConnection=new SqlConnection(connectionString))
                {
                    sqlConnection.Open();
                    // Inserting Recruiter details in database                                
                    SqlCommand cmd = new SqlCommand("Insert_Update_Fetch_companies", sqlConnection);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CompanyName", recruiterMaster.CompanyName);
                    cmd.Parameters.AddWithValue("@LoginID", recruiterMaster.LoginID);
                    cmd.Parameters.AddWithValue("@Password", recruiterMaster.Password);
                    cmd.Parameters.AddWithValue("@Address1", recruiterMaster.Address1);
                    cmd.Parameters.AddWithValue("@Address2", recruiterMaster.Address2);
                    cmd.Parameters.AddWithValue("@City", recruiterMaster.City);
                    cmd.Parameters.AddWithValue("@Country", recruiterMaster.Country);
                    cmd.Parameters.AddWithValue("@Website", recruiterMaster.Website);
                    cmd.Parameters.AddWithValue("@IndustryGrpID", recruiterMaster.IndustryGrpID);
                    cmd.Parameters.AddWithValue("@Industry", recruiterMaster.Industry);
                    cmd.Parameters.AddWithValue("@RegDate", recruiterMaster.RegDate);
                    cmd.Parameters.AddWithValue("@Status", recruiterMaster.Status);
                    cmd.Parameters.AddWithValue("@RecSignedPDF", recruiterMaster.RecSignedPDF);
                    cmd.Parameters.AddWithValue("@Zipcode", recruiterMaster.ZipCode);
                    cmd.Parameters.AddWithValue("@Disabled", recruiterMaster.Disabled);
                    cmd.Parameters.AddWithValue("@SAPID", recruiterMaster.SAPID);
                    cmd.Parameters.AddWithValue("@PAN", recruiterMaster.PAN);
                    cmd.Parameters.AddWithValue("@TAN", recruiterMaster.TAN);
                    cmd.Parameters.AddWithValue("@ST", recruiterMaster.ST);
                    cmd.Parameters.AddWithValue("@PANDoc", recruiterMaster.PANDoc);
                    cmd.Parameters.AddWithValue("@TANDoc", recruiterMaster.TANDoc);
                    cmd.Parameters.AddWithValue("@STDoc", recruiterMaster.STDoc);
                    cmd.Parameters.AddWithValue("@Type", Type);
                    cmd.Parameters.Add("@CompanyID", SqlDbType.Int).Direction = ParameterDirection.Output;
                    rowsAffected = await cmd.ExecuteNonQueryAsync();
                    contractID = Convert.ToInt32(cmd.Parameters["@CompanyID"].Value);
                    sqlConnection.Close();
                }
                return contractID;
            }
            catch (Exception ex)
            {
                _Error = ex.ToString();
                return 0;
            }
        }
        // Inserting Recruiter Contact details in database
        public async Task<int> AddRecruiterContact(List<RecruiterContactsBO> recruiterContacts, string Type)
        {
            string _Error = string.Empty;
            try
            {
                using (sqlConnection=new SqlConnection(connectionString))
                {
                    if (recruiterContacts != null && recruiterContacts.Count > 0)
                    {
                        for (int i = 0; i < recruiterContacts.Count; i++)
                        {
                            sqlConnection.Open();
                            // Inserting Recruiter Contact details in database                                
                            SqlCommand cmd = new SqlCommand("Insert_Update_Fetch_CompanyContact", sqlConnection);
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@CompanyID", recruiterContacts[i].CompanyID);
                            cmd.Parameters.AddWithValue("@Title", recruiterContacts[i].Title);
                            cmd.Parameters.AddWithValue("@FirstName", recruiterContacts[i].FirstName);
                            cmd.Parameters.AddWithValue("@LastName", recruiterContacts[i].LastName);
                            cmd.Parameters.AddWithValue("@Designation", recruiterContacts[i].Designation);
                            cmd.Parameters.AddWithValue("@OfficePh", recruiterContacts[i].OfficePh);
                            cmd.Parameters.AddWithValue("@OfficeExt", recruiterContacts[i].OfficeExt);
                            cmd.Parameters.AddWithValue("@Mobile", recruiterContacts[i].Mobile);
                            cmd.Parameters.AddWithValue("@ResPh", recruiterContacts[i].ResPh);
                            cmd.Parameters.AddWithValue("@Fax", recruiterContacts[i].Fax);
                            cmd.Parameters.AddWithValue("@EmailID", recruiterContacts[i].EmailID);
                            cmd.Parameters.AddWithValue("@SendMail", recruiterContacts[i].SendMail);
                            cmd.Parameters.AddWithValue("@MobileCCode", recruiterContacts[i].MobileCCode);
                            cmd.Parameters.AddWithValue("@OfficeCCode", recruiterContacts[i].OfficeCCode);
                            cmd.Parameters.AddWithValue("@OfficeACode", recruiterContacts[i].OfficeACode);
                            cmd.Parameters.AddWithValue("@FaxCCode", recruiterContacts[i].FaxCCode);
                            cmd.Parameters.AddWithValue("@FaxACode", recruiterContacts[i].FaxACode);
                            cmd.Parameters.AddWithValue("@Type", Type);
                            cmd.Parameters.AddWithValue("@ContactID", 0);
                            rowsAffected = await cmd.ExecuteNonQueryAsync();
                            sqlConnection.Close();
                        }
                    }
                }
                return rowsAffected;

            }
            catch (Exception ex)
            {
                _Error = ex.ToString();
                return 0;
            }
        }
        //Recruiter Login
        public async Task<int> RecruiterLogin(LoginBO recruiterLogin, string Type)
        {
            string _Error = string.Empty;
            int ID = 0;
            try
            {
                using (sqlConnection = new SqlConnection(connectionString))
                {
                    sqlConnection.Open();
                    // Inserting Recruiter Login details in database                                
                    SqlCommand cmd = new SqlCommand("CheckLogin", sqlConnection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@LoginID", recruiterLogin.LoginID);
                    cmd.Parameters.AddWithValue("@Password", recruiterLogin.Password);
                    cmd.Parameters.AddWithValue("@Type", Type);
                    cmd.Parameters.Add("@ID", SqlDbType.Int).Direction = ParameterDirection.Output;
                    rowsAffected = await cmd.ExecuteNonQueryAsync();
                    ID = Convert.ToInt32(cmd.Parameters["@ID"].Value);
                    sqlConnection.Close();
                }
                return ID;

            }
            catch (Exception ex)
            {
                _Error = ex.ToString();
                return ID;
            }
        }
        //Getting Dashboard Data
        public async Task<DataTable> FetchBDWiseReport(DashboardBO dashboardBO)
        {
            string _Error = string.Empty;
            DataTable dt = new DataTable();
            try
            {
                using (sqlConnection = new SqlConnection(connectionString))
                {
                    sqlConnection.Open();
                    // Inserting Fetch in database                    
                    SqlCommand cmd = new SqlCommand("FetchBDWiseReport", sqlConnection);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Type", dashboardBO.Type);
                    cmd.Parameters.AddWithValue("@Zoneid", dashboardBO.Zoneid);
                    cmd.Parameters.AddWithValue("@bdid", dashboardBO.Bdid);
                    cmd.Parameters.AddWithValue("@AdminCategory", dashboardBO.AdminCategory);
                    cmd.Parameters.AddWithValue("@AdminID", dashboardBO.AdminID);
                    rowsAffected = await cmd.ExecuteNonQueryAsync();
                    sqlConnection.Close();
                    da.Fill(dt);
                }
                return dt;

            }
            catch (Exception ex)
            {
                _Error = ex.ToString();
                return dt;
            }
        }
        // Inserting Recruiter Master details in database
        public async Task<int> PostJob(PostJobBO postJobBO, string Type)
        {
            string _Error = string.Empty;
            int JobID = 0;
            try
            {
                using (sqlConnection = new SqlConnection(connectionString))
                {
                    sqlConnection.Open();
                    // Inserting Job Master details in database                                
                    SqlCommand cmd = new SqlCommand("Insert_Update_Fetch_Job", sqlConnection);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CompanyID", postJobBO.CompanyID);
                    cmd.Parameters.AddWithValue("@JobTitle", postJobBO.JobTitle);
                    cmd.Parameters.AddWithValue("@GroupFunctionID", postJobBO.GroupFunctionID);
                    cmd.Parameters.AddWithValue("@RoleFunction", postJobBO.RoleFunction);
                    cmd.Parameters.AddWithValue("@JobDescription", postJobBO.JobDescription);
                    cmd.Parameters.AddWithValue("@JobFilePath", postJobBO.JobFilePath);
                    cmd.Parameters.AddWithValue("@Currency", postJobBO.Currency);
                    cmd.Parameters.AddWithValue("@PostedDate", postJobBO.PostedDate);
                    cmd.Parameters.AddWithValue("@JobStatus", postJobBO.JobStatus);
                    cmd.Parameters.AddWithValue("@Location", postJobBO.Location);
                    cmd.Parameters.AddWithValue("@CountryID", postJobBO.CountryID);
                    cmd.Parameters.AddWithValue("@DeadlineDate", postJobBO.DeadlineDate);
                    cmd.Parameters.AddWithValue("@MultiLoc", postJobBO.Multilocation);
                    cmd.Parameters.AddWithValue("@JobPosition", postJobBO.JobPosition);
                    cmd.Parameters.AddWithValue("@ApprovedDate", postJobBO.ApprovedDate);
                    cmd.Parameters.AddWithValue("@ApprovedBy", postJobBO.ApprovedBy);
                    cmd.Parameters.AddWithValue("@InterviewProcess", postJobBO.InterviewProcess);
                    cmd.Parameters.AddWithValue("@NumPanels", postJobBO.NumPanels);
                    cmd.Parameters.AddWithValue("@StartTimeMin", postJobBO.StartTimeMin);
                    cmd.Parameters.AddWithValue("@StartTimeHR", postJobBO.StartTimeHR);
                    cmd.Parameters.AddWithValue("@Type", Type);
                    cmd.Parameters.AddWithValue("@Salrange", postJobBO.Salrange);
                    cmd.Parameters.AddWithValue("@JobPostedNewDate", postJobBO.JobPostedNewDate);
                    cmd.Parameters.AddWithValue("@ExpectedDateofShortlist", postJobBO.ExpectedDateofShortlist);
                    cmd.Parameters.AddWithValue("@FromYears", postJobBO.FromYears);
                    cmd.Parameters.AddWithValue("@ToYears", postJobBO.ToYears);
                    cmd.Parameters.AddWithValue("@EOIRequired", postJobBO.EOIRequired);
                    cmd.Parameters.AddWithValue("@EOIName", postJobBO.EOIName);
                    cmd.Parameters.AddWithValue("@EOIDesignation", postJobBO.EOIDesignation);
                    cmd.Parameters.AddWithValue("@EOITitle", postJobBO.EOITitle);
                    cmd.Parameters.AddWithValue("@DomesticDayWiseCounters", postJobBO.DomesticDayWiseCounters);
                    cmd.Parameters.AddWithValue("@Term", postJobBO.Term);
                    cmd.Parameters.AddWithValue("@Division", postJobBO.Division);
                    cmd.Parameters.AddWithValue("@EmailID", postJobBO.EmailID);
                    cmd.Parameters.AddWithValue("@Name", postJobBO.Name);
                    cmd.Parameters.AddWithValue("@JobCategoryID", postJobBO.JobCategoryID);
                    cmd.Parameters.AddWithValue("@DomesticDayWiseCountersSub", postJobBO.DomesticDayWiseCountersSub);
                    cmd.Parameters.AddWithValue("@OldJobID", postJobBO.OldJobID);
                    cmd.Parameters.AddWithValue("@CGPA", postJobBO.CGPA);
                    cmd.Parameters.AddWithValue("@FinanceJob", postJobBO.FinanceJob);
                    cmd.Parameters.AddWithValue("@CampusID", postJobBO.CampusID);
                    cmd.Parameters.AddWithValue("@TieringDay", postJobBO.TieringDay);
                    cmd.Parameters.AddWithValue("@AdditionalDeadline", postJobBO.AdditionalDocDeadline);
                    cmd.Parameters.AddWithValue("@LocationType", postJobBO.LocationType);
                    cmd.Parameters.Add("@JobID", SqlDbType.Int).Direction = ParameterDirection.Output;
                    rowsAffected = await cmd.ExecuteNonQueryAsync();
                    JobID = Convert.ToInt32(cmd.Parameters["@JobID"].Value);
                    sqlConnection.Close();
                }
                return JobID;
            }
            catch (Exception ex)
            {
                _Error = ex.ToString();
                return 0;
            }
        }
        //Getting Post Jobs Data
        public async Task<DataTable> GetPostJobsData(GetPostJobsBO getPostJobsBO, string Type)
        {
            string _Error = string.Empty;
            DataTable dt = new DataTable();
            try
            {
                using (sqlConnection = new SqlConnection(connectionString))
                {
                    sqlConnection.Open();
                    // Inserting Fetch in database                    
                    SqlCommand cmd = new SqlCommand("Insert_Update_Fetch_Job", sqlConnection);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CompanyID", getPostJobsBO.CompanyID);
                    cmd.Parameters.AddWithValue("@Type", Type);
                    rowsAffected = await cmd.ExecuteNonQueryAsync();
                    sqlConnection.Close();
                    da.Fill(dt);
                }
                return dt;

            }
            catch (Exception ex)
            {
                _Error = ex.ToString();
                return dt;
            }
        }
        //Check EmailID 

        public DataSet CheckEMailID(ForgotPasswordBO forgotPasswordBO, string Type)
        {
            string _Error = string.Empty;
            DataSet ds = new DataSet();
            try
            {
                using (sqlConnection = new SqlConnection(connectionString))
                {
                    sqlConnection.Open();
                    // Inserting Fetch in database                    
                    SqlCommand cmd = new SqlCommand("CheckEMailID", sqlConnection);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@EMailID", forgotPasswordBO.EmailID);
                    cmd.Parameters.AddWithValue("@Type", Type);
                    cmd.ExecuteNonQueryAsync();
                    sqlConnection.Close();
                    da.Fill(ds);
                }
                return ds;

            }
            catch (Exception ex)
            {
                _Error = ex.ToString();
                return ds;
            }
        }
        //Inserted in MailLog
        public string AddMailToDB(string _SendTo, string _From, string _Subject, string _Body, string _CC, string _BCC, string _AttachedPath)
        {
            string result = string.Empty;
            try
            {
                using (sqlConnection = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("Insert_AddMailToDB", sqlConnection);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@FromMailID", _From);
                    cmd.Parameters.AddWithValue("@ToMailID", _SendTo);
                    cmd.Parameters.AddWithValue("@CCMailID", _CC);
                    cmd.Parameters.AddWithValue("@BCCMailID", _BCC);
                    cmd.Parameters.AddWithValue("@MailSubject", _Subject);
                    cmd.Parameters.AddWithValue("@MailBody", _Body);
                    cmd.Parameters.AddWithValue("@Status", "N");
                    cmd.Parameters.AddWithValue("@EnteredDate", System.DateTime.UtcNow.AddHours(5.5));
                    cmd.Parameters.AddWithValue("@Type", "I");
                    cmd.Parameters.AddWithValue("@Attachedpath", _AttachedPath);
                    cmd.ExecuteNonQueryAsync();
                    sqlConnection.Close();
                }
                return result;
            }
            catch (Exception)
            {
                throw;
            }

        }
        //Manage Recruiters
        public DataSet FetchAllCompaniesbyStatus(string Status)
        {
            string _Error = string.Empty;
            DataSet ds = new DataSet();
            try
            {
                using (sqlConnection = new SqlConnection(connectionString))
                {
                    sqlConnection.Open();
                    // Inserting Fetch in database                    
                    SqlCommand cmd = new SqlCommand("GetAllCompaniesByStatus", sqlConnection);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Status", Status);
                    cmd.ExecuteNonQueryAsync();
                    sqlConnection.Close();
                    da.Fill(ds);
                }
                return ds;

            }
            catch (Exception ex)
            {
                _Error = ex.ToString();
                return ds;
            }
        }

        //Fetch Company Contacts
        public DataSet FetchAllContacts(int CompanyID, string Status)
        {
            string _Error = string.Empty;
            DataSet ds = new DataSet();
            try
            {
                using (sqlConnection = new SqlConnection(connectionString))
                {
                    sqlConnection.Open();
                    SqlCommand cmd = new SqlCommand("Insert_Update_Fetch_CompanyContact", sqlConnection);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CompanyID", CompanyID);
                    cmd.Parameters.AddWithValue("@Type", Status);
                    cmd.ExecuteNonQueryAsync();
                    sqlConnection.Close();
                    da.Fill(ds);
                }
                return ds;

            }
            catch (Exception ex)
            {
                _Error = ex.ToString();
                return ds;
            }
        }
        //Fetch Company Details
        public DataSet FetchCompany(int CompanyID, string Status)
        {
            string _Error = string.Empty;
            DataSet ds = new DataSet();
            try
            {
                using (sqlConnection = new SqlConnection(connectionString))
                {
                    sqlConnection.Open();
                    SqlCommand cmd = new SqlCommand("Insert_Update_Fetch_companies", sqlConnection);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CompanyID", CompanyID);
                    cmd.Parameters.AddWithValue("@Type", Status);
                    cmd.ExecuteNonQueryAsync();
                    sqlConnection.Close();
                    da.Fill(ds);
                }
                return ds;

            }
            catch (Exception ex)
            {
                _Error = ex.ToString();
                return ds;
            }
        }

		//Fetch Email Configuration
		public DataSet GetEmailConfig()
		{
			string _Error = string.Empty;
			DataSet ds = new DataSet();
			try
			{
				using (sqlConnection = new SqlConnection(connectionString))
				{
					sqlConnection.Open();
					SqlCommand cmd = new SqlCommand("Insert_Update_MailConfiguration", sqlConnection);
					SqlDataAdapter da = new SqlDataAdapter(cmd);
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.Parameters.AddWithValue("@Type", "F");
					cmd.ExecuteNonQueryAsync();
					sqlConnection.Close();
					da.Fill(ds);
				}
				return ds;

			}
			catch (Exception ex)
			{
				_Error = ex.ToString();
				return ds;
			}
		}

		//Get EmailConfig based on ID
		public DataSet EditEmailConfig(int emailConfigId)
		{
			string _Error = string.Empty;
			DataSet ds = new DataSet();
			try
			{
				using (sqlConnection = new SqlConnection(connectionString))
				{
					sqlConnection.Open();
					SqlCommand cmd = new SqlCommand("Insert_Update_MailConfiguration", sqlConnection);
					cmd.Parameters.AddWithValue("@EConfigID", emailConfigId);
					cmd.Parameters.AddWithValue("@Type", "S");
					SqlDataAdapter da = new SqlDataAdapter(cmd);
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.ExecuteNonQueryAsync();
					sqlConnection.Close();
					da.Fill(ds);
				}
				return ds;

			}
			catch (Exception ex)
			{
				_Error = ex.ToString();
				return ds;
			}
		}

		public DataSet UpdateEmailConfig(EmailConfig emailConfig)
		{
			string _Error = string.Empty;
			DataSet ds = new DataSet();
			try
			{
				using (sqlConnection = new SqlConnection(connectionString))
				{
					sqlConnection.Open();
					// Inserting Fetch in database                    
					SqlCommand cmd = new SqlCommand("Insert_Update_MailConfiguration", sqlConnection);
					SqlDataAdapter da = new SqlDataAdapter(cmd);
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.Parameters.AddWithValue("@Type", "U");
					cmd.Parameters.AddWithValue("@FormName", emailConfig.FormName);
					cmd.Parameters.AddWithValue("@MailFrom", emailConfig.MailFrom);
					cmd.Parameters.AddWithValue("@MailCC", emailConfig.MailCC);
					cmd.Parameters.AddWithValue("@MailBCC", emailConfig.MailBCC);
					cmd.Parameters.AddWithValue("@MailPurpose", emailConfig.MailPurpose);
					cmd.Parameters.AddWithValue("@MailContent", emailConfig.MailContent);
					cmd.Parameters.AddWithValue("@Updatedby", emailConfig.Updatedby);
					cmd.Parameters.AddWithValue("@Updateddate", emailConfig.Updateddate);
					cmd.Parameters.AddWithValue("@EConfigID", emailConfig.EConfigID);
					cmd.Parameters.AddWithValue("@Updateddate", emailConfig.Updateddate);
					cmd.ExecuteNonQueryAsync();
					sqlConnection.Close();
					da.Fill(ds);
				}
				return ds;

			}
			catch (Exception ex)
			{
				_Error = ex.ToString();
				return ds;
			}
		}

	}

}
