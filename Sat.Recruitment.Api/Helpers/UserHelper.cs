using Sat.Recruitment.Api.Models;
using System.Collections.Generic;
using System.IO;

namespace Sat.Recruitment.Api.Helpers
{
    public static class UserHelper
    {
        public static IList<User> ReadUsersFromFile()
        {
            var users = new List<User>();

            using (var reader = LoadFile())
            {
                while (reader.Peek() >= 0)
                {
                    var line = reader.ReadLineAsync().Result;
                    var userRead = new User
                    {
                        Name = line.Split(',')[0].ToString(),
                        Email = line.Split(',')[1].ToString(),
                        Phone = line.Split(',')[2].ToString(),
                        Address = line.Split(',')[3].ToString(),
                        UserType = line.Split(',')[4].ToString(),
                        Money = decimal.Parse(line.Split(',')[5].ToString()),
                    };
                    users.Add(userRead);
                }
                reader.Close();
            }
            
            return users;
        }

        private static StreamReader LoadFile()
        {
            var path = Directory.GetCurrentDirectory() + "/Files/Users.txt";

            FileStream fileStream = new FileStream(path, FileMode.Open);
            StreamReader reader = new StreamReader(fileStream);

            return reader;
        }
    }
}
