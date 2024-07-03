using Newtonsoft.Json;

namespace Project.CoreMVC.Models.ShoppingTools
{
    //Buradaki yapacağımız CRUD veri tabanında değil RAM'de yer alır.

    [Serializable]

    public class Cart
    {
        //Bir sepetin içerisinde birden fazla ürün olur. Buraya Tek bir CartItem koyarsak sepete bir ürün koyabilir demiş oluruz. Aynı şekilde ürün sepetin içerisinde ekleme silme ve güncellemeye maruz kalabilir. Burada bir iş akışı var buna property olarak yaklaşamayız. Kontrol edilmesi gereken bir iş var encapsulation prensibi devreye girmesi gerekli. Property bu kontrolden kendi kendi geçemez. Bu kontrolü sağlayabilmesi için bir fielda ihtiyacı var. (Field olmasa ve kendi kendine yapmaya çalışsa StackOverFlow Exception alırız)
        //Set : Ram'e veriyi gönderir, Get: Ram'den veriyi getirir. Set atama operatörünü gördüğü anda tetiklenir.

        [JsonProperty("_myCart")] //Bunu yazmazsak json bu field'ı tanımaz. Eğer ben bunu yazmaz access modifiers'a public yazarsam o zaman encapsulation algoritması ortadan kalkar..

        readonly Dictionary<int, CartItem> _myCart; //Biz sepetimize List tipi ile eklenen ürüne ekleme silme ve güncelleme gibi işlemler yapabiliriz. Yalnız işi uzatmış oluruz. Sepette birden fazla ürün olabilir o ürünü bulmak için LİNQ yazmak zorunda kalırız. Buna gerek yok. Her ürüne anahtar olarak ID'lerini veren koleksiyonumuz var (Dictionary). Yani LİNQ yazmadan id'den ona ulaşabiliyorum. (İlk önce anahtarını veriyoruz sonra tutmak istediğimiz yapıyı söylüyoruz int,CartItem)

        public Cart()
        {
            _myCart = new Dictionary<int, CartItem>();

            //_myCart[1] normal şartlarda index parantezleri ilgili index'teki elemanı secme ifadesini söyler...Fakat bir Dictionary koleksiyonu söz konusu oldugunda bu index parantezi ilgili key'e sahip anahtarı sec demektir...
        }


        [JsonProperty("GetCartItems")]
        public List<CartItem> GetCartItems
        {
            get
            {
                return _myCart.Values.ToList(); //List olarak encapsulation şeklinde dışarı açtık. Ram'de dictionary anahtarıyla duruyor. Kişi sepetindeki ürünü görmek isteyince property gidiyor dictionary'den sadece değerleri alıp getiriyor ve bunu list halinde döndürüyor.
            }
        }

        public void AddToCart(CartItem ci) //Sepete ürün ekleme
        {
            if (_myCart.ContainsKey(ci.ID)) //Field'im böyle bir anahtar içeriyor mu... Bana gelen sepetin Id'si (ci.ID)
            {
                _myCart[ci.ID].Amount++; //Eğer içeriyorsa tekrar eklemeye gerek yok Amount'u arttırman yeterli. O koleksiyondaki ürüne index key'ine Id vererek. Amount++ diyerek 1 arttır.
                return; //ve local alanı sonlandır
            }

            _myCart.Add(ci.ID, ci); //Yoksa karta yeni ürün ekle. (ci.ID => Ürünün ID'si,  ci=> kendisi)
        }

        public void Decrease(int id) //Sepetten ürün çıkarma
        {
            _myCart[id].Amount--;

            if (_myCart[id].Amount == 0)
            {
                _myCart.Remove(id); //Dictionary'deki remove metodu verdiğiniz anahtardaki veriyi siler. 
            }
        }

        public void RemoveFromCart(int id)
        {
            _myCart.Remove(id); //10 tane ürünü komple sil vs..
        }


        [JsonProperty("TotalPrice")]
        public decimal TotalPrice //Toplam
        {
            get
            {
                return _myCart.Values.Sum(x => x.SubTotal); //_myCart isimli değişkene gir, values(değerlerini) al, bir property'in tamamen toplamını al ()sum)SubTotal'ini topla.. (Values == CartItem)
            }

        }

        #region TotalPrice 2.Yöntem
        /* public decimal TotalPriceWithMethod()
         {
             decimal total = 0;
             foreach (CartItem item in _myCart.Values)
             {
                 total += item.SubTotal;
             }
             return total;
         } 
        */
        #endregion

        // _myCart[1] ... Normal şartlarda index parantezleri ilgili index'teki elemanı seçme ifadesini söyler. Fakat bir Dictionary koleksiyonu olduğunda bu index parantezi ilgili key'e sahip anahtarı getir demektir. 

    }
}
