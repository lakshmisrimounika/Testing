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
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PostJobController : ControllerBase
    {
        IRecruiterDAL _recruiterDAL;
        ILogEntry _logEntry;
        public PostJobController(ILogEntry logEntry, IRecruiterDAL recruiterDAL)
        {
            _logEntry = logEntry;
            _recruiterDAL = recruiterDAL;
        }
        [HttpPost("Staff")]
        public async Task<int> Staff([FromBody]PostJobBO postJobBO)
        {
            try
            {
                _logEntry.PageName = "PostJobController";
                _logEntry.MethodName = "Staff";
                _logEntry.Action = "Post";
                _logEntry.InputData = JsonConvert.SerializeObject(postJobBO);
                LogFile.Write(_logEntry);
                //Calling Recruiter DAL method for inserting the data
                int Result = await _recruiterDAL.PostJob(postJobBO, "I");
                return Result;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        [HttpPost("GetPostJobsData")]
        public async Task<DataTable> GetPostJobsData([FromBody]GetPostJobsBO getPostJobsBO)
        {
            try
            {
                DataTable dt = new DataTable();
                _logEntry.PageName = "PostJobController";
                _logEntry.MethodName = "GetJobsData";
                _logEntry.Action = "Post";
                _logEntry.InputData = JsonConvert.SerializeObject(getPostJobsBO);
                LogFile.Write(_logEntry);
                //Calling Recruiter DAL method
               dt = await _recruiterDAL.GetPostJobsData(getPostJobsBO, "B");
                return dt;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}