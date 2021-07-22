using System;
using System.Threading.Tasks;
using AthenathonApp.Services;
using Refit;

namespace AthenathonApp.API
{
   interface IMyAPI
    {
        //http://192.168.178.27:5000/api/Login

        [Post("/api/Register")]
        Task<PostUser> RegisterUser([Body] PostUser user);

        [Post("/api/Login")]
        Task<PostUser> LoginUser([Body] PostUser user);
    }
}
