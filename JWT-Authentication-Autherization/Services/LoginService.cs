using JWT_Authentication_Autherization.CustomFiles;
using JWT_Authentication_Autherization.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JWT_Authentication_Autherization.Services
{
    public class LoginService
    {
        private readonly autherizationContext _autherizationContext;

        public LoginService(autherizationContext autherizationContext)
        {
            _autherizationContext = autherizationContext;
        }

        public List<Role> GetAllRole()
        {
            try
            {
                var roles = _autherizationContext.Roles.ToList();
                return roles;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new List<Role>();
            }
        }

        public ActionResult<Role> CreateRole(CreateRoleDTO role)
        {
            try
            {
                var roles = new Role
                {
                    Name = role.Name
                };
                _autherizationContext.Roles.Add(roles);
                _autherizationContext.SaveChanges();
                return roles;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new BadRequestObjectResult(ex.Message);
            }
        }

        public  List<Login> GetAllLogin()
        {
            try
            {
                var logins = _autherizationContext.Logins.ToList();
                return logins;
            }
            catch (Exception ex)
            {
                return new List<Login>();
            }
        }

        public ActionResult<Login> CreateUser(CreateUserDTO login)
        {
            try
            {
                //string hashedPassword = HashPassword(login.Password);

                var lgn = new Login
                {
                    Name = login.Name,
                    EmailId = login.EmailId,
                    MobileNo = login.MobileNo,
                    //Password = hashedPassword,
                    Password = login.Password,
                    RoleId = login.RoleId

                };

                _autherizationContext.Logins.Add(lgn);
                _autherizationContext.SaveChanges();
                return lgn;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new BadRequestObjectResult(ex.Message);
            }
        }

        //private string HashPassword(string Password)
        //{
        //    return Convert.ToBase64String(Encoding.UTF8.GetBytes(Password));
        //}
    }
}
