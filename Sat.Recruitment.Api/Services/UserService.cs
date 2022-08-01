using Sat.Recruitment.Api.Helpers;
using Sat.Recruitment.Api.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Sat.Recruitment.Api.Services
{
    public class UserService : IUserService
    {
        public async Task<Result> Create(User user)
        {
            var result = new Result();

            user.Money = Calculate(user.UserType, user.Money);
            user.Email = MailHelper.Normalize(user.Email);

            var users = UserHelper.ReadUsersFromFile();

            var isDuplicated = users.Any(u => (u.Email == user.Email || u.Phone == user.Email) || 
                                              (u.Name == user.Name && u.Address == user.Address));

            if (isDuplicated)            
                return new Result { IsSuccess = false , Errors = "The user is duplicated" };            

            return new Result { IsSuccess = true , Errors = "User Created" };
        }

        private decimal Calculate(string userType, decimal money)
        {
            decimal percentage = 0;
            switch (userType)
            {
                case "Normal":
                    percentage = money > 100 ? Convert.ToDecimal(0.12) : Convert.ToDecimal(0.8);
                    break;
                case "SuperUser":
                    percentage = money > 100 ? Convert.ToDecimal(0.20) : 0;
                    break;
                case "Premium":
                    percentage = money > 100 ? 2 : 0;
                    break;
            }

            var gif = money * percentage;
            money = money + gif;

            return money;
        }
    }    
}
