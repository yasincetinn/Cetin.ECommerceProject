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

        public async Task<IActionResult> Register(UserRegisterModel model) //Kay�t Olma
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

                    await _userManager.AddToRoleAsync(appUser, "Member"); //appUser'i member rol�ne ekle

                    #endregion

                    string body = $"Your account has been created. To confirm your membership, please click on the link -> http://localhost:5233/Home/ConfirmEmail?specId={specId}&id={appUser.Id}";

                    MailService.Send(model.Email, body: body); //Comman Katman�ndaki MailService class'�nda parametre olarak verdi�imiz di�er kalan bilgiler ayn�...

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

        public async Task<IActionResult> ConfirmEmail(Guid specId, int id) //Yukaridaki linke bas�nca oradaki specId ve user id'si buraya denk d��ecek..
        {
            AppUser user = await _userManager.FindByIdAsync(id.ToString());

            if (user == null)
            {
                TempData["Message"] = "User not found";
                return RedirectToAction("MailPanel");
            }

            else if (user.ActivationCode == specId) //user bulunduysa specId'si aktivasyonla ayn� m� kontrol ediyoruz
            {
                user.EmailConfirmed = true;
                await _userManager.UpdateAsync(user);
                TempData["message"] = "Your email has been confirmed successfully";
                return RedirectToAction("SignIn"); //Hepsini ge�tiyse signIn'e y�nlendiriyoruz
            }

            return RedirectToAction("Register"); //bunlar�n hi�birini ge�emezse register'e d�n..
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

                if (result.Succeeded) //Giri� ba�ar�l�ysa
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

                else if (result.IsNotAllowed) //Email onayl� de�ilse
                {
                    return RedirectToAction("MailPanel");
                }

                TempData["Message"] = "User not found"; //Kullan�c� bulunamad�
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
        [ValidateAntiForgeryToken]  //Bu attribute, Cross-Site Request Forgery (CSRF) sald�r�lar�na kar�� koruma sa�lar ve b�ylece sunucunun istemci taraf�ndan g�nderilen isteklerin g�venilirli�ini do�rulamas�na yard�mc� olur.
        public async Task<IActionResult> ForgotPassword(ForgotPasswordModel model)
        {
            AppUser user = await _userManager.Users.FirstOrDefaultAsync(u => u.Email == model.Email); // Kullan�c�n�n e-posta adresine g�re AppUser nesnesini veritaban�ndan bulur .  FirstOrDefaultAsync, veri taban�ndan ilk uygun kullan�c�y� getirir. E�er u.Email == model.Email ko�uluna uyan bir kullan�c� yoksa null d�ner. Bu durum, veritaban�ndan gereksiz yere t�m verileri almak yerine, sadece ilgili kullan�c�ya ait verilerin al�nmas�n� sa�lar, bu da performans� art�r�r.

            if (user != null)
            {
                string userToken = await _userManager.GeneratePasswordResetTokenAsync(user); // Kullan�c� bulunduysa, yeni bir �ifre s�f�rlama token'i olu�turulur

                string passwordTokenLink = Url.Action("ResetPassword", "Home", new { userId = user.Id, token = userToken }, HttpContext.Request.Scheme); // passwordTokenLink de�i�keni, do�ru �ema (http veya https) ile ba�layan bir URL sa�lar, b�ylece kullan�c�lar g�venli ve do�ru bir �ekilde y�nlendirilebilir HttpContext.Request.Scheme mevcut HTTP iste�inin �emas�n� belirler ve genellikle URL olu�turma ve y�nlendirme i�lemlerinde kullan�l�r.

                MailService.Send(model.Email, subject: "Reset Password", body: $"Reset your password by clicking -> {passwordTokenLink}");

                TempData["Message"] = "Password reset email has been sent. Please check your email box.."; //�ifre s�f�rlama e-postas� g�nderildi. L�tfen e-posta kutunuzu kontrol edin.

                return RedirectToAction("MailPanel");
            }

            return View(model);

        }

        public IActionResult MailPanel()
        {
            return View();
        }

        public IActionResult ResetPassword(string userId, string token)  //userId ve token parametreleri, kullan�c�n�n kimli�ini ve ge�erli bir �ifre s�f�rlama i�lemi i�in gerekli olan ge�ici bir token'i temsil eder. Bu bilgiler TempData kullan�larak ge�ici olarak saklan�r ve bir sonraki POST iste�inde kullan�labilir.
        {
            TempData["userId"] = userId;
            TempData["token"] = token;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]  //Bu attribute, Cross-Site Request Forgery (CSRF) sald�r�lar�na kar�� koruma sa�lar ve b�ylece sunucunun istemci taraf�ndan g�nderilen isteklerin g�venilirli�ini do�rulamas�na yard�mc� olur.
        public async Task<IActionResult> ResetPassword(ResetPasswordModel model) 
        {
            string userId = (string)TempData["userId"];  //TempData �zerinden al�nan userId ve token ile kullan�c� do�rulan�r. (FindByIdAsync kullan�larak).

            string token = (string)TempData["token"];  //Tempdata object t�rde oldu�u i�in strig t�rde cast ettik.

            if (ModelState.IsValid)
            {
                AppUser user = await _userManager.FindByIdAsync(userId.ToString());

                IdentityResult result = await _userManager.ResetPasswordAsync(user, token, model.NewPassword); //Kullan�c�ya ait �ifre resetlenir(ResetPasswordAsync kullan�larak).

                

                if (result.Succeeded) //�ifre s�f�rlama i�lemi ba�ar�l�ysa, kullan�c�ya bir bildirim g�nderilir.
                {
                    TempData["Message"] = "Your password has been reset successfully."; //�ifreniz ba�ar�yla s�f�rland�

                    return RedirectToAction("SignIn"); // �ifre s�f�rlama ba�ar�l�ysa giri� sayfas�na y�nlendirilebilir
                }

                foreach (IdentityError error in result.Errors)  
                {
                    ModelState.AddModelError("", error.Description);
                }
            }

            // E�er kullan�c� do�rulanamazsa veya token ge�ersizse, hata mesaj� eklenerek view'e geri d�n�l�r.
            return View(model);
        }
    }
}
