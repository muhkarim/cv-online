using CVOnline.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CVOnline.Context
{
    public class MyContext : DbContext 
    {
        public MyContext(DbContextOptions<MyContext> options) : base(options) { }

        public DbSet<Job> Jobs { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Applicant> Applicants { get; set; }
        public DbSet<Biodata> Biodatas { get; set; }
        public DbSet<Document> Documents { get; set; }
        public DbSet<EducationalDetails> EducationalDetails { get; set; }
        public DbSet<UserRequest> UserRequests { get; set; }
        public DbSet<WorkExperience> WorkExperiences { get; set; }
        public DbSet<RequestApplication> RequestApplications { get; set; }
        public DbSet<UserRole> UserRole { get; set; }
        public DbSet<Admin> Admins { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Write Fluent API configurations here
            modelBuilder.Entity<UserRole>().HasKey(x => new { x.User_Id, x.Role_Id });

            modelBuilder.Entity<UserRole>()
                .HasOne(x => x.User)
                .WithMany(x => x.UserRoles)
                .HasForeignKey(x => x.User_Id);

            modelBuilder.Entity<UserRole>()
                .HasOne(x => x.Role)
                .WithMany(x => x.UserRoles)
                .HasForeignKey(x => x.Role_Id);

            // 1 only 1 applicant : document
            modelBuilder.Entity<Applicant>()
                .HasOne<Document>(x => x.Document)
                .WithOne(x => x.Applicant)
                .HasForeignKey<Applicant>(x => x.Document_Id);

            // 1 only 1 applicant : education
            modelBuilder.Entity<Applicant>()
                .HasOne<EducationalDetails>(x => x.EducationalDetails)
                .WithOne(x => x.Applicant)
                .HasForeignKey<Applicant>(x => x.EducationalDetails_Id);

            //1 only 1 applicant: biodata
            modelBuilder.Entity<Applicant>()
                .HasOne<Biodata>(x => x.Biodata)
                .WithOne(x => x.Applicant)
                .HasForeignKey<Applicant>(x => x.Biodata_Id);

            //1:1 Applicant : User
            modelBuilder.Entity<Applicant>()
                .HasOne<User>(x => x.User)
                .WithOne(x => x.Applicant)
                .HasForeignKey<Applicant>(x => x.User_Id);

            //1:1 Admin : User
            modelBuilder.Entity<Admin>()
                .HasOne<User>(x => x.User)
                .WithOne(x => x.Admin)
                .HasForeignKey<Admin>(x => x.User_Id);

            modelBuilder.Entity<UserRequest>().HasKey(x => new { x.Applicants_Id, x.RequestApplication_Id });
            modelBuilder.Entity<UserRequest>()
                .HasOne(x => x.Applicant)
                .WithMany(x => x.UserRequests)
                .HasForeignKey(x => x.Applicants_Id);

            // 1 to Many Request : List
            modelBuilder.Entity<UserRequest>()
                .HasOne(x => x.RequestApplication)
                .WithMany(x => x.UserRequests)
                .HasForeignKey(x => x.RequestApplication_Id);

            modelBuilder.Entity<Applicant>()
                .HasOne<WorkExperience>(x => x.WorkExperience)
                .WithOne(x => x.Applicant)
                .HasForeignKey<Applicant>(x => x.WorkExperience_Id);

        }
    }
}
