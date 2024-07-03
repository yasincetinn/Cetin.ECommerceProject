using Microsoft.AspNetCore.Identity;
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
    public class AppUserRepository : BaseRepository<AppUser> , IAppUserRepository ////Ben sana IAppUserRepository isteyeceğim sen bana AppUserRepository vereceksin(instance alacaksın)(IOC). Yarın bir gün bu yapı değişirse(AppUserRepository) interface üzerinden tekrar miras vererek hiç programı değiştirmeden tamamen interface'ler üzerinden çalışarak Loose Coupling (Gevşek Bağlılık) bir yapı sağlayabiliriz.
    {
        public AppUserRepository(MyContext db) : base(db)
        {

        }

    }
}
