using Evbul.Data.Abstract;
using Evbul.Entity;

namespace Evbul.Data.Concrete.EfCore;

public class EfOzellikRepository : IOzellikRepository
{
    private EvbulContext _context;
    public EfOzellikRepository(EvbulContext context)
    {
        _context = context;
    }
    public IQueryable<Ozellik> Ozellikler => _context.Ozellikler;

    public void OzellikOlustur(Ozellik ozellik)
    {
        _context.Ozellikler.Add(ozellik);
        _context.SaveChanges();
    }
}
