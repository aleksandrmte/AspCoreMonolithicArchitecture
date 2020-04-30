using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ApplicationCore.Common.Models;

namespace ApplicationCore.Common.Interfaces
{
    public interface IIdentityService
    {
        Task<string> GetUserNameAsync(string userName);
        Task<(Result Result, int UserId)> CreateUserAsync(string userName, string password);
        Task<Result> DeleteUserAsync(int userId);
    }
}
