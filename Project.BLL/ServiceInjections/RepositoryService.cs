using Microsoft.Extensions.DependencyInjection;
using Project.DAL.Repositories.Abstracts;
using Project.DAL.Repositories.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.ServiceInjections
{
    public static class RepositoryService
    {
        
        public static IServiceCollection AddRepServices(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>)); //IRepository'i generic içerisinde yazamıyoruz çünkü onlar full generic sınıf. O yüzden bu şekilde yazıyoruz. 

            services.AddScoped<ICategoryRepository, CategoryRepository>(); //ICategoryRepository'i constructor'da bu tipi gördüğün zaman ona CategoryRepository tipi gönder böylece ben o interface'i aldığım anda elime CategoryRepository instance'i geçsin o interface'de dursun

            services.AddScoped<IProductRepository, ProductRepository>();

            services.AddScoped<IOrderRepository, OrderRepository>();

            services.AddScoped<IOrderDetailRepository, OrderDetailRepository>();

            services.AddScoped<IAppUserRepository, AppUserRepository>();

            services.AddScoped<IProfileRepository, ProfileRepository>();

            return services; //ondan sonra servisleri entegre et..

            // IOC => Dependecy Injection algoritmasının yazılması (.NET uygulamalarında bağımlılıkların dışarıdan enjekte edildiği ve kontrolün bileşenler arasında tersine çevrildiği bir tasarım prensibidir, bu da yazılımın daha esnek ve sürdürülebilir olmasını sağlar.) 

            //Yukaridaki sistem bir IOC (Inversion of Controls) sistemidir. Yani bu tarz kontrollerin yapılması için bir çevre oluşturmak demektir. (Ben bunu diyorum sen bundan instance al..) 
        }
    }
}
