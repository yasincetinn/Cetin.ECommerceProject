using Project.BLL.Managers.Abstracts;
using Project.DAL.Repositories.Abstracts;
using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.Managers.Concretes
{
    public class AppUserManager : BaseManager<AppUser> , IAppUserManager
    {
        readonly IAppUserRepository _iAppRep;

        public AppUserManager(IAppUserRepository iAppRep) : base(iAppRep)
        {
            _iAppRep = iAppRep;
        }

    }
}
