using DAL.Entitys;
using System;
using System.Collections.Generic;
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

        public HomeVideoLibraryContext(string connectionString)
            : base(connectionString)
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
            context.Actors.Add(new Actor() { Name = "Морвед Кларк", Birthdate = new DateTime(1989, 03, 17), Country = "Велика Британія", Description = "За свою роботу в Saint Maud вона була номінована на найкращу жіночу роль Британської незалежної кінопремії та премії BAFTA Rising Star." });
            context.Actors.Add(new Actor() { Name = "Роберт Арамайо", Birthdate = new DateTime(1992, 11, 06), Country = "Велика Британія", Description = "Акторська кар'єра Арамайо почалася у віці семи років, коли він виконав роль Багсі Мелоуна в постановці початкової школи. Коли йому виповнилося десять років, він приєднався до молодіжного театру Халл-трак, де він виступав в трьох п'єсах за рік. Його старша сестра Лора також почала акторську кар'єру в молодіжному театрі Халл-трак і вивчала драму в театральній школі Арден в Манчестері.Він відвідував Вайкський коледж в Халлі та в 2011 році отримав місце в престижній Джульярдській школі в Нью-Йорку. Його виступ в постановці \"Заводного апельсина\" Ентоні Берджесса в ролі Алкса, головного персонажа п'єси, принесло йому першу роль в кіно в італо-американському фільмі \"Турист\".У 2016 році Роберт виконав роль молодого Еддарда Старка в шостому сезоні серіалу HBO \"Гра престолів\"." });
            context.Films.Add(new Film() { Name = "Володар перснів: Персні влади", ReleaseDate = new DateTime(2022, 09, 01), Country = "США", Budget = 465000000});
            context.Films.Add(new Film() { Name = "Хижаки", ReleaseDate = new DateTime(2019, 07, 11), Country = "США", Budget = 17000000 });

            context.SaveChanges();
        }
    }


}