using SapinotesAPI.Data.Models;

namespace SapinotesAPI.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();


                if (!context.Users.Any())
                {
                    context.AddRangeAsync(
                    new User()
                    {
                        username = "hamzabalazs99",
                        email = "hamzabalazs99@gmail.com",
                        password = "jelszo1234",
                        
                    },
                    new User()
                    {
                        username = "tothadam98",
                        email = "tothadam98@gmail.com",
                        password = "kecskekecske",
                        
                    },
                    new User()
                    {
                        username = "nagyviktor56",
                        email = "nagyviktor56@gmail.com",
                        password = "NViktor56",
                        
                    });

                    context.SaveChanges();

                }
            }
        }
    }
}
