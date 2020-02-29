using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PdrAutomate.WebUI.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PdrAutomate.WebUI.DataAccess.Concrete.EntityFramework
{
    public static class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            var context = app.ApplicationServices.GetRequiredService<PdrAutomateContext>();

            context.Database.Migrate();
            if (!context.Students.Any())
            {
                var Classes = new[]
                {
                    new Class()
                    {
                        ClassName="10A",
                        ClassCapacity=20
                    },
                    new Class()
                    {
                        ClassName="10B",
                        ClassCapacity=20
                    },
                };
                context.AddRange(Classes);

                var Presentations = new[]
                {
                    new Presentation()
                    {
                        PresentationName="Bilgisayar",
                    },
                    new Presentation()
                    {
                        PresentationName="Kimya",
                    },
                };
                context.AddRange(Presentations);

                var Sessions = new[]
                {
                    new Sessions()
                    {
                        StartTime=new DateTime(2020,02,02,9,0,0),
                        EndTime =new DateTime(2020,02,02,9,0,0)
                    },
                    new Sessions()
                    {
                        StartTime=new DateTime(2020,02,02,10,0,0),
                        EndTime =new DateTime(2020,02,02,11,0,0)
                    },
                };
                context.AddRange(Sessions);

                var Students = new[]
                {
                    new Student()
                    {
                        StudentName="Seyfi",
                        StudentSurname="Zeyrek",
                        StudentSchoolId="55",
                        Password="seyf1903",
                        Class=Classes[0]
                    }
                };
                context.AddRange(Sessions);

                var PresentationSessions = new[]
                {
                    new PresentationSession()
                    {
                        Presentation=Presentations[0],
                        Sessions=Sessions[0]
                    },
                    new PresentationSession()
                    {
                        Presentation=Presentations[0],
                        Sessions=Sessions[1]
                    },
                    new PresentationSession()
                    {
                        Presentation=Presentations[1],
                        Sessions=Sessions[0]
                    },
                    new PresentationSession()
                    {
                        Presentation=Presentations[1],
                        Sessions=Sessions[1]
                    },

                };
                context.AddRange(PresentationSessions);

                var ClassPresentationSession = new[]
                {
                    new ClassPresentationsession()
                    {
                        Class=Classes[0],
                        Presentation=Presentations[0],
                        Sessions=Sessions[0],
                        CurrentCapacity=0
                    },
                    new ClassPresentationsession()
                    {
                        Class=Classes[0],
                        Presentation=Presentations[1],
                        Sessions=Sessions[1],
                        CurrentCapacity=0

                    },
                    new ClassPresentationsession()
                    {
                        Class=Classes[1],
                        Presentation=Presentations[0],
                        Sessions=Sessions[1],
                        CurrentCapacity=0
                    },
                    new ClassPresentationsession()
                    {
                        Class=Classes[1],
                        Presentation=Presentations[1],
                        Sessions=Sessions[0],
                        CurrentCapacity=0
                    },
                };

                context.AddRange(ClassPresentationSession);

                var StudentPresentationSessions = new[]
                {
                    new StudentPresentationsession()
                    {
                        Student=Students[0],
                        Presentation=Presentations[0],
                        Sessions=Sessions[0]
                    }
                };
                context.AddRange(StudentPresentationSessions);
                context.SaveChanges();
            }
        }
    }
}
