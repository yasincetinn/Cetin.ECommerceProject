using Project.ENTITIES.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAL.Repositories.Abstracts
{
    //Marker Interface Pattern; kod yazma süreçlerinde derleyicinin nesneler hakkında ek bilgilere sahip olabilmesini ve böylece ilgili nesnenin kullanılacağı noktaları derleme sürecinde kurallar eşliğinde belirleyerek, kodu runtime’da olası hatalardan arındırmamızı sağlayan bir pattern’dır. Mesela 3 tane Entity classımız olsun bunlardan bunlar IEntity'den miras alsın böylelikle veritabanından silinebilir olsunlar, birisi IEntity'den miras alamazsa veritabanından silinemezler. 

    public interface IRepository<T> where T : IEntity //Marker Interface Pattern (İşaretleyici Arayüz Tasarımı) Biz burada sadece BaseEntity olsun diyemeyiz. Çünkü class'larımız bir interface'den miras aldı. 
    {
        //List Commands
        List<T> GetAll();
        List<T> GetActives();
        Task<List<T>> GetActivesAsync();
        List<T> GetPassives();
        List<T> GetModifieds();

        //Modify Commands
        //(Veri tabanında değişikliğe uğrayacak yapılar)
        void Add(T item);
        Task AddAsync(T item);
        void AddRange(List<T> list);
        Task AddRangeAsync(List<T> list);
        void Delete(T item);
        void DeleteRange(List<T> list);
        Task UpdateAsync(T item);
        Task UpdateRangeAsync(List<T> list);
        void Destroy(T item);
        void DestroyRange(List<T> list);

        //Linq Commands
        List<T> Where(Expression<Func<T, bool>> exp);
        bool Any(Expression<Func<T, bool>> exp);
        Task<bool> AnyAsync(Expression<Func<T, bool>> exp);
        T FirstOrDefault(Expression<Func<T, bool>> exp);
        Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> exp);
        object Select(Expression<Func<T, object>> exp); //Mapleme yapabilmemizi sağlayan tek method Select'tir. (Domain entityleri VM'lere Mapledik veya tam tersi..) Bunun dışında Anonymus type'ları mapleriz. Bunun için ya object ya da dynamic vardır. Dynmac'i tercih etmeyiz çünkü test edilebilir değildir complier(derleme) bunu bilemez... Burada açılan select method'u anonymus type maping'e destek verecektir. 

        IQueryable<X> Select<X>(Expression<Func<T, X>> exp);//Burada açtığımız select method'u anonymus type mapping'e destek veremez. Bizim methodu çağırdığımızda Generic olarak koyduğumuz yapıya destek verir.

        //Expression yapısı içerisinde bu method kümesini çalıştıran delegate'in işlem yapabilmesi adına ayrılmış 2 kısım vardır.
        //
        //Örnek x=> x.CategoryName == "afasdfdsf";
        //
        //birinci kısım expression tipinin parametresidir  x=> (burada lampda operatörü ile kendini şekillendiriyor ve method'dan önce hangi DbSet'e gidilmiş ona bakıyor _db.Products , _db.Categories vs..)
        //
        //ikinci kısım x.CategoryName == "afasdfdsf"; burada çalışan bir delegate'imiz var bu da Func delegate(İçerisinde değer döndüren ve parametre alan methodları barındıran bir delegate)

        //Mesela biz 4 method'u kümelemek için neden 5.method açıp onları içersinde kümelemeyip çağırmıyoruz? Çünkü expression bir class'dır ve generic olarak bir delegate ister, method alamaz.


        //Find Commands
        Task<T> FindAsync(int id);
        List<T> GetLastDatas(int count);
        List<T> GetFirstDatas(int count);


        //Command'ların veya Queryable'lerin TSQ'ele dönüştürülmesi lazım. Dolayısıyla bu Command ve Queryable'lerde ifade etmek istediğimiz, kullandığımız programlama dilindeki ifadeler entity framework (veya hangi veri tabanı erişimi teknolojisiyle çalışıyorsak) tarafından yorumlanır ve TSQ'e çevrilmiş bir şekilde gönderilir.

        //Gönderdiğimiz teknolojilerde asenkson metotların yanında düz metotlarında olmasını isteriz. Eğer bu sistem bir web sisteminde çalışmayacak ise bir konsol sisteminde veya masaüstü programlama sisteminde çalışacaksa ve başkalarını kitleme gibi bir durum olmayacaksa asenkron metot kullanmak over engineering'dir.(aşırı, gereksiz) Bu yüzden düz metotlarında olması iyidir.

        //Entity Framework'ün bazı metotları full async çalışır. Bunun nedeni API tarafıyla çok bağlantılı olmalarıdır.

        //Bir metodun düz çalışmasını istesek bile asenk olarak oluşturmanın dezavantajı yoktur fakat gereksizdir.

        //Repository dediğimiz şey ekleme, silme, güncelleme vs. yapar. Bunu yaparken başka bir şey ile ilgilenmez. Buraya o emri manager(BLL) gönderir. 
    }
}
