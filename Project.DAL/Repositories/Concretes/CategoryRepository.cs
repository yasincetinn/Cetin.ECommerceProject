using Project.DAL.ContextClasses;
using Project.DAL.Repositories.Abstracts;
using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAL.Repositories.Concretes
{
    //Burada sadece ICategoryRepository'den miras alırsa içerisindeki çoğu şeyi implement etmek zorunda kalır. Peki ICategoryRepository içerisinde ne vardı? IRepository'in aldığı bütün herşeyin Category'e göre implement edilmesi vardı. Peki aslında IRepository'i implement eden bir BaseRepository'imiz zaten var..  BaseRepository<Category> şu şekilde miras al, böylece ICategoryRepositorydan gelen herşey otomatik implement ediyorsun.

    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(MyContext db) : base(db)
        {

        }       
    }
}
