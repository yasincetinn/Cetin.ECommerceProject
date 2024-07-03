using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Project.BLL.Managers.Abstracts;
using Project.DAL.Repositories.Abstracts;
using Project.ENTITIES.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.Managers.Concretes
{
    public class BaseManager<T> : IManager<T> where T : class, IEntity
    {
        protected readonly IRepository<T> _iRep;

        public BaseManager(IRepository<T> iRep) //Burada dikkat ederseniz BaseManager constructor'i bir parametre alıyor (IRepository<T> iRep tipinde) .. IOC (Inversion of Controls) pattern'ine göre burada belirtilen tip middleware'de görülürse bize instance'i alınabilecek bir şey gönderilir. Bizim istediğimiz IRepository<T> generic tipi algılandığında BaseRepository instance'i gönderilecektir. Bu yüzdendir ki BaseRepository'i abstract yapmadık.(UI manageri kullanıyor, manager ise repository'i kullanıyor)
        {
            _iRep = iRep;
        }


        public void Add(T item)
        {         
            _iRep.Add(item);
        }

        public async Task AddAsync(T item)
        {
            await _iRep.AddAsync(item);

        }

        public void AddRange(List<T> list)
        {
            _iRep.AddRange(list);
        }

        public async Task AddRangeAsync(List<T> list)
        {
            
            await _iRep.AddRangeAsync(list);
        }

        public bool Any(Expression<Func<T, bool>> exp)
        {
            return _iRep.Any(exp);
        }

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> exp)
        {
            return await _iRep.AnyAsync(exp);
        }

        public void Delete(T item)
        {
            if (item.CreatedDate == default)
            {
                return;
            }
            _iRep.Delete(item);

        }

        public void DeleteRange(List<T> list)
        {
            _iRep.DeleteRange(list);
        }

        public string Destroy(T item) //Aşağıdaki algoritmanın amacı kişi içerisinde ürünler olan kategoriyi silebilir. Bunu engelliyoruz ve ürünler silindikten sonra kategoriyi destroy edebiliyoruz. 
        {
            if (item.Status == ENTITIES.Enums.DataStatus.Deleted)
            {
                try
                {
                    _iRep.Destroy(item); // Veritabanından silme işlemi yapılır
                    return "Data was successfully deleted."; // Veri başarıyla silindi
                }

                catch (Exception ex)
                {
                    // Veritabanı hata mesajını yakalayarak özelleştirilmiş hata mesajı döndürülür

                    if (ex.InnerException is SqlException sqlEx && sqlEx.Number == 547)
                    {
                        return "Cannot delete the data. Please delete the products in the category"; //Veriler silinemiyor. Lütfen kategorideki ürünleri silin.
                    }
                }
            }

            // Pasif olmayan bir veriyi silmeye çalışıyorsa uygun mesaj döndürülür
            return $"You cannot delete the data. Data with ID: {item.ID} is not marked as deleted."; // Silmeye çalışılan veri pasif değil.

        }

        public string DestroyRange(List<T> list)
        {
           
            foreach (T item in list) return Destroy(item);
            return "There was a problem during the deletion process. Please make sure the data status is passive!"; //Silme işlemi sırasında bir sorun oluştu. Lütfen veri durumunun pasif olduğundan emin olun!

        }

        public List<string> DestroyRangeWithText(List<T> list)
        {
            List<string> metinler = new List<string>();
            if (list == null || list.Count == 0)
            {
                metinler.Add("Not included in the list");//Listeye dahil edilmedi.
                return metinler;
            }

            foreach (T item in list) metinler.Add(Destroy(item));
            return metinler;
        }

        public async Task<T> FindAsync(int id)
        {
            return await _iRep.FindAsync(id);
        }

        public T FirstOrDefault(Expression<Func<T, bool>> exp)
        {
            return _iRep.FirstOrDefault(exp);
        }

        public async Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> exp)
        {
            return await _iRep.FirstOrDefaultAsync(exp);
        }

        public virtual List<T> GetActives()
        {
            return _iRep.GetActives();
        }

        public async Task<List<T>> GetActivesAsync()
        {
            return await _iRep.GetActivesAsync();
        }

        public List<T> GetAll()
        {
            return _iRep.GetAll();
        }

        public List<T> GetFirstDatas(int count)
        {
            return _iRep.GetFirstDatas(count);
        }

        public List<T> GetLastDatas(int count)
        {
            return _iRep.GetLastDatas(count);

        }

        public List<T> GetModifieds()
        {
            return _iRep.GetModifieds();
        }

        public List<T> GetPassives()
        {
            return _iRep.GetPassives();
        }

        public object Select(Expression<Func<T, object>> exp)
        {
            return _iRep.Select(exp);
        }

        public IQueryable<X> Select<X>(Expression<Func<T, X>> exp)
        {
            return _iRep.Select(exp);
        }

        public async Task UpdateAsync(T item)
        {
            await _iRep.UpdateAsync(item);
        }

        public async Task UpdateRangeAsync(List<T> list)
        {
            await _iRep.UpdateRangeAsync(list);
        }

        public List<T> Where(Expression<Func<T, bool>> exp)
        {
            return _iRep.Where(exp);
        }



        //Kullanıcıdan gelen bir verinin veri tabanına kadar işleminde kaç tane logic vardır?
        //
        // 2 logic işleminden geçer.
        //
        // 1) Validation logic : Yani doğrulama mantığı (Ürün ismi veya kategori ismi girilmiş mi? Minimum 8 karakter vs..) Bu validation logic tamamen PureVM'ler ile alakalıdır. buradan geçtikten sonra DTO dediğimiz sınıflara Map'lenir. Bu DTO sınıflarının amacı katmanlar arası gezmekten başka bir şey değildir. UI katmanı manager'a DTO gönderir. BLL bu DTO'uyu aldığı zaman manager'in görevi BLL'i DTO üzerinde handle (nesnenin bir yerden başta bir yere gönderilmesi) etmektir.   
        //
        // 2) Business logic : Buradan da geçktikten sonra veri, database'e repository tarafından eklemeye uygundur.


        // Manager yapısı iş akışı mantığını uygulamak için generic repository pattern kullanan teknoloji bağımsız bütün platformların başvurup uygulayabilmesi için kullandığımız bir sistemdir. Bunlar DAL'daki repository'e ihtiyaç duyarlar. Çünkü UI katmanı oraya başvurmak ister (CRUD işlemi yapmak vs.). Manager iş akışı kurallarını uygular. Manager'i bir nevi encapsulation algoritmasına benzetebiliriz... (UI katmanının göndermek istediği veri BLL'deki manager'a ulaşır, burada handle edilir ondan sonra DAL'a gönderilir..)


        //Bir .Net içerisinde System.Reflection kütüphanesi görüyorsanız anlayınki assembly ile samimi olmuşsunuzdur :):)
    }
}
