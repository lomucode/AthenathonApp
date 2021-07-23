using System.Collections.Generic;
using System.Threading.Tasks;
using App3over.RestClient;
using AthAppDB.moduls;

namespace App3over.Services
{
    public class AspUserServices
    {
        public async Task<List<AspNetUser>> GetAspNetUsersAsync()
        {
            RestClient<AspNetUser> restClient = new RestClient<AspNetUser>();
            var AspNetUserList = restClient.GetAsync();
            return await AspNetUserList;
        }
    }
}