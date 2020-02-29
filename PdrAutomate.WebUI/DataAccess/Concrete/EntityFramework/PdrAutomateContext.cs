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

        public DbSet<Class> Classes { get; set; }
        public DbSet<ClassPresentationsession> ClassPresentationsessions {get;set;}
        public DbSet<Presentation> Presentations { get; set; }
        public DbSet<PresentationSession> PresentationSessions { get; set; }
        public DbSet<Sessions> Sessions { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<StudentPresentationsession> StudentPresentationsessions { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Sessions>()
                .HasKey(pc => new { pc.SessionId});
            modelBuilder.Entity<ClassPresentationsession>()
                .HasKey(pc => new { pc.ClassId,pc.PresentationId,pc.SessionId});
            modelBuilder.Entity<PresentationSession>()
                .HasKey(sc => new { sc.PresentationID,sc.SessionId});
            modelBuilder.Entity<StudentPresentationsession>()
                .HasKey(pc => new { pc.StudentId, pc.PresentationId,pc.SessionId });
        }
    }
}
