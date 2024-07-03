using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project.ENTITIES.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.CONF.Configurations
{
    //Veri tabanımızda tablo olacak classlarımızın ayarlamalarını yaptğımız katman = Project.CONF

    //Aşağıdaki Configure metodunu virtual ile işaretledik. (Miras alan diğer classlarımız implement ettiğinde ek ayarlamalar barındırabilir.)

    public abstract class BaseConfiguration<T> : IEntityTypeConfiguration<T> where T : class, IEntity
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            
        }
    }
}
