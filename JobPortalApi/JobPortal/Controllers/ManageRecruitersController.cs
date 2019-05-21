using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using JobPortalLib.BO;
using JobPortalLib.DAL;
using JobPortalLib.DAL.Interfaces;
using JobPortalLib.Helper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace JobPortal.Controllers
{
   
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class ManageRecruitersController : ControllerBase
    {
        IRecruiterDAL _recruiterDAL;
        ILogEntry _logEntry;
        private static readonly Random _random = new Random();
        public ManageRecruitersController(ILogEntry logEntry, IRecruiterDAL recruiterDAL)
        {
            _logEntry = logEntry;
            _recruiterDAL = recruiterDAL;
        }
        //Manage Recruiters
        [HttpGet]
        public DataSet FetchAllCompaniesbyStatus()
        {
            string _Error = string.Empty;
            DataSet ds = new DataSet();
            try
            {
                _logEntry.PageName = "ManageRecruitersController";
                _logEntry.MethodName = "FetchAllCompaniesbyStatus";
                _logEntry.Action = "Get";
                _logEntry.InputData = JsonConvert.SerializeObject("");
                LogFile.Write(_logEntry);
                //Calling Recruiter DAL method for Get Manage REcruiters data
                ds = _recruiterDAL.FetchAllCompaniesbyStatus("I");
                return ds;

            }
            catch (Exception ex)
            {
                _Error = ex.ToString();
                return ds;
            }
        }
        //Get Contact Details
        [HttpPost("FetchAllContacts")]
        public DataSet FetchAllContacts(PostJobBO postJobBO)
        {
            string _Error = string.Empty;
            DataSet ds = new DataSet();
            try
            {
                _logEntry.PageName = "ManageRecruitersController";
                _logEntry.MethodName = "FetchAllContacts";
                _logEntry.Action = "Post";
                _logEntry.InputData = JsonConvert.SerializeObject("postJobBO");
                LogFile.Write(_logEntry);
                int Id = Convert.ToInt32(postJobBO.CompanyID);
                //Calling Recruiter DAL method
                ds = _recruiterDAL.FetchAllContacts(Id, "L");
                return ds;

            }
            catch (Exception ex)
            {
                _Error = ex.ToString();
                return ds;
            }
        }
        //Get Company Details
        [HttpPost("FetchCompany")]
        public DataSet FetchCompany(PostJobBO postJobBO)
        {
            string _Error = string.Empty;
            DataSet ds = new DataSet();
            try
            {
                _logEntry.PageName = "ManageRecruitersController";
                _logEntry.MethodName = "FetchCompany";
                _logEntry.Action = "Post";
                _logEntry.InputData = JsonConvert.SerializeObject("postJobBO");
                LogFile.Write(_logEntry);
                int Id = Convert.ToInt32(postJobBO.CompanyID);
                //Calling Recruiter DAL method
                ds = _recruiterDAL.FetchCompany(Id,"F");
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