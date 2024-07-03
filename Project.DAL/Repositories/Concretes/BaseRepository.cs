using Microsoft.EntityFrameworkCore;
using Project.DAL.ContextClasses;
using Project.DAL.Repositories.Abstracts;
using Project.ENTITIES.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAL.Repositories.Concretes
{
    public class BaseRepository<T> : IRepository<T> where T : class, IEntity
    {
        //Artık .Net Core'da kullandığımız Hybrid N-Tier Architechure'da BaseRepository class'ımız Abstract olmayacaktır. Çünkü BaseRepository anlamlı veri modelleri oluşturabilecek bir class'dır.

        //BaseRepository ismi değişmez. Teknoloji değiştiğinde kodla sürekli  bir değişiklik yapmayız onun yerine namespace adını değiştiririz. Zaten BLL katmanının bunu dert etmesine gerek yok çünkü BLL umursamaz hangi teknolojiyi kullandığımızı , interface'i tanır. Peki BLL sadece interface'i tanıyorsa ve bizim teknolojimizi BaseRepository bilecekse program nereden bilecek hangi teknolojiyi kullandığımızı? -> Biz middleware tanımlayacağız ve o da anlayacak.

        protected readonly MyContext _db; //Miras verilen yerde field olarak çekip kullanmak isteyebilir diye protected olarak işaretledik.

        public BaseRepository(MyContext db)  // Biz burada entity framework'deki gibi elimizle singeleton pattern aracılığıyla instance almıyoruz. Middleware verdiğimiz talimatla parametre olarak verdiğimiz MyContext fielda inject edilecek. (Tabi algoritmayı BLL'deki serviceinjection'da yapıp midlleware'e tanımladık.) 
        {
            _db = db;
        }

        protected void Save()
        {
            _db.SaveChanges();
        }

        public void Add(T item)
        {
            _db.Set<T>().Add(item); //T tipinde item aldı. Database gittik ilgili Db'yi(tabloyu) Set ederek (T tipi neyse) o nesneyi tabloya ekleyerek Save ettik. 
            Save();
        }

        public async Task AddAsync(T item)
        {
            await _db.Set<T>().AddAsync(item);
            Save();
        }

        public void AddRange(List<T> list)
        {
            _db.Set<T>().AddRange(list);
            Save();
        }

        public async Task AddRangeAsync(List<T> list)
        {
            await _db.Set<T>().AddRangeAsync(list);
            Save();
        }

        public bool Any(Expression<Func<T, bool>> exp)
        {
            return _db.Set<T>().Any(exp);
        }

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> exp)
        {
            return await _db.Set<T>().AnyAsync(exp);
        }

        public void Delete(T item)
        {
            item.Status = ENTITIES.Enums.DataStatus.Deleted;
            item.DeletedDate = DateTime.Now;
            Save();
        }

        public void DeleteRange(List<T> list)
        {
            foreach (T item in list) Delete(item);
        }

        public void Destroy(T item)
        {
            _db.Set<T>().Remove(item);
            Save();
        }

        public void DestroyRange(List<T> list)
        {
            _db.Set<T>().RemoveRange(list);
            Save();
        }

        public async Task<T> FindAsync(int id)
        {
            return await _db.Set<T>().FindAsync(id);
        }

        public T FirstOrDefault(Expression<Func<T, bool>> exp)
        {
            return _db.Set<T>().FirstOrDefault(exp);
        }

        public async Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> exp)
        {
            return await _db.Set<T>().FirstOrDefaultAsync(exp);
        }

        public List<T> GetActives()
        {
            return Where(x => x.Status != ENTITIES.Enums.DataStatus.Deleted);
        }

        public async Task<List<T>> GetActivesAsync()
        {
            return await _db.Set<T>().Where(x => x.Status != ENTITIES.Enums.DataStatus.Deleted).ToListAsync();
        }

        public List<T> GetAll()
        {
            return _db.Set<T>().ToList();
        }

        public List<T> GetFirstDatas(int count)
        {
            return _db.Set<T>().OrderBy(x => x.CreatedDate).Take(count).ToList();
        }

        public List<T> GetLastDatas(int count)
        {
            return _db.Set<T>().OrderByDescending(x => x.CreatedDate).Take(count).ToList();
        }

        public List<T> GetModifieds()
        {
            return Where(x => x.Status == ENTITIES.Enums.DataStatus.Updated);
        }

        public List<T> GetPassives()
        {
            return Where(x => x.Status == ENTITIES.Enums.DataStatus.Deleted);
        }

        public object Select(Expression<Func<T, object>> exp)
        {
            return _db.Set<T>().Select(exp);
        }

        public IQueryable<X> Select<X>(Expression<Func<T, X>> exp)
        {
            return _db.Set<T>().Select(exp);
        }

        public async Task UpdateAsync(T item)
        {
            item.ModifiedDate = DateTime.Now;
            item.Status = ENTITIES.Enums.DataStatus.Updated;
            T originalEntity = await FindAsync(item.ID);
            _db.Entry(originalEntity).CurrentValues.SetValues(item);
            Save();

            //_db.Entry dediğimiz zaman database'e direkt ana müdahale, primary(birincil) için bir giriş var demektir. _db.Entry(originalEntity)'i alıyor, CurrentValues henüz değişmemiş veriyi alıyor, SetValue(item) ayarlamak üzere Ramdeki yeni haline (item'a) Set ediyor.
            //Entry en yüksek giriştir. Direkt veriyle iş yapar.
        }

        public async Task UpdateRangeAsync(List<T> list)
        {
            foreach (T item in list) await UpdateAsync(item);
        }

        public List<T> Where(Expression<Func<T, bool>> exp)
        {

            return _db.Set<T>().Where(exp).ToList();
        }
    }
}
