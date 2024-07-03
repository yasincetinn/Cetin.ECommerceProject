using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Project.DAL.ContextClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.ServiceInjections
{ 
    //Bu class'ın amacı Context sınıfının middleware'e nasıl göndereceğini tespit etmektir. 

    public static class DbContextService
    {
        //ServiceInjection'lar neden BLL katmanı içerisinde? Neden DAL katmanında değil? Neden program.cs'e direkt yazılmadı ?

        // 1) Kompakt bir yapı. Bir sorumluluğu ne kadar single (tekil) tutarsak o kadar rahat ederiz. Burada Identity ile ilgili hiç bir service yapmıyoruz (DbContextService). Hata çıkarsa direkt burayla ilgileniriz. Yönetim kolaylığı sağlar.

        // 2) Kod temizliği. Program cs'de bir çok service'in inject edildiğini görmek projenin kod temizliği öldürür. 

        // 3) Bizim injectionlarımız UI katmanı tarafından bilinmesi gerek. Bu yüzden DAL'da olursa UI, BLL katmanını baypas edip Dal'a ulaşıyor demektir.     


        //DbContextPool'umuz böylece Startup'da Dal'dan bir sınıfı kullanmaktan ziyade sadece BLL'deki bu yaratılmış olan class'ın kurallarıyla bir Service entegrasyonu yapacaktır.
        public static IServiceCollection AddDbContextService(this IServiceCollection services)
        {
            //Neden ServiceProvider
            //Çünkü biz bu noktada aslında bir Core.MVC platformundaki startup dosyasında değiliz. Dolayısıyla startupdaki hazır service elimizde yok. Biz o yapıları ayağa kaldırmak adına bir giriş noktasına ihtiyaç duyarız ve bu giriş noktasını bana ServiceProvider nesnesi sağlar. 

            ServiceProvider provider = services.BuildServiceProvider();


            //Sakın IConfiguration kullanırken Castle kütüphanesini kullanmayın.. Kullanacağınız kütüphane Microsoft.Extensions.Configuration olmak zorundadır.

            //IConfiguration sayesinde projenizin conf.(ayarlamalarının) bulunduğu dosyaya ulaşabiliyorsunuz. 
            
            IConfiguration? configuration = provider.GetService<IConfiguration>();

            services.AddDbContextPool<MyContext>(opt => opt.UseSqlServer(configuration.GetConnectionString("MyConnection")).UseLazyLoadingProxies());

            return services;

        }

    }
}
