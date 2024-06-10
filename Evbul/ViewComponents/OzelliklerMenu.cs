using Evbul.Data.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Evbul.ViewComponents;

public class OzelliklerMenu : ViewComponent
{
    private IOzellikRepository _ozellikRepository;
    public OzelliklerMenu(IOzellikRepository ozellikRepository)
    {
        _ozellikRepository = ozellikRepository;
    }
    public async Task<IViewComponentResult> InvokeAsync()
    {
        return View(await _ozellikRepository.Ozellikler.ToListAsync());
    }
}
