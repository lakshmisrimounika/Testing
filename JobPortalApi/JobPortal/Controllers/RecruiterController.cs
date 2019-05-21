using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JobPortalLib.BO;
using JobPortalLib.DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Runtime.Serialization;
using JobPortalLib.Helper;
using JobPortalLib.DAL.Interfaces;

namespace JobPortal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecruiterController : ControllerBase
    {
        IRecruiterDAL _recruiterDAL;
        ILogEntry _logEntry;
        public RecruiterController(ILogEntry logEntry, IRecruiterDAL recruiterDAL)
        {
            _logEntry = logEntry;
            _recruiterDAL = recruiterDAL;
        }
        [HttpPost]
        public async Task<int> PostRecruiter([FromBody]RecruiterBO recruitermaster)
        {
            try
            {
                _logEntry.PageName = "RecruiterController";
                _logEntry.MethodName = "PostRecruiter";
                _logEntry.Action = "Post";
                _logEntry.InputData = JsonConvert.SerializeObject(recruitermaster);
                LogFile.Write(_logEntry);
                //Calling Recruiter DAL method for inserting the data
                int Result = await _recruiterDAL.AddRecruiter(recruitermaster, "I");
                return Result;
            }
            catch (Exception ex)
            {
                throw;
            }

        }
        [Route("PostRecruiterContact")]
        [HttpPost]
        public async Task<int> PostRecruiterContact([FromBody]List<RecruiterContactsBO> recruiterContacts)
        {
            try
            {
                _logEntry.PageName = "RecruiterController";
                _logEntry.MethodName = "PostRecruiterContact";
                _logEntry.Action = "Post";
                _logEntry.InputData = JsonConvert.SerializeObject(recruiterContacts);
                LogFile.Write(_logEntry);
                //Calling Recruiter DAL method for inserting the data
                int Result = await _recruiterDAL.AddRecruiterContact(recruiterContacts, "I");
                return Result;
            }
            catch (Exception ex)
            {
                throw;
            }

        }
      
    }
}