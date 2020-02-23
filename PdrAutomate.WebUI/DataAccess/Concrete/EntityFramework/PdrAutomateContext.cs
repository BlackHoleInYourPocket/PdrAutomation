using Microsoft.EntityFrameworkCore;
using PdrAutomate.WebUI.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PdrAutomate.WebUI.DataAccess.Concrete.EntityFramework
{
    public class PdrAutomateContext : DbContext
    {
        public PdrAutomateContext(DbContextOptions<PdrAutomateContext> options) : base(options)
        {

        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Presentation> Presentations { get; set; }
        public DbSet<Class> Classes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PresentationClass>()
                .HasKey(pc => new { pc.PresentationId, pc.ClassId });
            modelBuilder.Entity<StudentClass>()
                .HasKey(sc => new { sc.StudentId, sc.ClassId });
            modelBuilder.Entity<StudentPresentation>()
                .HasKey(sp => new { sp.StudentId, sp.PresentationId });


        }
    }
}
