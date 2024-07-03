using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Project.BLL.Managers.Abstracts;
using Project.COMMON.Tools;
using Project.CoreMVC.Areas.Admin.Models.Products.PureVMs;
using Project.CoreMVC.Models.Categories;
using Project.CoreMVC.Models.Orders.PageVMs;
using Project.CoreMVC.Models.PageVMs;
using Project.CoreMVC.Models.Products;
using Project.CoreMVC.Models.SessionService;
using Project.CoreMVC.Models.ShoppingTools;
using Project.ENTITIES.Models;
using System.Text;
using X.PagedList;

namespace Project.CoreMVC.Controllers
{
    public class ShoppingController : Controller
    {
        readonly IProductManager _productManager;
        readonly ICategoryManager _categoryManager;
        readonly IOrderManager _orderManager;
        readonly IOrderDetailManager _orderDetailManager;
        readonly UserManager<AppUser> _userManager;
        readonly IHttpClientFactory _httpClientFactory;

        public ShoppingController(IProductManager productManager, ICategoryManager categoryManager, IOrderManager orderManager, IOrderDetailManager orderDetailManager, UserManager<AppUser> userManager, IHttpClientFactory httpClientFactory)
        {
            _productManager = productManager;
            _categoryManager = categoryManager;
            _orderManager = orderManager;
            _orderDetailManager = orderDetailManager;
            _userManager = userManager;
            _httpClientFactory = httpClientFactory;
        }

        //List<Product> list koleksiyon tipi Front End'e sayfalama yapmaya uygun bir koleksiyon değildir. Çünkü sayfalara bölünebilecek bir koleksiyon tipi değildir.

        public IActionResult Index(int? page, int? categoryID)
        {
            //Kişi sayfa belirtebilirde, belirtmeyebilirde o yüzden page'i null geçirebiliyoruz. Kişi aynı zamanda belirli kategorilerdeki ürünüde listelemeyi seçebilirde,  seçmeyedebilirde o yüzden bunuda null geçiyoruz.

            List<Category> categories = _categoryManager.GetActives(); //İlk olarak, aktif olan tüm kategorileri _categoryManager.GetActives() metoduyla alıyoruz.

            List<CategoryShoppingViewModel> cPureVm = categories.Select(cPureVm => new CategoryShoppingViewModel  //Bu kategorileri CategoryShoppingViewModel tipine dönüştürüp cPureVm listesine ekliyorsunuz.
            {
                ID = cPureVm.ID,
                CategoryName = cPureVm.CategoryName

            }).ToList();

            List<Product> products = _productManager.GetActives(); //Sonra, aktif olan tüm ürünleri _productManager.GetActives() metoduyla alıyorsunuz.

            IPagedList<ProductShoppingViewModel> pPureVm = products.Select(pPureVm => new ProductShoppingViewModel //Bu ürünleri ProductShoppingViewModel tipine dönüştürüp pPureVm listesine ekliyorsunuz. ToPagedList() metoduyla sayfalama işlemi yapıyorsunuz.
            {
                ID = pPureVm.ID,
                ProductName = pPureVm.ProductName,
                UnitPrice = pPureVm.UnitPrice,
                UnitsInStock = pPureVm.UnitsInStock,
                ImagePath = pPureVm.ImagePath,
                CategoryName = pPureVm.Category.CategoryName,
                CategoryID = pPureVm.Category.ID

            }).ToPagedList();

            ShoppingPageVM sPageVm = new ShoppingPageVM();

            sPageVm.Categories = cPureVm;

            sPageVm.Products = categoryID == null ? pPureVm.ToPagedList(page ?? 1, 5) : pPureVm.Where(x => x.CategoryID == categoryID).ToPagedList(page ?? 1, 5); //categoryID null ise (page ??) yani null geldiyse page değerini 1 yap yani 1.sayfadan başlat yok eğer 2-3 geldiyse onu al ve sayfa içerisinde 5 veri barındır. categoryID null değilse x.CategoryID == categoryID 'ye eşit olanları pagedList'e dök..          

            if (categoryID != null) TempData["catID"] = categoryID; //Bu satırda ise, eğer categoryID değeri null değilse (yani bir kategori filtresi uygulanmışsa), TempData adlı geçici veri saklayıcısına bu categoryID değeri atanıyor. Bu, kullanıcının sepete ürün ekledikten sonra hangi kategoride kaldığını hatırlamak için kullanılır. Geçici olarak saklanan bu değer, kullanıcı bir sonraki istekte sayfa yenilendiğinde veya yönlendirildiğinde kullanılabilir.

            return View(sPageVm);
        }


        public async Task<IActionResult> AddToCart(int id)
        {
            Cart c = GetCartFromSession("scart") == null ? new Cart() : GetCartFromSession("scart");  // Sepeti al veya yeni bir sepet oluştur

            Product productToBeAdded = await _productManager.FindAsync(id);  //Ürünü veritabanından al

            CartItem ci = new()  //CartItem oluştur
            {
                ID = productToBeAdded.ID,
                ProductName = productToBeAdded.ProductName,
                UnitPrice = productToBeAdded.UnitPrice,
                ImagePath = productToBeAdded.ImagePath,
                CategoryName = productToBeAdded.Category.CategoryName,
                CategoryID = productToBeAdded.CategoryID
            };

            c.AddToCart(ci); // Sepete ürünü ekle

            SetCartFromSession(c); // Sepeti session'da sakla

            TempData["Message"] = $"The product named <{ci.ProductName}> has been added to the cart.";

            return RedirectToAction("Index", new {productToBeAdded.CategoryID}); //object olarak CategoryID verdik ürüne tıkladığımızda aynı sayfada kalması için.          
        }

        void SetCartFromSession(Cart c)
        {
            HttpContext.Session.SetObject("scart", c);  //Bu metod, Cart tipindeki bir nesneyi session'a (HttpContext.Session) kaydetmek için kullanılır. HttpContext.Session.SetObject metodunun içerisinde, "scart" anahtarıyla Cart nesnesi (c) session'a kaydedilir. Bu yöntem, sepet bilgisini session üzerinde tutmak ve kullanıcı oturumu boyunca erişilebilir kılmak için gereklidir.
        }


        Cart GetCartFromSession(string key)
        {
            return HttpContext.Session.GetObject<Cart>(key);  //Bu metod, session'dan (HttpContext.Session) belirli bir anahtarla ("scart" anahtarıyla) Cart nesnesini almak için kullanılır. HttpContext.Session.GetObject metodunu kullanarak, belirtilen anahtarla kaydedilmiş Cart nesnesini geri döndürür. GetObject metodunun işlevi, belirtilen türdeki nesneyi session'dan doğrudan almak ve cast etmek için yardımcı olur.
        }

        public IActionResult CartPage()
        {
            if (GetCartFromSession("scart") == null) //Session'dan sepet bilgisini al, eğer sepet boşsa (null ise) mesaj çıkar Index'e yönlendir.
            {
                TempData["Message"] = "Your cart is currently empty!";
                return RedirectToAction("Index");
            }

            Cart c = GetCartFromSession("scart");  //Eğer sepet dolu ise, Cart nesnesini session'dan alır (GetCartFromSession("scart")), bu nesneyi CartPageVM tipinde bir view modeline (cartPageVm) atar (cartPageVm.Cart = c;) ve bu view modelini CartPage.cshtml gibi bir view dosyasına göndererek kullanıcıya sepet içeriğini gösterir.
            CartPageVM cartPageVm = new CartPageVM();
            cartPageVm.Cart = c;
            return View(cartPageVm);     
        }

        public IActionResult DeleteFromCart(int id) //Ürünü sepetten komple kaldırmak için
        {
            if (GetCartFromSession("scart") != null) //GetCartFromSession("scart") metoduyla session'dan sepet bilgisini alır. Eğer session'da sepet varsa (null değilse), Cart nesnesini c değişkenine atar.
            {
                Cart c = GetCartFromSession("scart");

                c.RemoveFromCart(id); //c.RemoveFromCart(id) satırıyla Cart sınıfının RemoveFromCart metodunu çağırarak, belirtilen id ile tanımlanan ürünü sepetten çıkarır. 

                SetCartFromSession(c); //SetCartFromSession(c) metodunu çağırarak güncellenmiş sepet bilgisini session'a tekrar kaydeder

                ControlCart(c); //ControlCart(c) metodunu çağırarak sepetin içeriğini kontrol ettik.
            }
            return RedirectToAction("CartPage");
        }

        void ControlCart(Cart c)
        {
            if (c.GetCartItems.Count == 0) HttpContext.Session.Remove("scart"); //Kartı kontrol et. Ürünleri sildiğimizde sepetin için boşsa session'u temizle, session boşuna durmasın. 
        }

        public IActionResult DecreaseFromCart(int id) //Ürün azaltma için 
        {
            if (GetCartFromSession("scart") != null) // metoduyla session'dan ("scart" anahtarıyla) sepet bilgisini alıyoruz. Eğer session'da scart anahtarıyla bir sepet varsa (!= null kontrolü ile)...
            {
                Cart c = GetCartFromSession("scart"); //bu sepet bilgisini c isimli bir Cart nesnesine atıyoruz.

                c.Decrease(id); //Cart sınıfının Decrease metodunu çağırarak, belirtilen id ile tanımlanan ürünü sepetten azaltıyoruz.

                SetCartFromSession(c); //SetCartFromSession(c) satırıyla, güncellenmiş sepet bilgisini tekrar session'a ("scart" anahtarıyla) kaydediyoruz.

                ControlCart(c); //ControlCart(c) metodunu çağırarak, sepetin içeriğini kontrol et. 
            }
            return RedirectToAction("CartPage");
        }

        public IActionResult ConfirmOrder()
        {
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> ConfirmOrder(OrderRequestPageVM ovm)
        {
            Cart c = GetCartFromSession("scart");

            CartPageVM cartPageVm = new CartPageVM();
            cartPageVm.Cart = c;

            ovm.Order.PriceOfOrder = ovm.PaymentRequestModel.ShoppingPrice = c.TotalPrice;

            #region APIIntegration

            HttpClient client = _httpClientFactory.CreateClient();
            string JsonData = JsonConvert.SerializeObject(ovm.PaymentRequestModel);  //HTTP isteği için JSON formatına dönüştürülmüş ödeme modeli (PaymentRequestModel) hazırlanır.

            StringContent content = new StringContent(JsonData, Encoding.UTF8, "application/json"); //Encoding.UTF8 genellikle JSON verileri için kullanılan standart karakter kodlamasıdır.

            HttpResponseMessage responseMessage = await client.PostAsync("http://localhost:5205/api/Transaction", content); //HttpClient ile belirtilen yukarıdaki URL'e POST isteği gönderilir ve cevap beklenir. application/json": Bu parametre, StringContent nesnesinin içeriğinin hangi medya türü olduğunu belirtir. application/json medya türü, içeriğin JSON formatında olduğunu ifade eder. Bu bilgi, alıcı tarafında içeriğin nasıl işleneceğini anlamak için kullanılır.

            if (responseMessage.IsSuccessStatusCode) //HTTP isteği başarılı ise (IsSuccessStatusCode true ise),
            {
                if (User.Identity.IsAuthenticated) //kullanıcı kimlik doğrulaması yapılır ve gerekli sipariş bilgileri ayarlanır.

                {
                    AppUser appUser = await _userManager.FindByNameAsync(User.Identity.Name);

                    ovm.Order.AppUserID = appUser.Id; //Normalde Order'in içerisindeki Email ve NameDescription null geçilebilir olması gereken şeylerdir. Çünkü AppUserId zaten sistemdedir ve Order'in Email'ine gerek yoktur. Lakin bu durumda üye olmayanada alışveriş yapabilsin diye bu noktada onları Required olarak tanımlamak gerekir (Pure VM'de)

                    ovm.Order.Email = appUser.Email; //Normalde bunların böyle verilmesine gerek yok string property'i nullable yapabilirdik (.Net 6'da artık referans tiplerek özellikle null geçilebilir demezseniz veritabanına not nullable olarak gider) Ancak Entities'in düzenini tekrar bozmamak adına böyle bir yönetimi tercik ettik.

                    ovm.Order.NameDescription = appUser.UserName;
                }

                Order order = new()
                {
                    ID = ovm.Order.ID,
                    Email = ovm.Order.Email,
                    NameDescription = ovm.Order.NameDescription,
                    AppUserID = ovm.Order.AppUserID,
                    PriceOfOrder = ovm.Order.PriceOfOrder,
                    ShippingAddress = ovm.Order.ShippingAddress                  
                };

                await _orderManager.AddAsync(order); //Önce Order'in ID'sinin olusması lazım... Burada Order'i kaydederek o ID'nin Identity sayesinde olusmasını saglıyoruz...

                string productName = null;
                decimal subTotal = 0;

                foreach (CartItem item in cartPageVm.Cart.GetCartItems)
                {
                    OrderDetail od = new()
                    {
                        OrderID = order.ID,
                        ProductID = item.ID,
                        Quantity = item.Amount,
                        UnitPrice = item.UnitPrice
                    };
                                   
                    Product p = await _productManager.FindAsync(item.ID);
                    p.UnitsInStock -= item.Amount;
                    await _productManager.UpdateAsync(p);

                    await _orderDetailManager.AddAsync(od);

                    productName += $" {item.ProductName} x {item.Amount} ,"; //Sipariş edilen ürünler (mail ile gönderilecek)                                                                    
                    subTotal += item.SubTotal; //Siparişin toplam tutarı (mail ile gönderilecek)
                }

                productName = productName.TrimEnd(',');

                TempData["Message"] = "Your payment has been successfully received"; //Ödemeniz başarıyla alındı

                string emailAddress = ovm.Order.Email; // Siparişi veren kişinin e-posta adresi
                MailService.Send(emailAddress, subject: "Order Confirmation" , body : $"Your order has been received successfully. Thank you for choosing us. The products you ordered : \n{productName} \nSubTotal= {subTotal}"); //Sipariş verildikten sonra onaylandığına dair mail gönderdik.


                HttpContext.Session.Remove("scart"); //Sipariş verildikten sonra kartı boşa çıkar. 

                return RedirectToAction("Index");
            }

            string result = await responseMessage.Content.ReadAsStringAsync();
            TempData["Message"] = result;  //HTTP isteği başarısız ise, hata mesajı alınarak kullanıcıya bilgi verilir
            return RedirectToAction("Index");

            #endregion

        }
    }
}
