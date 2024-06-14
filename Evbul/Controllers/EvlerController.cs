using System.Security.Claims;
using Evbul.Data.Abstract;
using Evbul.Data.Concrete.EfCore;
using Evbul.Entity;
using Evbul.Models;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Evbul.Controllers;

public class EvlerController : Controller
{
    private readonly IEvRepository _evRepository;
    private readonly IYorumRepository _yorumRepository;
    public EvlerController(IEvRepository evRepository, IYorumRepository yorumRepository)
    {
        _evRepository = evRepository;
        _yorumRepository = yorumRepository;
    
    }
    public async Task<IActionResult> Index(string ozellik)
    {
        var evler = _evRepository.Evler;
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
    public IActionResult Olustur()
    {
        return View();
    }
    [HttpPost]
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
}
