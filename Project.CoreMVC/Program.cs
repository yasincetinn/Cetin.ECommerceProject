using FluentValidation.AspNetCore;
using Microsoft.Extensions.Options;
using Project.BLL.ServiceInjections;
using System.Reflection;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddHttpClient(); //E�er bir API consume edilecekse HTTP protokol�nde client taraf�nda oldu�umuzu Middleware'e bildirmeliyiz.

builder.Services.AddControllersWithViews().AddFluentValidation(x=> x.RegisterValidatorsFromAssemblyContaining<Program>());

builder.Services.AddDistributedMemoryCache(); //E�er session kompleks yap�larla �al��mak i�in Extension metodu eklenme durumuna maruz kalm��sa bu kod projenizin sa�l�kl� �al��mas� i�in gereklidir. (Memory'de par�alay�p da��t, tek bir blokta tutma)

builder.Services.AddSession(x =>
{
    x.IdleTimeout = TimeSpan.FromMinutes(5); //IdleTimeout genellikle bir kullan�c�n�n belirli bir s�re boyunca hi�bir etkile�imde bulunmamas� durumunda oturumun otomatik olarak sonland�r�laca�� s�reyi belirtir. TimeSpan.FromMinutes(5) ifadesi ise 5 dakika olarak ayarlanm�� bir TimeSpan nesnesi olu�turur.Yani, kullan�c� 5 dakika boyunca herhangi bir etkile�imde bulunmazsa oturumu otomatik olarak sonland�rabilir.

    x.Cookie.HttpOnly = true; //document.cookie'nin ilgili bilginin g�zlemlenmesi (HttpOnly �zelli�i, taray�c�lar�n JavaScript kodu arac�l���yla eri�ilmesini engeller ve yaln�zca HTTP (ve HTTPS) �zerinden sunucuya iletilmesini sa�lar. Bu g�venlik �nlemi, �erezlerin k�t� ama�l� JavaScript kodlar� taraf�ndan ele ge�irilmesini �nler.)

    x.Cookie.IsEssential = true; //IsEssential �zelli�i, �erezin temel (essential) olup olmad���n� belirtir. Temel �erezler, kullan�c�n�n iste�ine bak�lmaks�z�n oturum y�netimi gibi temel i�levler i�in gerekli olan �erezlerdir. Kullan�c� bu �erezleri devre d��� b�rakamaz veya reddedemez.
});

builder.Services.AddIdentityService();
builder.Services.AddDbContextService();//DbContextService'imizi BLL'den alarak middleware'e entegre ettik
builder.Services.AddRepServices();
builder.Services.AddManagerServices();


WebApplication app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseSession();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllerRoute(
    name:"Admin",
    pattern: "{area}/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Shopping}/{action=Index}/{id?}");

app.Run();
