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
                var Students = new[]{
                    new Student(){StudentSchoolId = "2015510076",Password = "123"}
                };

                context.Students.AddRange(Students);


                var Classes = new[]
                {
                new Class(){ClassName="9A",ClassCapacity=30}
                };

                context.Classes.AddRange(Classes);

                var StudentClass = new[]
                {
                new StudentClass(){Class=Classes[0],Student=Students[0]}
                };

                context.AddRange(StudentClass);

                var Presentations = new[]
                {
                    new Presentation(){PresentationName="Bilgisayar"},
                    new Presentation(){PresentationName="Kimya"}
                };
                context.AddRange(Presentations);

                var PresentationClass = new[]
                {
                    new PresentationClass(){Class=Classes[0],Presentation=Presentations[0],CurrentCapacity=0,Section=0},
                    new PresentationClass(){Class=Classes[0],Presentation=Presentations[1],CurrentCapacity=0,Section=1}
                };
                context.AddRange(PresentationClass);

                var StudentPresentations = new[]
                {
                    new StudentPresentation(){Student=Students[0],Presentation=Presentations[0]}
                };
                context.AddRange(StudentPresentations);

                context.SaveChanges();
            }
        }
    }

}
