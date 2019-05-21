using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using JobPortalLib.BO;
using JobPortalLib.DAL.Interfaces;
using JobPortalLib.Helper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace JobPortal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManageMastersController : ControllerBase
    {
		IRecruiterDAL _recruiterDAL;
		ILogEntry _logEntry;
		public ManageMastersController(ILogEntry logEntry, IRecruiterDAL recruiterDAL)
		{
			_logEntry = logEntry;
			_recruiterDAL = recruiterDAL;
		}

		// GET: api/ManageMasters
		[HttpGet("EmailConfig")]
        public DataSet GetEmailConfig()
		{

			string _Error = string.Empty;
			DataSet ds = new DataSet();
			try
			{
				_logEntry.PageName = "ManageMastersController";
				_logEntry.MethodName = "GetEmailConfig";
				_logEntry.Action = "Get";
				_logEntry.InputData = JsonConvert.SerializeObject("");
				LogFile.Write(_logEntry);
				//Calling Recruiter DAL method for Get Manage REcruiters data
				ds = _recruiterDAL.GetEmailConfig();
				return ds;

			}
			catch (Exception ex)
			{
				_Error = ex.ToString();
				return ds;
			}
		}

        // GET: api/ManageMasters/5
        [HttpGet("{id}", Name = "GetEmailConfigbyId")]
        public DataSet Get(int emailConfigId)
        {
			string _Error = string.Empty;
			DataSet ds = new DataSet();
			try
			{
				_logEntry.PageName = "ManageMastersController";
				_logEntry.MethodName = "GetEmailConfigbyId";
				_logEntry.Action = "Get";
				_logEntry.InputData = JsonConvert.SerializeObject("");
				LogFile.Write(_logEntry);
				//Calling Recruiter DAL method for Get Manage REcruiters data
				ds = _recruiterDAL.EditEmailConfig(emailConfigId);
				return ds;

			}
			catch (Exception ex)
			{
				_Error = ex.ToString();
				return ds;
			}
		}

        // POST: api/ManageMasters
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/ManageMasters/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] EmailConfig emailConfig)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
