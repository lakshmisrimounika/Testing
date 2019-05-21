using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using JobPortalLib.BO;
using JobPortalLib.DAL;
using JobPortalLib.DAL.Interfaces;
using JobPortalLib.Helper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace JobPortal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ForgotPasswordController : ControllerBase
    {
        IConfiguration _configuration;       
        SendMail sendMail = new SendMail();
        ILogEntry _logEntry;
        string connectionString = string.Empty;
        IRecruiterDAL _recruiterDAL = null;
        public ForgotPasswordController(ILogEntry logEntry, IConfiguration configuration,IRecruiterDAL recruiterDAL)
        {
            _logEntry = logEntry;
            _configuration = configuration;
            connectionString= _configuration.GetSection("ConnectionStrings").GetSection("DefaultConnection").Value;
            _recruiterDAL = recruiterDAL;           
        }
       
        
        [HttpPost("Recruiter")]
        public string Recruiter([FromBody]ForgotPasswordBO forgotPasswordBO)
        {          
            try
            {
                DataSet dsCheckEmail = new DataSet();
                string Password = string.Empty;
                string Result = string.Empty;
                _logEntry.PageName = "ForgotPasswordController";
                _logEntry.MethodName = "Recruiter";
                _logEntry.Action = "Post";
                _logEntry.InputData = JsonConvert.SerializeObject(forgotPasswordBO);
                LogFile.Write(_logEntry);
                //Calling DAL method
             
                dsCheckEmail = _recruiterDAL.CheckEMailID(forgotPasswordBO, "R");
                if (dsCheckEmail.Tables[0].Rows.Count > 0)
                {
                    Password = dsCheckEmail.Tables[0].Rows[0]["Password"].ToString();
                    Result = sendMail.MailSend(forgotPasswordBO.EmailID.ToString(), Password);
                    if (Result == "Success")
                    {
                        Result = "Password Sent Successfully";
                    }
                }
                else
                {
                    Result = "EmailID Not Exists.";
                }
                return Result;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        [HttpPost("Staff")]
        public string Staff([FromBody]ForgotPasswordBO forgotPasswordBO)
        {
            try
            {
                DataSet dsCheckEmail = new DataSet();
                string Password = string.Empty;
                string Result = string.Empty;
                _logEntry.PageName = "ForgotPasswordController";
                _logEntry.MethodName = "Staff";
                _logEntry.Action = "Post";
                _logEntry.InputData = JsonConvert.SerializeObject(forgotPasswordBO);
                LogFile.Write(_logEntry);
                //Calling DAL method
                dsCheckEmail = _recruiterDAL.CheckEMailID(forgotPasswordBO, "A");
                if (dsCheckEmail.Tables[0].Rows.Count > 0)
                {
                    Password = dsCheckEmail.Tables[0].Rows[0]["Password"].ToString();                  
                    Result = _recruiterDAL.AddMailToDB(forgotPasswordBO.EmailID, forgotPasswordBO.FromEmailID, "Forgot Password", "Your Password is " + Password, "", "", "");
                    Result = "Password Sent Successfully";
                }
                else
                {
                    Result = "EmailID Not Exists.";
                }
                return Result;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}