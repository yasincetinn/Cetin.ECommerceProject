using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Project.CONF.Configurations;
using Project.DAL.Extensions;
using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAL.ContextClasses
{
     //Buradaki Mycontext class'ımız DbContext'den değil IdentityDbContext'den miras alır. (Identity kullandığımız için). Bu IdentityDbContext identity kütüphanesinden gelir. Biz CONF katmanını referans aldık CONF katmanıda ENTITIES katmanını referans alınca onunla ilgili kütüphanede gelmiş oluyor.

    public class MyContext : IdentityDbContext<AppUser, IdentityRole<int>, int> //Biz AppUser ve IdentityRole'i direkt yazarsak hata verecektir. Bizden TKey'de ister. Biz zaten AppUser'a IdentityUser<int>'den miras verdik. Fakat IdentityRole'ü de burada <int> olarak yazmamız lazım. Diğer gelecek classların keyi int olsun. İnt demezsek sql'de default olarak string alır. (Sadece AppUser'a açıktan müdahele ettiğimiz için onu normal yazdık. 2'den fazla classa müdahale etseydik generic içerisinde hepsini yazmak zorunda kalırdık).  
    {
        public MyContext(DbContextOptions<MyContext> opt) : base(opt) //Middleware'de belirttiğimiz ayarlamayı DbContextOptions<MyContext> tipine gönderdik böylece o ayarlamalar base(opt) yani MyContext'in miras aldığı IdentityDbContext'in constuctor'ina ulaşacak bu sayede bütün sistemimde tanımlı olacak. (Biz crud işlemi yaparken veri tabanına bağlanmak istersek el ile singleton pattern almayacağız.(yani MyContext'imi tekrar instancelamayacağım.)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new AppUserConfiguration());  //Bu satır, AppUser varlığı için belirli bir yapılandırma sınıfı olan AppUserConfiguration'ı kullanarak Entity Framework Core tarafından sağlanan bir ModelBuilder nesnesine yapılandırma bilgileri uygular. Bu yapılandırma, ilgili varlığın (örneğin, kullanıcılar için bir tablonun) veritabanı şemasının nasıl oluşturulacağını belirler.

            builder.ApplyConfiguration(new ProfileConfiguration());

            builder.ApplyConfiguration(new CategoryConfiguration());

            builder.ApplyConfiguration(new ProductConfiguration());

            builder.ApplyConfiguration(new OrderConfiguration());

            builder.ApplyConfiguration(new OrderDetailConfiguration());

            CategoryDataSeedExtension.SeedCategories(builder);

            ProductDataSeedExtension.SeedProducts(builder);

            UserRoleDataSeedExtension.SeedUsers(builder);
            
        }

        public DbSet<AppUser> AppUsers { get; set; }
        //AppUsers DbSet'i, AppUser tipindeki nesnelerin veritabanında AppUsers tablosunda depolanacağını belirtir (Veritabanında AppUsers adında tablo oluşacak). Aşağıdaki class'larda aynı şekilde. 
        public DbSet<AppUserProfile> Profiles { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
    }
}
