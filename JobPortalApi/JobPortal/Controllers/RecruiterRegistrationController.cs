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
    public class RecruiterRegistrationController : ControllerBase
    {
        IRecruiterDAL _recruiterDAL;
        ILogEntry _logEntry;
        private static readonly Random _random = new Random();
        public RecruiterRegistrationController(ILogEntry logEntry, IRecruiterDAL recruiterDAL)
        {
            _logEntry = logEntry;
            _recruiterDAL = recruiterDAL;
        }
        [HttpPost]
        public async Task<int> PostRecruiter([FromBody]RecruiterBO recruiterBO)
        {
            try
            {
                _logEntry.PageName = "RecruiterRegistrationController";
                _logEntry.MethodName = "PostRecruiter";
                _logEntry.Action = "Post";
                _logEntry.InputData = JsonConvert.SerializeObject(recruiterBO);
                LogFile.Write(_logEntry);
                //Calling Recruiter DAL method for inserting the data
                int Result = await _recruiterDAL.AddRecruiter(recruiterBO, "I");
                return Result;
            }
            catch (Exception ex)
            {
                throw;
            }

        }        
        [HttpPost("PostRecruiterContact")]
        public async Task<int> PostRecruiterContact([FromBody]List<RecruiterContactsBO> recruiterContactsBO)
        {
            try
            {
                _logEntry.PageName = "RecruiterRegistrationController";
                _logEntry.MethodName = "PostRecruiterContact";
                _logEntry.Action = "Post";
                _logEntry.InputData = JsonConvert.SerializeObject(recruiterContactsBO);
                LogFile.Write(_logEntry);
                //Calling Recruiter DAL method for inserting the data
                int Result = await _recruiterDAL.AddRecruiterContact(recruiterContactsBO, "I");
                return Result;
            }
            catch (Exception ex)
            {
                throw;
            }

        }
        [HttpGet]
        public ActionResult<string> Captcha()
        { 
            string alphabets = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string small_alphabets = "abcdefghijklmnopqrstuvwxyz";
            string numbers = "1234567890";
            string characters = numbers;          
               characters += alphabets + small_alphabets + numbers;            
            int length = 6;
            string Captcha = string.Empty;
            for (int i = 0; i < length; i++)
            {
                string character = string.Empty;
                do
                {
                    int index = new Random().Next(0, characters.Length);
                    character = characters.ToCharArray()[index].ToString();
                } while (Captcha.IndexOf(character) != -1);
                Captcha += character;
            }
           return Captcha;
        }

    }
}