using _20191204.Hw.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _20191204.Hw.DataAcces
{
    public class PortfolioContext : DbContext
    {
        public DbSet<AboutMe> AboutMe { get; set; }
        public DbSet<AboutStudy> AboutStudy { get; set; }
        public DbSet<AboutWork> AboutWork { get; set; }
        public DbSet<Project> Projects { get; set; }
        public PortfolioContext(DbContextOptions<PortfolioContext> options)
            : base(options)
        {
            Database.EnsureCreated();
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AboutMe>().HasData(
                new AboutMe[]
                {
                new AboutMe { Paragraph = "Привет! Я какой-то чел"},
                new AboutMe { Paragraph = "Люблю что-то делать, куда-то ходить. Иногда жру и сплю"}
                });

            modelBuilder.Entity<AboutStudy>().HasData(
               new AboutStudy[]
               {
                new AboutStudy { Year = 1999, Text = "Где-то там учился"},
                new AboutStudy { Year = 2004, Text = "Еще раз где-то учился"},
                new AboutStudy { Year = 2010, Text = "Куда-то там поступил"},
                new AboutStudy { Year = 2013, Text = "Устал учиться"},
               });

            modelBuilder.Entity<AboutWork>().HasData(
               new AboutWork[]
               {
                new AboutWork { Year = 2013, Text = "Где-то там работал"},
                new AboutWork { Year = 2015, Text = "Еще раз работал"},
                new AboutWork { Year = 2019, Text = "Всё еще работаю"},
               });

            modelBuilder.Entity<Project>().HasData(
               new Project[]
               {
                new Project { ImagePath = "https://www.optimism.ru/blog/wp-content/uploads/2018/12/514fb1aaa66a524226a1429e1e96ed17.jpg", Text = "Четкий сайт 1"},
                new Project { ImagePath = "https://www.optimism.ru/blog/wp-content/uploads/2018/12/514fb1aaa66a524226a1429e1e96ed17.jpg", Text = "Четкий сайт 2"},
                new Project { ImagePath = "https://www.optimism.ru/blog/wp-content/uploads/2018/12/514fb1aaa66a524226a1429e1e96ed17.jpg", Text = "Четкий сайт 3"},
                new Project { ImagePath = "https://www.optimism.ru/blog/wp-content/uploads/2018/12/514fb1aaa66a524226a1429e1e96ed17.jpg", Text = "Четкий сайт 4"},
                new Project { ImagePath = "https://www.optimism.ru/blog/wp-content/uploads/2018/12/514fb1aaa66a524226a1429e1e96ed17.jpg", Text = "Четкий сайт 5"},
                new Project { ImagePath = "https://www.optimism.ru/blog/wp-content/uploads/2018/12/514fb1aaa66a524226a1429e1e96ed17.jpg", Text = "Четкий сайт 6"}
               });
        }
    }
}
