using System;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace RazorMVC.Models
{
    public class AVGContext : DbContext
    {
        public DbSet<Video> Videos { get; set; }
        public DbSet<Picture> Pictures { get; set; }
        public DbSet<Service> Services { get; set; }
        public AVGContext(DbContextOptions<AVGContext> options) : base(options)
        {
        }

        //  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //  {
        //      optionsBuilder.UseNpgsql("User ID=postgres;Password=Project;Host=localhost;Port=5432;Database=AVGDB;Pooling=true;");
        //  }
    }

    public class Video
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Title is required")]
        [StringLength(3)]
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public string Path { get; set; }
    }

    public class Picture
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public string Path { get; set; }
    }

    public class Service
    {
        public int ID { get; set; }
        public string service { get; set; }
        public DateTime AvailableDate { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string PicPath { get; set; }
        public string VideoPath { get; set; }
    }
}