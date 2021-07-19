using System;
using System.Threading.Tasks;
using AthenathonApp.Services;
using Refit;

namespace AthenathonApp.API
{
   interface IMyAPI
    {
        //http://192.168.187.202:5000/api/Login

        [Post("http://192.168.187.202:5000/api/Register")]
        Task<User> RegisterUser([Body] User user);

        [Post("http://192.168.187.202:5000/api/Login")]
        Task<User> LoginUser([Body] User user);
    }
}
