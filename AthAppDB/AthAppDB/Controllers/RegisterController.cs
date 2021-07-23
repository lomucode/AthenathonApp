using AthAppDB.moduls;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AthAppDB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        readonly ATHENATONContext dbContext = new ATHENATONContext();




        // POST api/<registerController>
        [HttpPost]
        public String Post([FromBody] AspNetUser value)
        {
            if (!dbContext.AspNetUsers.Any(user => user.Email.Equals(value.Email)))
            {
                AspNetUser user = new AspNetUser();
                user.Email = value.Email;
                //Securityst = Guid.NewGuid().ToString();
                user.UserName = value.Email;
                user.PasswordHash = value.PasswordHash;
                //user.Id = Guid.NewGuid().ToString();
                //var result = await AspNetUser.CreateAsync(user, Password);
                //user.Salt = Convert.ToBase64String(Common, GetHashCode(16));






                try
                {
                    dbContext.Add(user);
                    user.Id = Guid.NewGuid().ToString();


                    dbContext.SaveChanges();
                    return JsonConvert.SerializeObject(user);

                }
                catch (Exception ex)
                {
                    return JsonConvert.SerializeObject(ex.Message);
                }
            }
            else
            {
                return JsonConvert.SerializeObject("user is already taken");
            }

        }


    }
}