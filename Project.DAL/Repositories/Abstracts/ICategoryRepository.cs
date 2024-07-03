using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAL.Repositories.Abstracts
{
    //Burası sadece içerisinde category ile ilgili olan işlemleri barındıracak. Aynı zamanda IRepository'deki o metotları Category için işleyerek kendi içine alacak. (Diğer interface'lerde aynı şekilde...)

    public interface ICategoryRepository : IRepository<Category>
    {
        
    }
}
