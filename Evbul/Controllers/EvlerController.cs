using Evbul.Data.Abstract;
using Evbul.Data.Concrete.EfCore;
using Evbul.Models;
using Microsoft.AspNetCore.Mvc;

namespace Evbul.Controllers;

public class EvlerController : Controller
{
    private readonly IEvRepository _evRepository;
    public EvlerController(IEvRepository evRepository)
    {
        _evRepository = evRepository;
    
    }
    public IActionResult Index()
    {
        return View(
            new EvViewModel
            {
                Evler = _evRepository.Evler.ToList()
            }
        );
    }
}
