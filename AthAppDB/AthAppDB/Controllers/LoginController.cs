using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AthAppDB.moduls;
using WebApplicationAthenA.Hash;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AthAppDB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        ATHENATONContext dbContext = new ATHENATONContext();



        // POST api/<LoginController>
        [HttpPost]
        public string Post([FromBody] AspNetUser value)
        {

            if (dbContext.AspNetUsers.Any(user => user.Email.Equals(value.Email)))
            {
                AspNetUser user = dbContext.AspNetUsers.Where(u => u.Email.Equals(value.Email)).First();

                //var Client_post_hash_password = Convert.ToBase64String(
                //    Common.SaltHashPassword(Encoding.ASCII.GetBytes(value.PasswordHash),
                //        Convert.FromBase64String(user.ConcurrencyStamp)));

                if (user.PasswordHash.Equals(value.PasswordHash))
                    return JsonConvert.SerializeObject(user);
                else
                    return JsonConvert.SerializeObject("Falsche Zugangsdaten");

            }
            else
            {
                return JsonConvert.SerializeObject("User not Existing in Database");
            }



        }



    }
}