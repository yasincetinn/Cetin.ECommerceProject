using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAL.Extensions
{

    //Parametre neden this keywordu almadı ?
    //
    //Çünkü Identity'e artık veri ekleme olayı girdi. Identity'nin özel olarak tetiklenmesini istiyoruz. Identity'nin tetiklenmesi için kendi kafamıza göre exten edemeyiz bir metodu class içerisine (kütüphane var). Biz MyContext class'ı içerisinde builder.Seed(); Dersek Identity bunun manuel olarak müdahale edildiğini anlar(c# tarafında). O yüzden biz bunu ModelBuilder'e gömmektense biz bunun normal static olarak çalışmasını istedik ve parametre olarak düz bir şekilde ModelBuilder verip extension olmasını istemedik. (Kısaca this kullanmayı sağlıklı bulmuyoruz)


    public static class UserRoleDataSeedExtension
    {
        public static void SeedUsers(ModelBuilder modelBuilder)
        {
            IdentityRole<int> appRole = new()
            {
                Id = 1,
                Name = "Admin",
                NormalizedName = "ADMIN",
                ConcurrencyStamp = Guid.NewGuid().ToString() //Bu ifade sisteminizin yeni bir Guid yaratmasını sağlar
            };

            //Guid dediğimiz yapı benzersiz bir hashleme sistemidir. Sizin bilgisayarınızın işletim sistemini, Mac adresini, o anki sistem tarihini alır bu bir algoritamaya girerek işletim sisteminize göre 36 veya 48 karakterlik bir şifreleme oluşturur. Bir kez oluşturulan Guid bir kez daha taklit edilemez.

            modelBuilder.Entity<IdentityRole<int>>().HasData(appRole);

            PasswordHasher<AppUser> passwordHasher = new();


            AppUser user = new()
            {
                Id = 1,
                UserName = "yasn33",
                Email = "yasncetn8990@outlook.com",
                NormalizedEmail = "YASNCETN8990@OUTLOOK.COM",
                NormalizedUserName = "YASN33",
                EmailConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString(),
                PasswordHash = passwordHasher.HashPassword(null, "yasn33")
            };

            modelBuilder.Entity<AppUser>().HasData(user);

            modelBuilder.Entity<IdentityUserRole<int>>().HasData(new IdentityUserRole<int>
            {
                RoleId = appRole.Id,
                UserId = user.Id
            });
        }
    }
}
