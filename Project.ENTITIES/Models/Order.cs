using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.ENTITIES.Models
{
    public class Order : BaseEntity
    {
        public string ShippingAddress { get; set; } //Kullanıcının siparişi talep ettiği(Siparişin gönderileceği) adres 

        public string Email { get; set; } //Üye olmayan bir kullanıcın email'i özel olarak burada tutulur(null geçildiyse anlayın ki kullanıcı üye olarak alışveriş yapmıştır)
        public string NameDescription { get; set; } //Üye olmayan kullanıcının isim açıklaması burada tutulur. (null geçildiyse anlayın ki kullanıcı üye olarak alışveriş yapmıştır)

        public decimal PriceOfOrder { get; set; } //Siparişin toplam fiyatı (Sepetin onaylanan fiyatı)

        public int? AppUserID { get; set; } //Null geçilebiliyorsa anlayın ki kullanıcı üye değildir 

        //Relational Properties

        public virtual AppUser AppUser { get; set; }

        public virtual ICollection<OrderDetail> OrderDetails { get; set; }


    }
}
