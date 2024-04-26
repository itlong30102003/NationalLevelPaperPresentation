using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace NationalLevelPaperPresentation.Models
{
    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<Activity> Activities { get; set; }
        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<Participant> Participants { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Activity>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<Activity>()
                .Property(e => e.eligibility)
                .IsUnicode(false);

            modelBuilder.Entity<Activity>()
                .Property(e => e.prize_details)
                .IsUnicode(false);

            modelBuilder.Entity<Activity>()
                .Property(e => e.address)
                .IsUnicode(false);

            modelBuilder.Entity<Activity>()
                .Property(e => e.terms_and_conditions)
                .IsUnicode(false);

            modelBuilder.Entity<Activity>()
                .HasMany(e => e.Participants)
                .WithMany(e => e.Activities)
                .Map(m => m.ToTable("Participant_Activity").MapLeftKey("activity_id").MapRightKey("participant_id"));

            modelBuilder.Entity<Admin>()
                .Property(e => e.UserName)
                .IsUnicode(false);

            modelBuilder.Entity<Admin>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<Participant>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<Participant>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<Participant>()
                .HasMany(e => e.Users)
                .WithMany(e => e.Participants)
                .Map(m => m.ToTable("User_Participant").MapLeftKey("participant_id").MapRightKey("user_id"));

            modelBuilder.Entity<User>()
                .Property(e => e.username)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.password)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.email)
                .IsUnicode(false);
        }
    }
}
