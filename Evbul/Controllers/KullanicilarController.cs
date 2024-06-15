﻿using System.IO.Compression;
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
    public async Task<IActionResult> Kayit(KayitViewModel model, IFormFile imgFile)
    {
        var extension = Path.GetExtension(imgFile.FileName);
        var randomFileName = string.Format($"{Guid.NewGuid().ToString()}{extension}");
        var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img", randomFileName);
        if(ModelState.IsValid)
        {
            
            var user = await _kullaniciRepository.Kullanicilar.FirstOrDefaultAsync(u => u.Eposta == model.Eposta || u.KullaniciAd == model.KullaniciAd);

            if(user == null)
            {
                using(var stream = new FileStream(path, FileMode.Create))
                {
                    await imgFile.CopyToAsync(stream);
                }
                _kullaniciRepository.KullaniciOlustur(new Entity.Kullanici {
                    KullaniciAd = model.KullaniciAd,
                    Ad = model.Ad,
                    Eposta = model.Eposta,
                    Parola = model.Parola,
                    Image = randomFileName
                });
                return RedirectToAction("Giris");

            }else
            {
                ModelState.AddModelError("", "Kullanıcı Adı ve ya Eposta kullanımda");
            }
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

    public IActionResult Profile(string username)
    {
        if(string.IsNullOrEmpty(username))
        {
            return NotFound();
        }
        var kullanici = _kullaniciRepository
                        .Kullanicilar
                        .Include(x => x.Evler)
                        .Include(x => x.Yorumlar)
                        .ThenInclude(x => x.Ev)
                        .FirstOrDefault(x => x.KullaniciAd == username);
        if(kullanici == null)
        {
            return NotFound();
        }
        return View(kullanici);
    }
}
