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
        var claims = User.Claims;
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
    public JsonResult YorumEkle(int EvId, string KullaniciAd, string Yazi)
    {
        var entity = new Yorum 
        {
            Yazi = Yazi,
            Tarih = DateTime.Now,
            EvId = EvId,
            Kullanici = new Kullanici {KullaniciAd = KullaniciAd, Image = "avatar.png"}
        };
        _yorumRepository.YorumOlustur(entity);
       return Json(new {
        KullaniciAd,
        Yazi,
        entity.Tarih,
        entity.Kullanici.Image
       });
    }
}
