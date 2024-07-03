using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Project.DAL.ContextClasses;
using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.ServiceInjections
{
    public static class CustomIdentityService
    {
        //Kimlik doğrulama ve yetkilendirme işlemlerini yapılandırmak için açıldı
        public static IServiceCollection AddIdentityService(this IServiceCollection services)  //AddIdentityService genişletme metodu, IServiceCollection türündeki services nesnesini alır ve bu nesneye kimlik yönetimi hizmetlerini eklemek için yapılandırma işlemlerini gerçekleştirir. Bu metod, genellikle Startup.cs sınıfında ConfigureServices metodu içinde kullanılır.

        {
            //services.AddIdentity<AppUser, IdentityRole<int>>(x => { ... Bu satırda, services nesnesine kimlik doğrulama ve yetkilendirme ayarlarını yapılandırmak için AddIdentity metodu çağrılır.AppUser türü, uygulamanın kullanıcı modelini temsil eder. IdentityRole<int> ise rol kimliklendiricilerini temsil eder, burada int türünde kimlik tanımlayıcı kullanıldığı belirtilir. (AddIdentity'nin gelmesi için FluentValidation.AspNetcore kütüphanesini indirin.)
            services.AddIdentity<AppUser, IdentityRole<int>>(x =>   
            {
                x.Password.RequireDigit = false; //Şifrelerin rakam içermesi gerekip gerekmediğini belirtir.
                x.Password.RequiredLength = 3; //Şifrelerin minimum uzunluğunu belirtir.
                x.Password.RequireUppercase = false; //Şifrelerin büyük harf içermesi gerekip gerekmediğini belirtir.
                x.Password.RequireLowercase = false; //Şifrelerin küçük harf içermesi gerekip gerekmediğini belirtir.
                x.SignIn.RequireConfirmedEmail = true; //Kullanıcı girişlerinde doğrulanmış e-posta gerekip gerekmediğini belirtir.
                x.Password.RequireNonAlphanumeric = false; //Şifrelerin alfasayısal olmayan karakter içermesi gerekip gerekmediğini belirtir.
                x.User.RequireUniqueEmail = true; //Kullanıcıların benzersiz e-posta adresine sahip olması gerekip gerekmediğini belirtir.
                
            }).AddDefaultTokenProviders().AddEntityFrameworkStores<MyContext>();

            return services;

            // AddDefaultTokenProviders() metodu, kimlik doğrulama işlemlerinde kullanılan varsayılan token sağlayıcılarını ekler. (EmailTokenProvider, PhoneNumberTokenProvider gibi) 

            //AddEntityFrameworkStores<MyContext>() metodu, kimlik bilgilerinin saklandığı veritabanını belirtir. MyContext türü, uygulamanın kullanılacak veritabanı bağlamını temsil eder.
        }

    }
}
