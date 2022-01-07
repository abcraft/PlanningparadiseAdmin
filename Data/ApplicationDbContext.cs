using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PlanningParadiseAdmin.Models;
using System;
using System.Collections.Generic;
using System.Text;
using PlanningParadiseAdmin.ViewModel;

namespace PlanningParadiseAdmin.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ApplicationUser>()
                .Property(e => e.Name)
                .HasMaxLength(250);

            modelBuilder.Entity<ApplicationUser>()
                .Property(e => e.Modified)
                .HasMaxLength(250);
            modelBuilder.Entity<ApplicationUser>()
              .Property(e => e.Created)
              .HasMaxLength(250);
          

        }
        public virtual DbSet<AboutUs> AboutUs { get; set; }
        public virtual DbSet<Home> Home { get; set; }
        public virtual DbSet<Gallery> Gallery { get; set; }
        public virtual DbSet<Banner> Banner { get; set; }
        public virtual DbSet<Testimonial> Testimonials { get; set; }
        public virtual DbSet<WhyChoosUs> WhyChoosUs { get; set; }
        public virtual DbSet<Services> Services { get; set; }
        public virtual DbSet<Team> Team { get; set; }

        public virtual DbSet<DestinationWedding> DestinationWedding { get; set; }
        public virtual DbSet<Blog> Blogs { get; set; }
        public virtual DbSet<FAQ> FAQ { get; set; }
        public virtual DbSet<Slider> Sliders { get; set; }
        public virtual DbSet<WWAImages> WWAImages { get; set; }
        public virtual DbSet<WhyChoosePoints> WhyChoosePoints { get; set; }

    }
}
