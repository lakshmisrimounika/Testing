using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JobPortalLib.BO;
using JobPortalLib.DAL;
using JobPortalLib.DAL.Interfaces;
using JobPortalLib.Helper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace JobPortal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        IRecruiterDAL _recruiterDAL;
        ILogEntry _logEntry;
        public LoginController(ILogEntry logEntry,IRecruiterDAL recruiterDAL)
        {
            _logEntry = logEntry;
            _recruiterDAL = recruiterDAL;
        }      
        [HttpPost("Recruiter")]
        public async Task<int> Recruiter([FromBody]LoginBO loginBO)
        {
            try
            {
                _logEntry.PageName = "LoginController";
                _logEntry.MethodName = "Recruiter";
                _logEntry.Action = "Post";
                _logEntry.InputData = JsonConvert.SerializeObject(loginBO);
                LogFile.Write(_logEntry);
                //Calling Recruiter DAL method
                int Result = await _recruiterDAL.RecruiterLogin(loginBO, "R");
                return Result;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        [HttpPost("Staff")]
        public async Task<int> Staff([FromBody]LoginBO loginBO)
        {
            try
            {
                _logEntry.PageName = "LoginController";
                _logEntry.MethodName = "Staff";
                _logEntry.Action = "Post";
                _logEntry.InputData = JsonConvert.SerializeObject(loginBO);
                LogFile.Write(_logEntry);
                //Calling Recruiter DAL
                int Result = await _recruiterDAL.RecruiterLogin(loginBO, "C");
                return Result;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        [HttpPost("Alumni")]
        public async Task<int> Alumni([FromBody]LoginBO loginBO)
        {
            try
            {
                _logEntry.PageName = "LoginController";
                _logEntry.MethodName = "Alumni";
                _logEntry.Action = "Post";
                _logEntry.InputData = JsonConvert.SerializeObject(loginBO);
                LogFile.Write(_logEntry);
                //Calling Recruiter DAL
                int Result = await _recruiterDAL.RecruiterLogin(loginBO, "R");
                return Result;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}