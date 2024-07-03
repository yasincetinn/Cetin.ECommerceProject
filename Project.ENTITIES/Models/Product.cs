using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.ENTITIES.Models
{
    public class Product : BaseEntity
    {
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public int UnitsInStock { get; set; }
        public string ImagePath { get; set; } //Resmi direkt veri tabanında tutmayacağız çünkü veri tabanını boğar. O yüzden bizim projemizde server'da duracak. veri tabanında string (resmin yolu) olarak duracak. Biz o resmin yolunu html'deki imgsource olarak verip öyle çıkaracağız. Eğer direkt veri tabanında tutsaydık string değil byte olarak gönderecektik.
        public int? CategoryID { get; set; }

        //Relational Properties

        public virtual Category Category { get; set; }

        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
