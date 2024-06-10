using Evbul.Data.Abstract;
using Evbul.Data.Concrete.EfCore;
using Evbul.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Evbul.Controllers;

public class EvlerController : Controller
{
    private readonly IEvRepository _evRepository;
    public EvlerController(IEvRepository evRepository)
    {
        _evRepository = evRepository;
    
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
        .FirstOrDefaultAsync(e => e.Url == url));
    }
}
