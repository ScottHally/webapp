using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WebApplication1.Data;
using System;
using System.Linq;
namespace WebApplication1.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new WebApplication1Context(
                serviceProvider.GetRequiredService<
                    DbContextOptions<WebApplication1Context>>()))
            {


                if (!context.League.Any())
                {
                    context.League.AddRange(
                        new League
                        {
                            Name = "NHL",
                            Sport = "Hockey"
                        },

                        new League
                        {
                            Name = "MLB",
                            Sport = "Baseball"
                        },

                        new League
                        {
                            Name = "NFL",
                            Sport = "Gridiron"
                        },

                        new League
                        {
                            Name = "NBA",
                            Sport = "Basketball"
                        }


                    );
                }
                // Look for any players.
                if (context.Player.Any())
                {
                    return;   // DB has been seeded
                }

                context.Player.AddRange(
                    new Player
                    {
                        Name = "Mark Scheifele",
                        BirthDate = DateTime.Parse("1993-3-15"),
                        Team = "Winnipeg Jets",
                        Salary = 7.99M,
                        Rating = "A+",
                        LeagueID = 1
                    },

                    new Player
                    {
                        Name = "Blake Wheeler",
                        BirthDate = DateTime.Parse("1986-08-31"),
                        Team = "Winnipeg Jets",
                        Salary = 8.99M,
                        Rating = "A",
                        LeagueID = 1
                    },

                    new Player
                    {
                        Name = "Nikolaj Ehlers",
                        BirthDate = DateTime.Parse("1996-02-14"),
                        Team = "Winnipeg Jets",
                        Salary = 9.99M,
                        Rating = "A",
                        LeagueID = 1
                    },

                    new Player
                    {
                        Name = "Kyle Connor",
                        BirthDate = DateTime.Parse("1996-12-09"),
                        Team = "Winnipeg Jets",
                        Salary = 3.99M,
                        Rating = "A",
                        LeagueID = 1
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
