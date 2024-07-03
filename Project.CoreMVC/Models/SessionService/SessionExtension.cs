using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json;

namespace Project.CoreMVC.Models.SessionService
{
    public static class SessionExtension
    {
        //Bu sınıf, ISession arabirimine genişletme metodları ekleyerek session işlemlerini kolaylaştırmak amacıyla tasarlanmıştır. JSON formatında nesne serileştirme ve deserileştirme işlemlerini kullanarak nesneleri session üzerinde depolamayı ve almayı sağlar.


        public static void SetObject(this ISession session, string key, object value) //SetObject metodu, ISession türündeki bir nesneye genişletme metodunu ekler. Session: Session nesnesi. Key: Depolanan nesnenin anahtarı. Value: Depolanacak nesne.
        {
            string objectString = JsonConvert.SerializeObject(value);  //JsonConvert.SerializeObject(value) -> value parametresini JSON formatına dönüştürür.
            session.SetString(key, objectString); //JSON formatına dönüştürülmüş nesneyi key anahtarıyla session'a kaydeder.

            //Kısaca bu metod, session'a bir nesneyi kaydetmek için kullanılır. Nesne önce JSON formatına dönüştürülür ve sonra session'a string olarak kaydedilir.
        }


        public static T GetObject<T>(this ISession session, string key) where T : class //GetObject<T> metodu, ISession türündeki bir nesneye genişletme metodunu ekler. Bu metod generic bir metottur ve dönüş tipi T olmalıdır (sınırlama olarak class kullanılmış). Session: Session nesnesi. Key: Alınacak nesnenin anahtarı.
        {
            string objectString = session.GetString(key); //session.GetString(key): Belirtilen key anahtarına sahip veriyi string olarak alır.

            if (!string.IsNullOrEmpty(objectString))
            {
                T deserializedObject = JsonConvert.DeserializeObject<T>(objectString); //JsonConvert.DeserializeObject<T>(objectString): JSON formatındaki string'i belirtilen T türüne dönüştürür.

                return deserializedObject; //Eğer session'da key anahtarında bir veri yoksa veya dönüştürme işlemi başarısız olursa (objectString null veya boş ise), null değeri döner.
            }

            return null; //Eğer session'da key anahtarında bir veri yoksa veya dönüştürme işlemi başarısız olursa (objectString null veya boş ise), null değeri döner.
        }
    }
}
