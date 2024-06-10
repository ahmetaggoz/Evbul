using Evbul.Data.Abstract;
using Evbul.Data.Concrete.EfCore;
using Evbul.Models;
using Microsoft.AspNetCore.Mvc;

namespace Evbul.Controllers;

public class EvlerController : Controller
{
    private readonly IEvRepository _evRepository;
    private readonly IOzellikRepository _ozellikRepository;
    public EvlerController(IEvRepository evRepository, IOzellikRepository ozellikRepository)
    {
        _evRepository = evRepository;
        _ozellikRepository = ozellikRepository;
    }
    public IActionResult Index()
    {
        return View(
            new EvViewModel
            {
                Evler = _evRepository.Evler.ToList(),
                Ozellikler = _ozellikRepository.Ozellikler.ToList()
            }
        );
    }
}
