using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAL.Repositories.Abstracts
{
    //Interface segregation principle: Bir sınıfın tüm işlemlerini tek bir arayüze yüklemek yerine, ihtiyaçlara göre birden çok arayüz oluşturmalıyız. Bu yüzden hepsine ayrı ayrı interface açtık
    public interface IAppUserRepository : IRepository<AppUser>
    {
        
    }
}
