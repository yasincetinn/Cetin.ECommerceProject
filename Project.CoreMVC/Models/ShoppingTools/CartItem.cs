using Newtonsoft.Json;

namespace Project.CoreMVC.Models.ShoppingTools
{

    //Sepete atılan ürün Domain entity olmamalı onu temsil eden bir class olmalı..

    [Serializable] //Json formata çevirme. Serializable Attribute: Bu öznitelik, bir sınıfın serileştirilebilir olduğunu belirtir. Serileştirme, bir nesnenin bir veri akışına veya depolama ortamına (örneğin, bir dosyaya veya ağa) dönüştürülmesi işlemidir. JSON (JavaScript Object Notation) da bir serileştirme formatıdır.
    public class CartItem
    {
        //Constructors veya herhangi bir metodda JSON serileştirmesi için varsayılan olarak kullanılmaz. Çünkü JSON serileştirme kütüphaneleri genellikle inşa edicilerle değil, public property'lerle çalışır. Eğer inşa edici içerisinde JSON serileştirmesi istediğiniz özel bir mantık varsa, o özelliğin public get/set metotlarına sahip olması ve uygun JSON serileştirme özniteliklerinin uygulanmış olması gerekir.

        public CartItem()
        {
            Amount++; //CartItem'dan instance alındığı zaman miktarı 1 artarak başlasın..
        }

        [JsonProperty("ID")]
        public int ID { get; set; } //JsonProperty Attribute: Bu öznitelik, bir property'nin JSON nesnesindeki karşılığının ne olacağını belirtir. Örneğin, ID property'si JSON'da "ID" adı altında gösterilecektir.


        [JsonProperty("ProductName")]
        public string ProductName { get; set; }


        [JsonProperty("Amount")]
        public int Amount { get; set; } //Miktar


        [JsonProperty("UnitPrice")]
        public decimal UnitPrice { get; set; }


        [JsonProperty("SubTotal")]
        public decimal SubTotal { get { return Amount * UnitPrice; } } //Toplam


        [JsonProperty("ImagePath")]
        public string ImagePath { get; set; }


        [JsonProperty("CategoryID")]
        public int? CategoryID { get; set; }


        [JsonProperty("CategoryName")]
        public string CategoryName { get; set; }

    }
}

