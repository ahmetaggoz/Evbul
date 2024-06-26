﻿using System.Security.Claims;
using Evbul.Data.Abstract;
using Evbul.Data.Concrete.EfCore;
using Evbul.Entity;
using Evbul.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Evbul.Controllers;

public class EvlerController : Controller
{
    private readonly IEvRepository _evRepository;
    private readonly IYorumRepository _yorumRepository;
    private readonly IOzellikRepository _ozellikRepository;
    public EvlerController(IEvRepository evRepository, IYorumRepository yorumRepository, IOzellikRepository ozellikRepository)
    {
        _evRepository = evRepository;
        _yorumRepository = yorumRepository;
        _ozellikRepository = ozellikRepository;
    
    }
    public async Task<IActionResult> Index(string ozellik)
    {
        var evler = _evRepository.Evler.Where(e => e.AktifMi);
        if(!string.IsNullOrEmpty(ozellik))
        {
            evler = evler.Where(x => x.Ozellikler.Any(t => t.Url == ozellik));
        }
        return View(
            new EvViewModel
            {
                Evler = await evler.ToListAsync()
            }
        );
    }
    public async Task<IActionResult> Detay(string url)
    {
        return View(await 
        _evRepository
        .Evler
        .Include(x => x.Kullanici)
        .Include(x => x.Ozellikler)
        .Include(y => y.Yorumlar)
        .ThenInclude(k => k.Kullanici)
        .FirstOrDefaultAsync(e => e.Url == url));
    }
    [HttpPost]
    public JsonResult YorumEkle(int EvId,  string Yazi)
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        var username = User.FindFirstValue(ClaimTypes.Name);
        var avatar = User.FindFirstValue(ClaimTypes.UserData);

        var entity = new Yorum 
        {
            EvId = EvId,
            Yazi = Yazi,
            Tarih = DateTime.Now,
            KullaniciId = int.Parse(userId ?? "")
        };
        _yorumRepository.YorumOlustur(entity);
       return Json(new {
        username,
        Yazi,
        entity.Tarih,
        avatar
       });
    }
    [Authorize]
    public IActionResult Olustur()
    {
        return View();
    }
    [HttpPost]
    [Authorize]
    public IActionResult Olustur(EvOlusturViewModel model)
    {
        if(ModelState.IsValid)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            _evRepository.EvOlustur(
                new Ev {
                    Baslik = model.Baslik,
                    Aciklama = model.Aciklama,
                    Kapasite = model.Kapasite,
                    YatakOdasi = model.YatakOdasi,
                    YatakSayisi = model.YatakSayisi,
                    Banyo = model.Banyo,
                    Fiyat = model.Fiyat,
                    KullaniciId = int.Parse(userId 
                    ?? ""),
                    YayinlamaTarihi = DateTime.Now,
                    Image = "1.jpg",
                    AktifMi = false
                }
            );
            return RedirectToAction("Index");
        }
        return View(model);
    }
    [Authorize]
    public async Task<IActionResult> List()
    {
        var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier) ?? "");
        var role = User.FindFirstValue(ClaimTypes.Role);

        var evler = _evRepository.Evler;

        if(string.IsNullOrEmpty(role))
        {
            evler = evler.Where(e => e.KullaniciId == userId);
        }
        return View(await evler.ToListAsync());
    }
    [Authorize]

    public IActionResult Edit(int? id)
    {
        if(id == null)
        {
            return NotFound();
        }

        var ev = _evRepository.Evler.Include(x => x.Ozellikler).FirstOrDefault(e => e.EvId == id);

        if(ev == null)
        {
            return NotFound();
        }
        ViewBag.Ozellikler = _ozellikRepository.Ozellikler.ToList();
        return View(new EvOlusturViewModel {
            EvId = ev.EvId,
            Baslik = ev.Baslik,
            Aciklama = ev.Aciklama,
            Kapasite = ev.Kapasite,
            YatakOdasi = ev.YatakOdasi,
            YatakSayisi = ev.YatakSayisi,
            Banyo = ev.Banyo,
            Fiyat = ev.Fiyat,
            Url = ev.Url,
            AktifMi = ev.AktifMi,
            Ozellikler = ev.Ozellikler
        });
    }
    [Authorize]
    [HttpPost]
    public IActionResult Edit(EvOlusturViewModel model, int[] ozelliklerIdler)
    {
        if(ModelState.IsValid)
        {
            var entityToUpdate = new Ev {
                EvId = model.EvId,
                Baslik = model.Baslik,
                Aciklama = model.Aciklama,
                Kapasite = model.Kapasite,
                YatakOdasi = model.YatakOdasi,
                YatakSayisi = model.YatakSayisi,
                Banyo = model.Banyo,
                Fiyat = model.Fiyat,
                Url = model.Url,
                AktifMi = model.AktifMi
            };
            
            if(User.FindFirstValue(ClaimTypes.Role) == "admin")
            {
                entityToUpdate.AktifMi = model.AktifMi;
            }


            _evRepository.EditEv(entityToUpdate, ozelliklerIdler);
            return RedirectToAction("List");
        }
        ViewBag.Ozellikler = _ozellikRepository.Ozellikler.ToList();
        return View(model);
    }
}
