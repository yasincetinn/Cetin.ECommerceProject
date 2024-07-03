using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Project.COMMON.Tools;
using Project.CoreMVC.Models;
using Project.CoreMVC.Models.AppUsers;
using Project.ENTITIES.Models;
using System.Diagnostics;
using SignInResult = Microsoft.AspNetCore.Identity.SignInResult;
using System.Net.Mail;
using Microsoft.EntityFrameworkCore;
using NuGet.Common;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.Extensions.Hosting;
using static System.Net.WebRequestMethods;
using System.Security.Policy;

namespace Project.CoreMVC.Controllers
{ 
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        readonly UserManager<AppUser> _userManager;
        readonly RoleManager<IdentityRole<int>> _roleManager;
        readonly SignInManager<AppUser> _signInManager;

        public HomeController(ILogger<HomeController> logger, UserManager<AppUser> userManager, RoleManager<IdentityRole<int>> roleManager, SignInManager<AppUser> signInManager)
        {
            _logger = logger;
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Register() 
        {
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> Register(UserRegisterModel model) //Kayýt Olma
        {
            if (ModelState.IsValid)
            {
                Guid specId = Guid.NewGuid();

                AppUser appUser = new()
                {
                    UserName = model.UserName,
                    Email = model.Email,
                    ActivationCode = specId //User eklenirken aktivasyon koduda eklensin
                };

                IdentityResult result = await _userManager.CreateAsync(appUser, model.Password);

                if (result.Succeeded)
                {
                    #region RolKontrolIslemleri

                    IdentityRole<int> appRole = await _roleManager.FindByNameAsync("Member");

                    if (appRole == null) await _roleManager.CreateAsync(new() { Name = "Member" });

                    await _userManager.AddToRoleAsync(appUser, "Member"); //appUser'i member rolüne ekle

                    #endregion

                    string body = $"Your account has been created. To confirm your membership, please click on the link -> http://localhost:5233/Home/ConfirmEmail?specId={specId}&id={appUser.Id}";

                    MailService.Send(model.Email, body: body); //Comman Katmanýndaki MailService class'ýnda parametre olarak verdiðimiz diðer kalan bilgiler ayný...

                    TempData["Message"] = "Confirm your email address. \n We have sent an email with a confirmation link to your email address.";
                    return RedirectToAction("MailPanel");
                }

                foreach (IdentityError error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }

            return View(model);
        }

        public async Task<IActionResult> ConfirmEmail(Guid specId, int id) //Yukaridaki linke basýnca oradaki specId ve user id'si buraya denk düþecek..
        {
            AppUser user = await _userManager.FindByIdAsync(id.ToString());

            if (user == null)
            {
                TempData["Message"] = "User not found";
                return RedirectToAction("MailPanel");
            }

            else if (user.ActivationCode == specId) //user bulunduysa specId'si aktivasyonla ayný mý kontrol ediyoruz
            {
                user.EmailConfirmed = true;
                await _userManager.UpdateAsync(user);
                TempData["message"] = "Your email has been confirmed successfully";
                return RedirectToAction("SignIn"); //Hepsini geçtiyse signIn'e yönlendiriyoruz
            }

            return RedirectToAction("Register"); //bunlarýn hiçbirini geçemezse register'e dön..
        }

        public IActionResult SignIn()
        {
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> SignIn(UserSignInModel model) //Giris Yapma
        {
            if (ModelState.IsValid)
            {
                AppUser appUser = await _userManager.FindByNameAsync(model.UserName);

                SignInResult result = await _signInManager.PasswordSignInAsync(appUser, model.Password, true, true);

                //bool isPersistent : cookie'e kaydolsun mu?
                //bool LockOutOnFailure : Password fail durumu

                if (result.Succeeded) //Giriþ baþarýlýysa
                {
                    IList<string> roles = await _userManager.GetRolesAsync(appUser);

                    if (roles.Contains("Admin"))
                    {
                        return RedirectToAction("Index", "Category", new { Area = "Admin" });
                    }

                    else if (roles.Contains("Member"))
                    {
                        return RedirectToAction("Privacy");
                    }

                    return RedirectToAction("Panel");
                }

                else if (result.IsNotAllowed) //Email onaylý deðilse
                {
                    return RedirectToAction("MailPanel");
                }

                TempData["Message"] = "User not found"; //Kullanýcý bulunamadý
                return RedirectToAction("SignIn");
            }

            return View(model);
        }

        public IActionResult Logout()
        {
            _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Shopping");
        }


        [Authorize(Roles = "Member")]
        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]  //Bu attribute, Cross-Site Request Forgery (CSRF) saldýrýlarýna karþý koruma saðlar ve böylece sunucunun istemci tarafýndan gönderilen isteklerin güvenilirliðini doðrulamasýna yardýmcý olur.
        public async Task<IActionResult> ForgotPassword(ForgotPasswordModel model)
        {
            AppUser user = await _userManager.Users.FirstOrDefaultAsync(u => u.Email == model.Email); // Kullanýcýnýn e-posta adresine göre AppUser nesnesini veritabanýndan bulur .  FirstOrDefaultAsync, veri tabanýndan ilk uygun kullanýcýyý getirir. Eðer u.Email == model.Email koþuluna uyan bir kullanýcý yoksa null döner. Bu durum, veritabanýndan gereksiz yere tüm verileri almak yerine, sadece ilgili kullanýcýya ait verilerin alýnmasýný saðlar, bu da performansý artýrýr.

            if (user != null)
            {
                string userToken = await _userManager.GeneratePasswordResetTokenAsync(user); // Kullanýcý bulunduysa, yeni bir þifre sýfýrlama token'i oluþturulur

                string passwordTokenLink = Url.Action("ResetPassword", "Home", new { userId = user.Id, token = userToken }, HttpContext.Request.Scheme); // passwordTokenLink deðiþkeni, doðru þema (http veya https) ile baþlayan bir URL saðlar, böylece kullanýcýlar güvenli ve doðru bir þekilde yönlendirilebilir HttpContext.Request.Scheme mevcut HTTP isteðinin þemasýný belirler ve genellikle URL oluþturma ve yönlendirme iþlemlerinde kullanýlýr.

                MailService.Send(model.Email, subject: "Reset Password", body: $"Reset your password by clicking -> {passwordTokenLink}");

                TempData["Message"] = "Password reset email has been sent. Please check your email box.."; //Þifre sýfýrlama e-postasý gönderildi. Lütfen e-posta kutunuzu kontrol edin.

                return RedirectToAction("MailPanel");
            }

            return View(model);

        }

        public IActionResult MailPanel()
        {
            return View();
        }

        public IActionResult ResetPassword(string userId, string token)  //userId ve token parametreleri, kullanýcýnýn kimliðini ve geçerli bir þifre sýfýrlama iþlemi için gerekli olan geçici bir token'i temsil eder. Bu bilgiler TempData kullanýlarak geçici olarak saklanýr ve bir sonraki POST isteðinde kullanýlabilir.
        {
            TempData["userId"] = userId;
            TempData["token"] = token;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]  //Bu attribute, Cross-Site Request Forgery (CSRF) saldýrýlarýna karþý koruma saðlar ve böylece sunucunun istemci tarafýndan gönderilen isteklerin güvenilirliðini doðrulamasýna yardýmcý olur.
        public async Task<IActionResult> ResetPassword(ResetPasswordModel model) 
        {
            string userId = (string)TempData["userId"];  //TempData üzerinden alýnan userId ve token ile kullanýcý doðrulanýr. (FindByIdAsync kullanýlarak).

            string token = (string)TempData["token"];  //Tempdata object türde olduðu için strig türde cast ettik.

            if (ModelState.IsValid)
            {
                AppUser user = await _userManager.FindByIdAsync(userId.ToString());

                IdentityResult result = await _userManager.ResetPasswordAsync(user, token, model.NewPassword); //Kullanýcýya ait þifre resetlenir(ResetPasswordAsync kullanýlarak).

                

                if (result.Succeeded) //Þifre sýfýrlama iþlemi baþarýlýysa, kullanýcýya bir bildirim gönderilir.
                {
                    TempData["Message"] = "Your password has been reset successfully."; //Þifreniz baþarýyla sýfýrlandý

                    return RedirectToAction("SignIn"); // Þifre sýfýrlama baþarýlýysa giriþ sayfasýna yönlendirilebilir
                }

                foreach (IdentityError error in result.Errors)  
                {
                    ModelState.AddModelError("", error.Description);
                }
            }

            // Eðer kullanýcý doðrulanamazsa veya token geçersizse, hata mesajý eklenerek view'e geri dönülür.
            return View(model);
        }
    }
}
