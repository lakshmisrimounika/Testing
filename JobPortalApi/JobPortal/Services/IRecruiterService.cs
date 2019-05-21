using JobPortal.Helper;
using JobPortalLib.BO;
using JobPortalLib.DAL;
using JobPortalLib.DAL.Interfaces;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.Services
{
    public interface IRecruiterService
    {
        LoginBO Authenticate(LoginBO loginBO);
        IEnumerable<LoginBO> GetAll();
    }

    public class RecruiterService : IRecruiterService
    {
        IRecruiterDAL _recruiterDAL;
        LoginBO loginBO = new LoginBO();
        // users hardcoded for simplicity, store in a db with hashed passwords in production applications
        private List<LoginBO> _users = new List<LoginBO>();
        //{
        //    new LoginBO { LoginID = "sreenu", Password = "1234" }
        //};

        private readonly AppSettings _appSettings;

        public RecruiterService(IOptions<AppSettings> appSettings, IRecruiterDAL recruiterDAL)
        {
            _appSettings = appSettings.Value;
            _recruiterDAL = recruiterDAL;
        }

        public LoginBO Authenticate(LoginBO loginBO)
        {
           var user=_recruiterDAL.RecruiterLogin(loginBO, "R");
            // var user = _users.SingleOrDefault(x => x.LoginID == username && x.Password == password);

            // return null if user not found
            if (user.Result == 0)
                return null;

            // authentication successful so generate jwt token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim("","")
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            loginBO.Token = tokenHandler.WriteToken(token);

            // remove password before returning
            loginBO.Password = null;

            return loginBO;
        }

        public IEnumerable<LoginBO> GetAll()
        {
            //return users without passwords
            return _users.Select(x =>
            {
                x.Password = null;
                return x;
            });
            //return loginBO.Password
        }
    }
}

