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

                if (!context.Majors.Any())
                {
                    context.AddRangeAsync(
                    new Major()
                    {
                        majorName = "Informatika"
                    },
                    new Major()
                    {
                        majorName = "Számitástechnika"
                    },
                    new Major()
                    {
                        majorName = "Gépészmérnöki"
                    },
                    new Major()
                    {
                        majorName = "Mechatronika"
                    },
                    new Major()
                    {
                        majorName = "Kommunikáció"
                    },
                    new Major()
                    {
                        majorName = "Fordító és tolmács"
                    },
                    new Major()
                    {
                        majorName = "Távközlés"
                    },
                    new Major()
                    {
                        majorName = "Automatizálás"
                    },
                    new Major()
                    {
                        majorName = "Közegészségügy"
                    },
                    new Major()
                    {
                        majorName = "Kertészmérnöki"
                    },
                    new Major()
                    {
                        majorName = "Tájépítészet"
                    },
                    new Major()
                    {
                        majorName = "Agrármérnöki"
                    },
                    new Major()
                    {
                        majorName = "Erdőmérnöki"
                    });
                    context.SaveChanges();
                }

                if (!context.Subjects.Any())
                {
                    context.AddRangeAsync(
                    new Subject()
                    {
                        subjectName = "Geometria",
                        majorID = 1
                        
                    },
                    new Subject()
                    {
                        subjectName = "Mesterséges Intelligencia",
                        majorID = 1

                    },
                    new Subject()
                    {
                        subjectName = "Differenciálegyenletek és parciális differenciálegyenletek",
                        majorID = 1

                    },
                    new Subject()
                    {
                        subjectName = "Adatbázisok I.",
                        majorID = 1

                    },
                    new Subject()
                    {
                        subjectName = "Adatbázisok II.",
                        majorID = 1

                    },
                    new Subject()
                    {
                        subjectName = "Számítógép hálózatok I.",
                        majorID = 1

                    },
                    new Subject()
                    {
                        subjectName = "Számítógép hálozatok I.",
                        majorID = 2

                    },
                    new Subject()
                    {
                        subjectName = "Fizika I.",
                        majorID = 2

                    },
                    new Subject()
                    {
                        subjectName = "Logikai tervezés",
                        majorID = 2

                    },
                    new Subject()
                    {
                        subjectName = "Digitális elektronika",
                        majorID = 2

                    },
                    new Subject()
                    {
                        subjectName = "Analóg elektronika I.",
                        majorID = 2

                    });

                    context.SaveChanges();

                }
            }
        }
    }
}
