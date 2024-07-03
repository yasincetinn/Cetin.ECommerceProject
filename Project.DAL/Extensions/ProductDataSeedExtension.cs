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
    public static class ProductDataSeedExtension
    {
        public static void SeedProducts(ModelBuilder modelBuilder)
        {
            List<Product> products = new();

            for (int i = 1; i < 11; i++)
            {
                Product p = new()
                {

                    ID = i,
                    ProductName = new Commerce("tr").ProductName(),
                    UnitPrice = Convert.ToDecimal(new Commerce("tr").Price()),
                    UnitsInStock = 100,
                    CategoryID = i,
                    ImagePath = new Images().Nightlife()
                };
                products.Add(p);   //Bu kısımda, Product sınıfından oluşan bir liste (products) oluşturulur ve bu listede 1'den 10'a kadar olan ID'lere sahip ürün nesneleri eklenir. Her bir ürün nesnesi, rasgele olarak Türkçe ürün adı (ProductName), Türkçe fiyat (UnitPrice), stok miktarı (UnitsInStock), kategori ID'si (CategoryID) ve bir resim yolu (ImagePath) ile oluşturulur.
            }

            modelBuilder.Entity<Product>().HasData(products);
        }
    }
}
