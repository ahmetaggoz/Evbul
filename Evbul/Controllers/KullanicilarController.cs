using Microsoft.AspNetCore.Mvc;

namespace Evbul.Controllers;

public class KullanicilarController:Controller
{
    public KullanicilarController()
    {
        
    }

    public IActionResult Giris()
    {
        return View();
    }
}
