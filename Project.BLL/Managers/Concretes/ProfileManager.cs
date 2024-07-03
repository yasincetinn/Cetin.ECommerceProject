﻿using Project.BLL.Managers.Abstracts;
using Project.DAL.Repositories.Abstracts;
using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.Managers.Concretes
{
    public class ProfileManager : BaseManager<AppUserProfile>, IProfileManager
    {
        readonly IProfileRepository _iProRep;

        public ProfileManager(IProfileRepository iProRep) : base(iProRep)
        {
            _iProRep = iProRep;
        }
    }
}
