using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using JobPortalLib.BO;

namespace JobPortalLib.DAL.Interfaces
{
    public interface IRecruiterDAL
    {
        string AddMailToDB(string _SendTo, string _From, string _Subject, string _Body, string _CC, string _BCC, string _AttachedPath);
        Task<int> AddRecruiter(RecruiterBO recruiterMaster, string Type);
        Task<int> AddRecruiterContact(List<RecruiterContactsBO> recruiterContacts, string Type);
        DataSet CheckEMailID(ForgotPasswordBO forgotPasswordBO, string Type);
        DataSet FetchAllCompaniesbyStatus(string Status);
        DataSet FetchAllContacts(int CompanyID, string Status);
        Task<DataTable> FetchBDWiseReport(DashboardBO dashboardBO);
        DataSet FetchCompany(int CompanyID, string Status);
        Task<DataTable> GetPostJobsData(GetPostJobsBO getPostJobsBO, string Type);
        Task<int> PostJob(PostJobBO postJobBO, string Type);
        Task<int> RecruiterLogin(LoginBO recruiterLogin, string Type);
		DataSet GetEmailConfig();
		DataSet EditEmailConfig(int emailConfigId);
	}
}