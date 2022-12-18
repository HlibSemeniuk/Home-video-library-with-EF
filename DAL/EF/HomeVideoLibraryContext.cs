using DAL.Entitys;
using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;

namespace DAL.EF
{
    public class HomeVideoLibraryContext : DbContext
    {
        public DbSet<Film> Films { get; set; }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<Director> Directors { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Review> Reviews { get; set; }

        public HomeVideoLibraryContext()
            : base("name=HomeVideoLibraryContext")
        {
            Database.SetInitializer<HomeVideoLibraryContext>(new HomeVideoLibraryDbInitializer());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }

    public class HomeVideoLibraryDbInitializer : DropCreateDatabaseIfModelChanges<HomeVideoLibraryContext>
    {
        protected override void Seed(HomeVideoLibraryContext context)
        {
            context.Actors.Add(new Actor() { Name = "������ �����", Birthdate = new DateTime(1990, 03, 17), Country = "������ �������", Description = "�� ���� ������ � Saint Maud ���� ���� ��������� �� �������� ����� ���� ���������� ��������� ������쳿 �� ���쳿 BAFTA Rising Star." });
            context.Films.Add(new Film() { Name = "������� ������: ����� �����", ReleaseDate = new DateTime(2022, 09, 01), Country = "���", Budget = 465000000});

            context.SaveChanges();
        }
    }


}