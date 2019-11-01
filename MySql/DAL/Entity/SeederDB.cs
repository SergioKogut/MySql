using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MySql.DAL.Entity
{
    public class SeederDB
    {

        private static int RandomNumber(int min, int max)
        {
            Random random = new Random();
            return random.Next(min, max);
        }

        private static void SeedData(EFContext context)
        {
            #region tblUsers - Користувачі
            List<string> users = new List<string>{
             "Sergio Kogut",
             "Anton Gerasimov",
             "Yuriy Gagarin",
             "Andry Fitisov"
            };
            foreach (var item in users)
            {
                if (context.Users.SingleOrDefault(f => f.Name == item) == null)
                {
                    context.Users.Add(
                        new User
                        {
                            Name = item,
                            Age = RandomNumber(20, 50)
                           
                        });
                    context.SaveChanges();
                }
            }
            #endregion

        }


        public static void SeedDataByAS(IServiceProvider services)
        {
            using (var scope = services.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<EFContext>();
                //var manager = scope.ServiceProvider.GetRequiredService<UserManager<DbUser>>();
                // var managerRole = scope.ServiceProvider.GetRequiredService<RoleManager<DbRole>>();
                SeederDB.SeedData(context);
            }
        }
    }
}
