using Bogus.DataSets;
using Microsoft.EntityFrameworkCore;
using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAL.Extensions   
{
    public static class CategoryDataSeedExtension
    {
        public static void SeedCategories(ModelBuilder modelBuilder) //SeedCategories metodu, ModelBuilder nesnesi üzerinde çalışacak ve veritabanına varsayılan kategori verilerini ekleyecek bir metottur. ModelBuilder parametresi, EF Core tarafından sağlanan ve veritabanı modelini oluşturmak veya değiştirmek için kullanılan yapısal bir nesnedir.
        {
            List<Category> categories = new();

            for (int i = 1; i < 11; i++)
            {
                Category c = new()
                {
                    ID = i,
                    CategoryName = new Commerce("tr").Categories(1)[0], //Rastgele ürün kategorilerinden oluşan bir koleksiyon döndürüyor. (1) tane ekle [0] başlangıç indexi.
                    Description = new Lorem("tr").Sentences(10) //10 cümlelik açıklama
                };

                categories.Add(c); //Bu kısım, Category sınıfından oluşan bir liste (categories) oluşturur ve bu listede 1'den 10'a kadar olan ID'lere sahip kategori nesneleri ekler. Her bir kategori nesnesi, rasgele olarak Türkçe kategori ismi (CategoryName) ve 10 cümlelik rasgele bir Türkçe açıklama (Description) ile oluşturulur. Commerce ve Lorem sınıfları, Bogus kütüphanesi tarafından sağlanan ve rasgele veri oluşturma işlevleri sunan sınıflardır.
            }

            modelBuilder.Entity<Category>().HasData(categories);  //modelBuilder.Entity<Category>() ifadesi, EF Core ile Category sınıfının veritabanı tablosunu temsil eden bir nesneyi alır. HasData metodu ise, parametre olarak aldığı categories listesindeki verileri veritabanına eklemek için kullanılır. Bu şekilde, veritabanında uygulama başlatıldığında veya veritabanı oluşturulduğunda bu kategoriler otomatik olarak eklenir.
        }
    }
}
