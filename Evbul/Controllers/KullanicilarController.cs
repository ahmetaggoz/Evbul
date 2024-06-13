using System.Security.Claims;
using Evbul.Data.Abstract;
using Evbul.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Evbul.Controllers;

public class KullanicilarController : Controller
{
    private readonly IKullaniciRepository _kullaniciRepository;
    public KullanicilarController(IKullaniciRepository kullaniciRepository)
    {
        _kullaniciRepository = kullaniciRepository;
    }

    public IActionResult Giris()
    {
        if(User.Identity!.IsAuthenticated)
        {
            return RedirectToAction("Index", "Evler");
        }
        return View();
    }
    public IActionResult Kayit()
    {
        
        return View();
    }
    [HttpPost]
    public IActionResult Kayit(KayitViewModel model)
    {
        if(ModelState.IsValid)
        {
            return RedirectToAction("Giris");
        }
        return View(model);
    }

    public async Task<IActionResult> Cikis()
    {
        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        return RedirectToAction("Giris");
    }
    [HttpPost]
    public async Task<IActionResult> Giris(GirisViewModel model)
    {
        if (ModelState.IsValid)
        {
            var isUser = await _kullaniciRepository.Kullanicilar.FirstOrDefaultAsync(u => u.Eposta == model.Eposta && u.Parola == model.Parola);

            if (isUser != null)
            {
                var userClaims = new List<Claim>();

                userClaims.Add(new Claim(ClaimTypes.NameIdentifier, isUser.KullaniciId.ToString()));
                userClaims.Add(new Claim(ClaimTypes.Name, isUser.KullaniciAd ?? ""));
                userClaims.Add(new Claim(ClaimTypes.GivenName, isUser.Ad ?? ""));
                userClaims.Add(new Claim(ClaimTypes.UserData, isUser.Image ?? ""));

                if(isUser.Eposta == "info@ahmetaggoz.com")
                {
                    userClaims.Add(new Claim(ClaimTypes.Role, "admin"));
                }

                var claimsIdentity = new ClaimsIdentity(userClaims, CookieAuthenticationDefaults.AuthenticationScheme);

                var authProperties = new AuthenticationProperties {
                    IsPersistent = true
                };

                await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity),
                    authProperties
                );

                return RedirectToAction("Index", "Evler");
            }
            else
            {
                ModelState.AddModelError("", "Kullanıcı adı veya şifre yanlış");
            }
        }

        return View(model);
    }
}
