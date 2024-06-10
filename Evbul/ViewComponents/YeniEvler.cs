using Evbul.Data.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Evbul.ViewComponents;

public class YeniEvler : ViewComponent
{
    private IEvRepository _evRepository;
    public YeniEvler(IEvRepository evRepository)
    {
        _evRepository = evRepository;
    }
    public async Task<IViewComponentResult> InvokeAsync()
    {
        return View(
            await
            _evRepository
            .Evler
            .OrderByDescending(e => e.YayinlamaTarihi)
            .Take(5)
            .ToListAsync()
        );
    }
}
