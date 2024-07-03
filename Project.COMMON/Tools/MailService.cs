using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Project.COMMON.Tools
{
    //Comman katmanı ortak katmandır. Yani projede ortak yapılması gereken işlemlerin bulunacağı yerdir..

    //Bu class'ımız mail gönderecek

    public static class MailService
    {
        // BİLGİ : Parametrelerimiz defaut değer almaya başladıysa onları takip eden parametreler değer almazsa syntax hatası verir. Default değer almayacak parametrelerimizi değer alanlardan önce yazmak gerekir. 

        //string receiver = email alıcısı
        //string password = SMTP, "Simple Mail Transfer Protocol" (Basit Posta Transfer Protokolü (SMTP, bir e-posta istemcisi (örneğin, Outlook, Gmail) tarafından gönderilen e-posta iletilerini alıcıların e-posta sunucularına iletmek için kullanılır.)
        //string body = emailin içerindeki gövde(içeriği)
        //string subject = Emailin başlığı
        //string sender = Gönderen kişi


        public static void Send(string receiver, string password = "hpgljsrxxgxptjwl", string body = "Confirm your membership by clicking on the link", string subject = "Confirm Email", string senderName = "Cetin Online Market", string cetinEmail = "yasncetn8990@outlook.com")
        {
            //MailAddress bize mail adres nesnesi vermekte.
            MailAddress senderEmail = new(cetinEmail, senderName);
            MailAddress receiverEmail = new(receiver);

            SmtpClient smtp = new() //SmtpClient sınıfından yeni bir örnek(smtp) oluşturulur.Bu örnek, e-posta göndermek için SMTP sunucusuna bağlanmak ve ileti göndermek için kullanılacak.
            {
                Host = "smtp-mail.outlook.com", //Host özelliği, SMTP sunucusunun adresini belirtir.
                Port = 587, //Port özelliği, SMTP sunucusuna bağlanmak için kullanılacak port numarasını belirtir.
                EnableSsl = true, //EnableSsl özelliği, SMTP bağlantısında SSL/TLS şifrelemesinin kullanılıp kullanılmayacağını belirtir. true olarak ayarlandığında, bağlantı SSL/TLS ile güvenli hale getirilir.
                DeliveryMethod = SmtpDeliveryMethod.Network, //DeliveryMethod özelliği, e-posta iletilerinin nasıl teslim edileceğini belirtir. SmtpDeliveryMethod.Network olarak ayarlandığında, iletiler SMTP ağı üzerinden gönderilir.
                UseDefaultCredentials = false, //UseDefaultCredentials özelliği, varsayılan kimlik doğrulama bilgilerinin kullanılıp kullanılmayacağını belirtir. false olarak ayarlandığında, kullanıcı tarafından belirtilen kimlik bilgileri (Credentials özelliği) kullanılır.
                Credentials = new NetworkCredential(senderEmail.Address, password) //Credentials özelliği, SMTP sunucusuna bağlanmak için kullanılacak kimlik doğrulama bilgilerini belirtir. NetworkCredential sınıfı kullanılarak, e-posta gönderenin adresi (senderEmail.Address) ve şifresi (password) belirtilir.
            };


            using (MailMessage message = new MailMessage(senderEmail, receiverEmail) //MailMessage sınıfı, gönderici (senderEmail) ve alıcı (receiverEmail) e-posta adreslerini alarak bir e-posta ileti objesi oluşturur. using ifadesi kullanıldığı için MailMessage objesi, işlem tamamlandıktan sonra otomatik olarak kapatılacak ve kaynakları serbest bırakılacaktır.
            {
                Subject = subject, //Eposta başlığı (konusu)
                Body = body //Eposta içeriği
            })
            {
                smtp.Send(message); //SmtpClient (smtp değişkeni) üzerinden Send metodu çağrılarak, oluşturulan MailMessage (message) ileti objesi SMTP sunucusuna gönderilir. Bu işlem, SMTP sunucusu üzerinden e-posta iletiyi alıcıya iletmek için gereken adımları gerçekleştirir.

            } //Burada yaratılan şey burada yaşasın ve ölsün (garbage collector)

            #region 2.yontem

            /* 
              MailMessage message = new(senderEmail, receiverEmail)
           {
               Subject = subject,
               Body = body
           };

           smtp.Send(message);

            */

            #endregion

        }
    }
}
