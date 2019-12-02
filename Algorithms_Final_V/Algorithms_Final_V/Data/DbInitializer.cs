using Algorithms_Final_V.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Algorithms_Final_V.Data
{
    public class DbInitializer
    {
        public static void Initialize(FactionContext context)
        {
            //context.Database.EnsureCreated();

            // Look for any students.
            if (context.Initiates.Any())
            {
                return;   // DB has been seeded
            }

            var initiates = new Initiate[]
            {
                new Initiate { FirstMidName = "Carson",   LastName = "Alexander",
                    EnrollmentDate = DateTime.Parse("2016-09-01") },
                new Initiate { FirstMidName = "Meredith", LastName = "Alonso",
                    EnrollmentDate = DateTime.Parse("2018-09-01") },
                new Initiate { FirstMidName = "Arturo",   LastName = "Anand",
                    EnrollmentDate = DateTime.Parse("2019-09-01") },
                new Initiate { FirstMidName = "Gytis",    LastName = "Barzdukas",
                    EnrollmentDate = DateTime.Parse("2018-09-01") },
                new Initiate { FirstMidName = "Yan",      LastName = "Li",
                    EnrollmentDate = DateTime.Parse("2018-09-01") },
                new Initiate { FirstMidName = "Peggy",    LastName = "Justice",
                    EnrollmentDate = DateTime.Parse("2017-09-01") },
                new Initiate { FirstMidName = "Laura",    LastName = "Norman",
                    EnrollmentDate = DateTime.Parse("2019-09-01") },
                new Initiate { FirstMidName = "Nino",     LastName = "Olivetto",
                    EnrollmentDate = DateTime.Parse("2011-09-01") }
            };

            foreach (Initiate s in initiates)
            {
                context.Initiates.Add(s);
            }
            context.SaveChanges();

            var officers = new Officer[]
            {
                new Officer { FirstMidName = "Kim",     LastName = "Abercrombie",
                    HireDate = DateTime.Parse("1995-03-11") },
                new Officer { FirstMidName = "Fadi",    LastName = "Fakhouri",
                    HireDate = DateTime.Parse("2002-07-06") },
                new Officer { FirstMidName = "Roger",   LastName = "Harui",
                    HireDate = DateTime.Parse("1998-07-01") },
                new Officer { FirstMidName = "Candace", LastName = "Kapoor",
                    HireDate = DateTime.Parse("2001-01-15") },
                new Officer { FirstMidName = "Roger",   LastName = "Zheng",
                    HireDate = DateTime.Parse("2004-02-12") }
            };

            foreach (Officer i in officers)
            {
                context.Officers.Add(i);
            }
            context.SaveChanges();

            var departments = new Department[]
            {
                new Department { Name = "English",     Budget = 350000,
                    StartDate = DateTime.Parse("2007-09-01"),
                    InstructorID  = officers.Single( i => i.LastName == "Abercrombie").ID },
                new Department { Name = "Mathematics", Budget = 100000,
                    StartDate = DateTime.Parse("2007-09-01"),
                    InstructorID  = officers.Single( i => i.LastName == "Fakhouri").ID },
                new Department { Name = "Engineering", Budget = 350000,
                    StartDate = DateTime.Parse("2007-09-01"),
                    InstructorID  = officers.Single( i => i.LastName == "Harui").ID },
                new Department { Name = "Economics",   Budget = 100000,
                    StartDate = DateTime.Parse("2007-09-01"),
                    InstructorID  = officers.Single( i => i.LastName == "Kapoor").ID }
            };

            foreach (Department d in departments)
            {
                context.Departments.Add(d);
            }
            context.SaveChanges();

            var roles = new Role[]
            {
                new Role {RoleID = 1050, Title = "Chemistry",      Credits = 3,
                    DepartmentID = departments.Single( s => s.Name == "Engineering").DepartmentID
                },
                new Role {RoleID = 4022, Title = "Microeconomics", Credits = 3,
                    DepartmentID = departments.Single( s => s.Name == "Economics").DepartmentID
                },
                new Role {RoleID = 4041, Title = "Macroeconomics", Credits = 3,
                    DepartmentID = departments.Single( s => s.Name == "Economics").DepartmentID
                },
                new Role {RoleID = 1045, Title = "Calculus",       Credits = 4,
                    DepartmentID = departments.Single( s => s.Name == "Mathematics").DepartmentID
                },
                new Role {RoleID = 3141, Title = "Trigonometry",   Credits = 4,
                    DepartmentID = departments.Single( s => s.Name == "Mathematics").DepartmentID
                },
                new Role {RoleID = 2021, Title = "Composition",    Credits = 3,
                    DepartmentID = departments.Single( s => s.Name == "English").DepartmentID
                },
                new Role {RoleID = 2042, Title = "Literature",     Credits = 4,
                    DepartmentID = departments.Single( s => s.Name == "English").DepartmentID
                },
            };

            foreach (Role c in roles)
            {
                context.Roles.Add(c);
            }
            context.SaveChanges();

            var stationedLocation = new StationedLocation[]
            {
                new StationedLocation {
                    InstructorID = officers.Single( i => i.LastName == "Fakhouri").ID,
                    Location = "Smith 17" },
                new StationedLocation {
                    InstructorID = officers.Single( i => i.LastName == "Harui").ID,
                    Location = "Gowan 27" },
                new StationedLocation {
                    InstructorID = officers.Single( i => i.LastName == "Kapoor").ID,
                    Location = "Thompson 304" },
            };

            foreach (StationedLocation o in stationedLocation)
            {
                context.StationedLocations.Add(o);
            }
            context.SaveChanges();

            var roleOfficers = new RoleAssignment[]
            {
                new RoleAssignment {
                    RoleID = roles.Single(c => c.Title == "Chemistry" ).RoleID,
                    OfficerID = officers.Single(i => i.LastName == "Kapoor").ID
                    },
                new RoleAssignment {
                    RoleID = roles.Single(c => c.Title == "Chemistry" ).RoleID,
                    OfficerID = officers.Single(i => i.LastName == "Harui").ID
                    },
                new RoleAssignment {
                    RoleID = roles.Single(c => c.Title == "Microeconomics" ).RoleID,
                    OfficerID = officers.Single(i => i.LastName == "Zheng").ID
                    },
                new RoleAssignment {
                    RoleID = roles.Single(c => c.Title == "Macroeconomics" ).RoleID,
                    OfficerID = officers.Single(i => i.LastName == "Zheng").ID
                    },
                new RoleAssignment {
                    RoleID = roles.Single(c => c.Title == "Calculus" ).RoleID,
                    OfficerID = officers.Single(i => i.LastName == "Fakhouri").ID
                    },
                new RoleAssignment {
                    RoleID = roles.Single(c => c.Title == "Trigonometry" ).RoleID,
                    OfficerID = officers.Single(i => i.LastName == "Harui").ID
                    },
                new RoleAssignment {
                    RoleID = roles.Single(c => c.Title == "Composition" ).RoleID,
                    OfficerID = officers.Single(i => i.LastName == "Abercrombie").ID
                    },
                new RoleAssignment {
                    RoleID = roles.Single(c => c.Title == "Literature" ).RoleID,
                    OfficerID = officers.Single(i => i.LastName == "Abercrombie").ID
                    },
            };

            foreach (RoleAssignment ci in roleOfficers)
            {
                context.RoleAssignments.Add(ci);
            }
            context.SaveChanges();

            var enrollments = new Enrollment[]
            {
                new Enrollment {
                    InitiateID = initiates.Single(s => s.LastName == "Alexander").ID,
                    RoleID = roles.Single(c => c.Title == "Chemistry" ).RoleID,
                    Grade = Grade.A
                },
                    new Enrollment {
                    InitiateID = initiates.Single(s => s.LastName == "Alexander").ID,
                    RoleID = roles.Single(c => c.Title == "Microeconomics" ).RoleID,
                    Grade = Grade.C
                    },
                    new Enrollment {
                    InitiateID = initiates.Single(s => s.LastName == "Alexander").ID,
                    RoleID = roles.Single(c => c.Title == "Macroeconomics" ).RoleID,
                    Grade = Grade.B
                    },
                    new Enrollment {
                        InitiateID= initiates.Single(s => s.LastName == "Alonso").ID,
                    RoleID = roles.Single(c => c.Title == "Calculus" ).RoleID,
                    Grade = Grade.B
                    },
                    new Enrollment {
                        InitiateID = initiates.Single(s => s.LastName == "Alonso").ID,
                    RoleID = roles.Single(c => c.Title == "Trigonometry" ).RoleID,
                    Grade = Grade.B
                    },
                    new Enrollment {
                    InitiateID = initiates.Single(s => s.LastName == "Alonso").ID,
                    RoleID = roles.Single(c => c.Title == "Composition" ).RoleID,
                    Grade = Grade.B
                    },
                    new Enrollment {
                    InitiateID = initiates.Single(s => s.LastName == "Anand").ID,
                    RoleID = roles.Single(c => c.Title == "Chemistry" ).RoleID
                    },
                    new Enrollment {
                    InitiateID = initiates.Single(s => s.LastName == "Anand").ID,
                    RoleID = roles.Single(c => c.Title == "Microeconomics").RoleID,
                    Grade = Grade.B
                    },
                new Enrollment {
                    InitiateID = initiates.Single(s => s.LastName == "Barzdukas").ID,
                    RoleID = roles.Single(c => c.Title == "Chemistry").RoleID,
                    Grade = Grade.B
                    },
                    new Enrollment {
                    InitiateID = initiates.Single(s => s.LastName == "Li").ID,
                    RoleID = roles.Single(c => c.Title == "Composition").RoleID,
                    Grade = Grade.B
                    },
                    new Enrollment {
                    InitiateID = initiates.Single(s => s.LastName == "Justice").ID,
                    RoleID = roles.Single(c => c.Title == "Literature").RoleID,
                    Grade = Grade.B
                    }
            };

            foreach (Enrollment e in enrollments)
            {
                var enrollmentInDataBase = context.Enrollments.Where(
                    s =>
                            s.Initiate.ID == e.InitiateID &&
                            s.Role.RoleID == e.RoleID).SingleOrDefault();
                if (enrollmentInDataBase == null)
                {
                    context.Enrollments.Add(e);
                }
            }
            context.SaveChanges();
        }
    }
}

