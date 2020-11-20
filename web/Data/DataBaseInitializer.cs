using web.Models;
using System;
using System.Linq;

namespace web.Data
{
    public static class DbInitializer
    {
        public static void Initialize(KinoContext ctx)
        {
            ctx.Database.EnsureCreated();

            if (!ctx.genres.Any()){
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
            }

            if (!ctx.people.Any()){
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
            }

            Room[] rooms = null;
            if (!ctx.rooms.Any()){
                rooms = new Room[]{
                    new Room{Name="Dvorana 1"},
                    new Room{Name="Dvorana 2"},
                    new Room{Name="Dvorana 3"},
                    new Room{Name="Dvorana 4"}
                };
                ctx.rooms.AddRange(rooms);
                ctx.SaveChanges();
            }

            if (!ctx.seats.Any() && rooms != null){
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
            }

            if (ctx.movies.Any())
            {
                return;
            }
            var movies = new Movie[]{
                new Movie{Name="Fast and Furious: Tokyo Drift",Rating="PG-13",Length="122", StartDate=new DateTime(2020,9,30),EndDate=new DateTime(2021,1,23)},
                new Movie{Name="Godzilla: King of the monsters",Rating="PG-13",Length="134",StartDate=new DateTime(2020,9,21),EndDate=new DateTime(2021,1,15)},
                new Movie{Name="Anchorman 2",Rating="PG-13",Length="119",StartDate=new DateTime(2020,8,3),EndDate=new DateTime(2020,12,30)},
                new Movie{Name="Hateful eight",Rating="R",Length="168",StartDate=new DateTime(2020,7,5),EndDate=new DateTime(2020,12,15)},
                new Movie{Name="Creed",Rating="PG-13",Length="133",StartDate=new DateTime(2020,7,17),EndDate=new DateTime(2020,12,11)},
                new Movie{Name="Jurassic World",Rating="PG-13",Length="124",StartDate=new DateTime(2020,6,9),EndDate=new DateTime(2020,12,1)},
                new Movie{Name="Inside Out",Rating="PG",Length="95",StartDate=new DateTime(2020,8,12),EndDate=new DateTime(2020,12,25)}
            };
            ctx.movies.AddRange(movies);
            ctx.SaveChanges();


            /* DB doesn't have any data */
            /* var students = new Student[]
            {
                new Student{FirstMidName="Carson",LastName="Alexander",EnrollmentDate=DateTime.Parse("2019-09-01")},
                new Student{FirstMidName="Meredith",LastName="Alonso",EnrollmentDate=DateTime.Parse("2017-09-01")},
                new Student{FirstMidName="Arturo",LastName="Anand",EnrollmentDate=DateTime.Parse("2018-09-01")},
                new Student{FirstMidName="Gytis",LastName="Barzdukas",EnrollmentDate=DateTime.Parse("2017-09-01")},
                new Student{FirstMidName="Yan",LastName="Li",EnrollmentDate=DateTime.Parse("2017-09-01")},
                new Student{FirstMidName="Peggy",LastName="Justice",EnrollmentDate=DateTime.Parse("2016-09-01")},
                new Student{FirstMidName="Laura",LastName="Norman",EnrollmentDate=DateTime.Parse("2018-09-01")},
                new Student{FirstMidName="Nino",LastName="Olivetto",EnrollmentDate=DateTime.Parse("2019-09-01")}
            }; */

            /* ctx.students.AddRange(students);
            ctx.SaveChanges(); */

            /* var courses = new Course[]
            {
                new Course{CourseID=1050,Title="Chemistry",Credits=3},
                new Course{CourseID=4022,Title="Microeconomics",Credits=3},
                new Course{CourseID=4041,Title="Macroeconomics",Credits=3},
                new Course{CourseID=1045,Title="Calculus",Credits=4},
                new Course{CourseID=3141,Title="Trigonometry",Credits=4},
                new Course{CourseID=2021,Title="Composition",Credits=3},
                new Course{CourseID=2042,Title="Literature",Credits=4}
            }; */

            /* ctx.courses.AddRange(courses);
            ctx.SaveChanges(); */

            /* var enrollments = new Enrollment[]
            {
                new Enrollment{StudentID=1,CourseID=1050,Grade=Grade.A},
                new Enrollment{StudentID=1,CourseID=4022,Grade=Grade.C},
                new Enrollment{StudentID=1,CourseID=4041,Grade=Grade.B},
                new Enrollment{StudentID=2,CourseID=1045,Grade=Grade.B},
                new Enrollment{StudentID=2,CourseID=3141,Grade=Grade.F},
                new Enrollment{StudentID=2,CourseID=2021,Grade=Grade.F},
                new Enrollment{StudentID=3,CourseID=1050},
                new Enrollment{StudentID=4,CourseID=1050},
                new Enrollment{StudentID=4,CourseID=4022,Grade=Grade.F},
                new Enrollment{StudentID=5,CourseID=4041,Grade=Grade.C},
                new Enrollment{StudentID=6,CourseID=1045},
                new Enrollment{StudentID=7,CourseID=3141,Grade=Grade.A},
            }; */

            /* ctx.enrollments.AddRange(enrollments);
            ctx.SaveChanges(); */
        }
    }
}