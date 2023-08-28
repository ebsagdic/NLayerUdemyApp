using Microsoft.EntityFrameworkCore;
using NLayer.Core;
using NLayer.Repository.Configurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Repository
{
    public class AppDbContext:DbContext
    //DbContext Ef core tarafından sağlanan veritabanı işlemlerini yönetmeye yarayan
    //temel bir sınıftır.
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            //bu method AppDbContext sınıfının yapıcı metodudur
        }

        public DbSet<Category> Categories { get; set; }
        //DbSet EF Core'da bir veritabanı tablosunu temsil eden
        //ve sorgulamalar yapmamızı sağlayan bir yapıdır.

        public DbSet<Product> Products { get; set; }

        public DbSet<ProductFeature> ProductFeatures { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            //Çalışmış olduğum tüm assemblyler bu metod ile çalışır ,
            //eğer tek tek seçmek istiyorsak
            //modelBuilder.ApplyConfiguration(new ProductConfiguration());

            modelBuilder.Entity<ProductFeature>().HasData(new ProductFeature()
            {
                Id = 1,
                Color = "Kırmızı",
                Height = 200,
                Width = 100,
                ProductId = 1,
            }, 
            new ProductFeature()
            {
                Id = 2,
                Color = "Mavi",
                Height = 70,
                Width = 400,
                ProductId = 2,
            });



            base.OnModelCreating(modelBuilder);
        }
    }


}
