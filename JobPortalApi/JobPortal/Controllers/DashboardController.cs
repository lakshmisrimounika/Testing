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
   // [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardController : ControllerBase
    {
        IRecruiterDAL _recruiterDAL;
        ILogEntry _logEntry;
        public DashboardController(ILogEntry logEntry, IRecruiterDAL recruiterDAL)
        {
            _logEntry = logEntry;
            _recruiterDAL = recruiterDAL;
        }
        [HttpPost("Staff")]
        public async Task<DataTable> Staff([FromBody]DashboardBO dashboardBO)
        {
            try
            {
                DataTable dt = new DataTable();
                _logEntry.PageName = "DashboardController";
                _logEntry.MethodName = "Staff";
                _logEntry.Action = "Post";
                _logEntry.InputData = JsonConvert.SerializeObject(dashboardBO);
                LogFile.Write(_logEntry);
                //Calling Recruiter DAL method for Get Dashboard the data
                 dt = await _recruiterDAL.FetchBDWiseReport(dashboardBO);               
                return dt;
            }
            catch (Exception Ex)
            {
                throw;
            }
        }
    }
}