using web.Models;
using System;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
namespace web.Data
{
    public static class DbInitializer
    {
        public static void Initialize(KinoContext ctx)
        {
            ctx.Database.EnsureCreated();

            if (ctx.movies.Any())
            {
                return;   // DB has been seeded
            }

            var genres = new Genre[]{
                new Genre{GenreName="Action"},
                new Genre{GenreName="Horror"},
                new Genre{GenreName="Drama"},
                new Genre{GenreName="Comedy"},
                new Genre{GenreName="Animation"},
                new Genre{GenreName="Science fiction"},
                new Genre{GenreName="Romance"},
                new Genre{GenreName="Musical"},
                new Genre{GenreName="Thriller"},
                new Genre{GenreName="Horror"}
            };
            ctx.genres.AddRange(genres);
            ctx.SaveChanges();

            var people = new People[]{
                // The Fast and the Furious: Tokyo Drif
                new People{Name="Justin Lin"},
                 new People{Name="Lucas Black"},
                new People{Name="Bow Wow"},
                // Godzilla: King of the Monsters
                new People{Name="Michael Dougherty"},
                new People{Name="Kyle Chandler"},
                new People{Name="Vera Farmiga"},
                new People{Name="Millie Bobby Brown"},
                // Anchorman 2: The Legend Continues
                new People{Name="Adam McKay"},
                new People{Name="Will Ferrell"},
                new People{Name="Steve Carell"},
                // The Hateful Eight
                new People{Name="Quentin Tarantino"},
                new People{Name="Samuel L. Jackson"},
                new People{Name="Kurt Russell"},
                // Creed
                new People{Name="Ryan Coogler"},
                new People{Name="Michael B. Jordan"},
                new People{Name="Sylvester Stallone"},
                // Jurassic World
                new People{Name="Colin Trevorrow"},
                new People{Name="Chris Pratt"},
                new People{Name="Bryce Dallas Howard"},
                // Inside Out 
                new People{Name="Pete Docter"},
                new People{Name="Amy Poehler"},
                new People{Name="Phyllis Smith"}
            };
            ctx.people.AddRange(people);
            ctx.SaveChanges();

            Room[] rooms = new Room[]{
                new Room{Name="Room 1"},
                new Room{Name="Room 2"},
                new Room{Name="Room 3"},
                new Room{Name="Room 4"}
            };
            ctx.rooms.AddRange(rooms);
            ctx.SaveChanges();

            var seats = new Seat[4*12*30];
            int c = 0;
                
            for(int room = 0; room <= 3; room++){
                for(int row = 1; row <= 12; row++){
                    for(int number = 1; number <= 30; number++){
                        seats[c++] = new Seat{Room=rooms[room],Row=row,Number=number};
                    }
                }
            }
            ctx.seats.AddRange(seats);
            ctx.SaveChanges();

            var movies = new Movie[]{
                new Movie{Title="Fast and Furious: Tokyo Drift",Rating="PG-13",Length="122", StartDate=new DateTime(2020,9,30),EndDate=new DateTime(2021,1,23)},
                new Movie{Title="Godzilla: King of the monsters",Rating="PG-13",Length="134",StartDate=new DateTime(2020,9,21),EndDate=new DateTime(2021,1,15)},
                new Movie{Title="Anchorman 2",Rating="PG-13",Length="119",StartDate=new DateTime(2020,8,3),EndDate=new DateTime(2020,12,30)},
                new Movie{Title="Hateful eight",Rating="R",Length="168",StartDate=new DateTime(2020,7,5),EndDate=new DateTime(2020,12,15)},
                new Movie{Title="Creed",Rating="PG-13",Length="133",StartDate=new DateTime(2020,7,17),EndDate=new DateTime(2020,12,11)},
                new Movie{Title="Jurassic World",Rating="PG-13",Length="124",StartDate=new DateTime(2020,6,9),EndDate=new DateTime(2020,12,1)},
                new Movie{Title="Inside Out",Rating="PG",Length="95",StartDate=new DateTime(2020,8,12),EndDate=new DateTime(2020,12,25)}
            };
            ctx.movies.AddRange(movies);
            ctx.SaveChanges();
            
            // added genres to movies
            var movieGenres = new GenreMovie[]
                {
                    new GenreMovie {
                        MovieID = movies.Single(m => m.Title == "Inside Out" ).MovieID,
                        GenreID = genres.Single(i => i.GenreName == "Action").GenreID
                    },
                    new GenreMovie {
                        MovieID = movies.Single(m => m.Title == "Fast and Furious: Tokyo Drift" ).MovieID,
                        GenreID = genres.Single(i => i.GenreName == "Action").GenreID
                    },
                    new GenreMovie {
                        MovieID = movies.Single(m => m.Title == "Fast and Furious: Tokyo Drift" ).MovieID,
                        GenreID = genres.Single(i => i.GenreName == "Drama").GenreID
                    },
                    new GenreMovie {
                        MovieID = movies.Single(m => m.Title == "Godzilla: King of the monsters" ).MovieID,
                        GenreID = genres.Single(i => i.GenreName == "Science fiction").GenreID
                    },
                    new GenreMovie {
                        MovieID = movies.Single(m => m.Title == "Godzilla: King of the monsters" ).MovieID,
                        GenreID = genres.Single(i => i.GenreName == "Action").GenreID
                    },
                    new GenreMovie {
                        MovieID = movies.Single(m => m.Title == "Anchorman 2" ).MovieID,
                        GenreID = genres.Single(i => i.GenreName == "Comedy").GenreID
                    },
                    new GenreMovie {
                        MovieID = movies.Single(m => m.Title == "Hateful eight" ).MovieID,
                        GenreID = genres.Single(i => i.GenreName == "Drama").GenreID
                    },
                    new GenreMovie {
                        MovieID = movies.Single(m => m.Title == "Creed" ).MovieID,
                        GenreID = genres.Single(i => i.GenreName == "Drama").GenreID
                    },
                    new GenreMovie {
                        MovieID = movies.Single(m => m.Title == "Jurassic World" ).MovieID,
                        GenreID = genres.Single(i => i.GenreName == "Action").GenreID
                    },
                    new GenreMovie {
                        MovieID = movies.Single(m => m.Title == "Inside Out" ).MovieID,
                        GenreID = genres.Single(i => i.GenreName == "Animation").GenreID
                    }
                };

            foreach (GenreMovie gm in movieGenres)
            {
                ctx.GenreMovies.Add(gm);
            }
            ctx.SaveChanges();

             // added actors to movies
            var actors = new Actors[] {
                new Actors {
                    MovieID = movies.Single(m => m.Title == "Fast and Furious: Tokyo Drift" ).MovieID,
                    PeopleID = people.Single(p => p.Name == "Lucas Black").PeopleID
                },
                new Actors {
                    MovieID = movies.Single(m => m.Title == "Fast and Furious: Tokyo Drift" ).MovieID,
                    PeopleID = people.Single(p => p.Name == "Bow Wow").PeopleID
                },
                new Actors {
                    MovieID = movies.Single(m => m.Title == "Godzilla: King of the monsters" ).MovieID,
                    PeopleID = people.Single(p => p.Name == "Kyle Chandler").PeopleID
                },
                new Actors {
                    MovieID = movies.Single(m => m.Title == "Godzilla: King of the monsters" ).MovieID,
                    PeopleID = people.Single(p => p.Name == "Vera Farmiga").PeopleID
                },
                new Actors {
                    MovieID = movies.Single(m => m.Title == "Godzilla: King of the monsters" ).MovieID,
                    PeopleID = people.Single(p => p.Name == "Millie Bobby Brown").PeopleID
                },
                new Actors {
                    MovieID = movies.Single(m => m.Title == "Anchorman 2" ).MovieID,
                    PeopleID = people.Single(p => p.Name == "Will Ferrell").PeopleID
                },
                new Actors {
                    MovieID = movies.Single(m => m.Title == "Anchorman 2" ).MovieID,
                    PeopleID = people.Single(p => p.Name == "Steve Carell").PeopleID
                },
                new Actors {
                    MovieID = movies.Single(m => m.Title == "Hateful eight" ).MovieID,
                    PeopleID = people.Single(p => p.Name == "Samuel L. Jackson").PeopleID
                },
                new Actors {
                    MovieID = movies.Single(m => m.Title == "Hateful eight" ).MovieID,
                    PeopleID = people.Single(p => p.Name == "Kurt Russell").PeopleID
                },
                new Actors {
                    MovieID = movies.Single(m => m.Title == "Creed" ).MovieID,
                    PeopleID = people.Single(p => p.Name == "Michael B. Jordan").PeopleID
                },
                new Actors {
                    MovieID = movies.Single(m => m.Title == "Creed" ).MovieID,
                    PeopleID = people.Single(p => p.Name == "Sylvester Stallone").PeopleID
                },
                new Actors {
                    MovieID = movies.Single(m => m.Title == "Jurassic World" ).MovieID,
                    PeopleID = people.Single(p => p.Name == "Chris Pratt").PeopleID
                },
                new Actors {
                    MovieID = movies.Single(m => m.Title == "Jurassic World" ).MovieID,
                    PeopleID = people.Single(p => p.Name == "Bryce Dallas Howard").PeopleID
                },
                new Actors {
                    MovieID = movies.Single(m => m.Title == "Inside Out" ).MovieID,
                    PeopleID = people.Single(p => p.Name == "Amy Poehler").PeopleID
                },
                new Actors {
                    MovieID = movies.Single(m => m.Title == "Inside Out" ).MovieID,
                    PeopleID = people.Single(p => p.Name == "Phyllis Smith").PeopleID
                }
            };

            foreach (Actors a in actors)
                ctx.Actors.Add(a);
            ctx.SaveChanges();

             // added directors to movies
            var directors = new Directors[] {
                new Directors {
                    MovieID = movies.Single(m => m.Title == "Fast and Furious: Tokyo Drift" ).MovieID,
                    PeopleID = people.Single(p => p.Name == "Justin Lin").PeopleID
                },
                new Directors {
                    MovieID = movies.Single(m => m.Title == "Godzilla: King of the monsters" ).MovieID,
                    PeopleID = people.Single(p => p.Name == "Michael Dougherty").PeopleID
                },
                new Directors {
                    MovieID = movies.Single(m => m.Title == "Anchorman 2" ).MovieID,
                    PeopleID = people.Single(p => p.Name == "Adam McKay").PeopleID
                },
                new Directors {
                    MovieID = movies.Single(m => m.Title == "Hateful eight" ).MovieID,
                    PeopleID = people.Single(p => p.Name == "Quentin Tarantino").PeopleID
                },
                new Directors {
                    MovieID = movies.Single(m => m.Title == "Creed" ).MovieID,
                    PeopleID = people.Single(p => p.Name == "Ryan Coogler").PeopleID
                },
                new Directors {
                    MovieID = movies.Single(m => m.Title == "Jurassic World" ).MovieID,
                    PeopleID = people.Single(p => p.Name == "Colin Trevorrow").PeopleID
                },
                new Directors {
                    MovieID = movies.Single(m => m.Title == "Inside Out" ).MovieID,
                    PeopleID = people.Single(p => p.Name == "Pete Docter").PeopleID
                },
            };

            foreach (Directors d in directors)
                ctx.Directors.Add(d);
            ctx.SaveChanges();


            ctx.Roles.Add(new IdentityRole{Id="1", Name="Administrator"});

            // admin account
            var user = new AppUser
            {
                FirstName = "Gospod",
                LastName = "Admin",
                NormalizedEmail = "ADMIN@KINO.SI",
                Email = "admin@kino.si",
                UserName = "admin@kino.si",
                NormalizedUserName = "ADMIN@KINO.SI",
                PhoneNumber = "+111111111111",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString("D")
            };

            if (!ctx.Users.Any(u => u.UserName == user.UserName))
            {
                var password = new PasswordHasher<AppUser>();
                var hashed = password.HashPassword(user,"Geslogeslo1!");
                user.PasswordHash = hashed;
                ctx.Users.Add(user);
            }

            ctx.SaveChanges();

        }
    }
}