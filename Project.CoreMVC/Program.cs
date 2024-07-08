using FluentValidation.AspNetCore;
using Microsoft.Extensions.Options;
using Project.BLL.ServiceInjections;
using System.Reflection;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddHttpClient(); //Eðer bir API consume edilecekse HTTP protokolünde client tarafýnda olduðumuzu Middleware'e bildirmeliyiz.

builder.Services.AddControllersWithViews().AddFluentValidation(x=> x.RegisterValidatorsFromAssemblyContaining<Program>());

builder.Services.AddDistributedMemoryCache(); //Eðer session kompleks yapýlarla çalýþmak için Extension metodu eklenme durumuna maruz kalmýþsa bu kod projenizin saðlýklý çalýþmasý için gereklidir. (Memory'de parçalayýp daðýt, tek bir blokta tutma)

builder.Services.AddSession(x =>
{
    x.IdleTimeout = TimeSpan.FromMinutes(5); //IdleTimeout genellikle bir kullanýcýnýn belirli bir süre boyunca hiçbir etkileþimde bulunmamasý durumunda oturumun otomatik olarak sonlandýrýlacaðý süreyi belirtir. TimeSpan.FromMinutes(5) ifadesi ise 5 dakika olarak ayarlanmýþ bir TimeSpan nesnesi oluþturur.Yani, kullanýcý 5 dakika boyunca herhangi bir etkileþimde bulunmazsa oturumu otomatik olarak sonlandýrabilir.

    x.Cookie.HttpOnly = true; //document.cookie'nin ilgili bilginin gözlemlenmesi (HttpOnly özelliði, tarayýcýlarýn JavaScript kodu aracýlýðýyla eriþilmesini engeller ve yalnýzca HTTP (ve HTTPS) üzerinden sunucuya iletilmesini saðlar. Bu güvenlik önlemi, çerezlerin kötü amaçlý JavaScript kodlarý tarafýndan ele geçirilmesini önler.)

    x.Cookie.IsEssential = true; //IsEssential özelliði, çerezin temel (essential) olup olmadýðýný belirtir. Temel çerezler, kullanýcýnýn isteðine bakýlmaksýzýn oturum yönetimi gibi temel iþlevler için gerekli olan çerezlerdir. Kullanýcý bu çerezleri devre dýþý býrakamaz veya reddedemez.
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
