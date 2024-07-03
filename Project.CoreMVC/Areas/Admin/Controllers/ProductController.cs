using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.DotNet.Scaffolding.Shared.CodeModifier.CodeChange;
using Project.BLL.Managers.Abstracts;
using Project.CoreMVC.Areas.Admin.Models.Products.PageVMs;
using Project.CoreMVC.Areas.Admin.Models.Products.PureVMs;
using Project.ENTITIES.Models;
using System;
using System.Drawing;
using System.Drawing.Imaging;

namespace Project.CoreMVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]

    public class ProductController : Controller
    {
        readonly ICategoryManager _categoryManager;
        readonly IProductManager _productManager;

        public ProductController(ICategoryManager categoryManager, IProductManager productManager)
        {
            _categoryManager = categoryManager;
            _productManager = productManager;
        }

        public IActionResult Index()
        {
            
            List<Product> products = _productManager.GetAll();

            // Product varlıklarını ProductRequestModel'e dönüştür
            List<ProductRequestModel> productRequestModels = products.Select(product => new ProductRequestModel
            {
                ID = product.ID,
                ProductName = product.ProductName,
                UnitPrice = product.UnitPrice,
                CategoryName = product.Category.CategoryName,
                ImagePath = product.ImagePath,
                UnitsInStock = product.UnitsInStock,
                Status = product.Status
            }).ToList();

            return View(productRequestModels);
        }

        private bool IsImageFile(IFormFile file) //Bu metod, bir IFormFile nesnesi alır ve bu dosyanın bir resim dosyası olup olmadığını kontrol eder.
        {
            try
            {
                using (Image image = Image.FromStream(file.OpenReadStream()))   //try-catch bloğu içinde dosyanın Image.FromStream metodunu kullanarak okunup okunamayacağını deneyerek kontrol ediyoruz. Bu yöntem, dosyanın gerçekten bir resim dosyası olup olmadığını doğrulamak için yaygın bir yöntemdir. Image.FromStream(file.OpenReadStream()) kullanılarak dosya okunur
                {
                    return image.RawFormat.Equals(ImageFormat.Jpeg) ||  
                           image.RawFormat.Equals(ImageFormat.Png); //Image nesnesi oluşturulduktan sonra, RawFormat özelliği ile dosyanın formatı kontrol edilir 
                }
            }
            catch
            {
                return false;   //Eğer dosya bir resim dosyası ise true döndürülür, değilse veya bir hata oluşursa catch bloğunda false döndürülür.
            }
        }

        public IActionResult CreateProduct()
        {
            List<Category> categories = _categoryManager.GetAll(); // ile tüm kategorileri alırız.

            List<CategoryProductRequestModel> cPrm = categories.Select(c => new CategoryProductRequestModel //CategoryProductRequestModel kullanarak kategorileri bir ViewModel listesine dönüştürürüz (cPrm).
            {
                ID = c.ID,
                CategoryName = c.CategoryName
                
            }).ToList();

            ProductPageVM pVm = new ProductPageVM() //ProductPageVM ViewModel'i oluştururuz ve içine kategorileri ekleriz (pVm).
            {
                Categories = cPrm
            };

            return View(pVm); //View(pVm) ile pVm ViewModel'i içeren view'i döndürürüz. Bu view, kullanıcıya ürün oluşturma formunu gösterir.
        }

        [HttpPost]
        public IActionResult CreateProduct(ProductRequestModel product, IFormFile formFile)
        {
            //FrontEnd'e gönderdiğimiz veri ProductPageVM tipinde. Fakat biz o modeli komple almak istemiyoruz. Biz burada nasıl bir standart izlemeliyiz ? PageVm içerisinde aynı property ismi var. Biz bunu yakalamak için parametre olarak aynı ismi vermeliyiz. Eğer parametresini standart olarak farklı vereceksek başına [Bind (Prefix = "Product") yazmamız gerekli.  

            if (formFile != null)
            {
                // Dosyanın uzantısını ve içeriğini kontrol etmek için
                string extension = Path.GetExtension(formFile.FileName).ToLower(); //ile dosyanın uzantısını alır ve küçük harfe dönüştürürüz.
                string[] allowedExtensions = { ".jpg", ".jpeg", ".png" }; //Dosya uzantısı sadece bunlar olsun

                // Dosyanın gerçek bir resim dosyası olup olmadığını kontrol etmek için
                if (IsImageFile(formFile))
                {
                    // Dosya uzantısı kontrolü (isteğe bağlı olarak)
                    if (!allowedExtensions.Contains(extension))
                    {
                        ModelState.AddModelError("formFile", "Please only upload a photo in JPG, JPEG or PNG format.");
                        // Şu an için örnek olarak default bir resim atıyoruz
                        product.ImagePath = "/images/ShoppingPhoto.png"; // Default resim yolu
                    }
                    else
                    {
                        // Eğer uzantı uygunsa, dosyayı işleyebiliriz
                        Guid uniqueName = Guid.NewGuid();
                        product.ImagePath = $"/images/{uniqueName}{extension}"; //Eğer dosya bir resim dosyası ise, dosyayı benzersiz bir isimle kaydedip product.ImagePath'i güncelleriz.

                        string path = $"{Directory.GetCurrentDirectory()}/wwwroot{product.ImagePath}";
                        using (FileStream stream = new FileStream(path, FileMode.Create))
                        {
                            formFile.CopyTo(stream);
                        }
                    }
                }
                else
                {
                    // Eğer dosya gerçek bir resim dosyası değilse
                    ModelState.AddModelError("formFile", "Lütfen geçerli bir fotoğraf dosyası yükleyin.");
                    product.ImagePath = "/images/ShoppingPhoto.png"; // Default resim yolu
                }
            }

            else
            {
                // Eğer formFile null ise, yani dosya yüklenmemişse
                product.ImagePath = "/images/ShoppingPhoto.png"; // Default resim yolu
            }

            Product p = new Product()  //Product sınıfından bir nesne oluşturulur ve bu nesneye ProductRequestModel içinden gelen veriler (ProductName, ImagePath, UnitPrice, UnitsInStock, CategoryID) atanır. Bu adımlarla, veritabanına eklemek üzere bir Product nesnesi hazırlanmış olur.
            {
                ProductName = product.ProductName,
                ImagePath = product.ImagePath,
                UnitPrice = product.UnitPrice,
                UnitsInStock = product.UnitsInStock,
                CategoryID = product.CategoryID
            };


            _productManager.Add(p); //Hazırlanan Product nesnesi _productManager aracılığıyla veritabanına eklenir.
            return RedirectToAction("Index");

        }

        public async Task<IActionResult> DeleteProduct(int id)
        {
            _productManager.Delete(await _productManager.FindAsync(id));
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DestroyProduct(int id)
        {
            TempData["Message"] = _productManager.Destroy(await _productManager.FindAsync(id));
            return RedirectToAction("Index");
        }


        public async Task<IActionResult> UpdateProduct(int id)
        {
            Product product = await _productManager.FindAsync(id);

            ProductRequestModel prVm = new()
            {
               ID = product.ID,
               ProductName = product.ProductName,    
               ImagePath = product.ImagePath,
               UnitPrice = product.UnitPrice,
               UnitsInStock = product.UnitsInStock,
               CategoryID = product.Category.ID
            };

            List<Category> categories = _categoryManager.GetActives();

            List<CategoryProductRequestModel> cpRm = categories.Select(c => new CategoryProductRequestModel
            {
                ID = c.ID,
                CategoryName = c.CategoryName

            }).ToList();

            ProductPageVM pVm = new()
            {
                Categories = cpRm,
                Product = prVm
            };
            
            return View(pVm);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateProduct(ProductRequestModel product, IFormFile formFile)
        {

            // Yeni bir dosya yüklendi mi kontrol ediyoruz
            if (formFile != null)
            {
                // Benzersiz bir dosya adı oluşturuyoruz
                Guid uniqueName = Guid.NewGuid();
                string extension = Path.GetExtension(formFile.FileName);
                product.ImagePath = $"/images/{uniqueName}{extension}";

                // Yeni dosyayı kaydediyoruz
                string path = $"{Directory.GetCurrentDirectory()}/wwwroot{product.ImagePath}";
                using (FileStream stream = new FileStream(path, FileMode.Create))
                {
                    await formFile.CopyToAsync(stream);
                }
            }

            else
            {
                // Eğer yeni bir dosya yüklenmediyse, mevcut ürünün resim yolunu koruyoruz
                Product existingProduct = _productManager.GetAll().FirstOrDefault(p => p.ID == product.ID); //_productManager.GetAll() ile tüm ürünleri alırız.LINQ FirstOrDefault metodu kullanılarak product.ID'ye eşit olan ürün bulunur ve existingProduct değişkenine atanır.

                if (existingProduct != null) //existingProduct null değilse, product.ImagePath mevcut ürünün resim yolunu korumak için bu değere atanır.
                {
                    product.ImagePath = existingProduct.ImagePath;
                }
            }


            // Güncellenecek Product nesnesini hazırlıyoruz
            Product p = new()
            {
                ID = product.ID,
                ProductName = product.ProductName,
                UnitPrice = product.UnitPrice,
                UnitsInStock = product.UnitsInStock,
                ImagePath = product.ImagePath,
                CategoryID = product.CategoryID
            };

            // Güncelleme işlemini yapıyoruz
            await _productManager.UpdateAsync(p);

            return RedirectToAction("Index"); //Ürün başarıyla güncellendikten sonra Index eylemine yönlendirme yapılır.

        }

    }
}
