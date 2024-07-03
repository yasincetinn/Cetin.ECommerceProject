using Project.ENTITIES.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.ENTITIES.Interfaces
{
    public interface IEntity
    {

        //C# dilinde interfaceler (interfaces), instance constructor (örnek kurucu metot) içeremezler. Interfaceler sadece üye tanımları (metotlar, özellikler, olaylar) içerebilirler.

        //Burada neden ID property'si tutuyoruz? Bir kütüphaneye kitlenmeyelim diye. Çünkü burada ID tutmazsak bir gün kütüphane değiştiğinde veya kalktığında primary key'siz kalmamıza sebep olur. 

        //Biz Identity ile çalışacağız. En az bir class'ımız (AppUser), BaseClass'tan miras alamayacak. Bu yüzden interface oluşturuyoruz. (C# multi inheritance desteği yok. Yani bir sınıf 2 class'dan miras alamaz. AppUser hem IdentityUser hemde BaseEntity'den miras alamaz. Ama istediğimiz kadar inteface'den miras alabiliriz.)

        //Bütün classlarımızda olacak özellikleri aşağıya verdik. Böylelikle baseclassımız buradan miras alıp imlement ettiğinde baseclass'ın miras verdikleride buradan faydalanabilecek.

        public int ID { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public DateTime? DeletedDate { get; set; }
        public DataStatus Status { get; set; }

    }
}
