using Evbul.Data.Abstract;
using Evbul.Entity;

namespace Evbul.Data.Concrete.EfCore;

public class EfEvRepository : IEvRepository
{
    private readonly EvbulContext _context;
    public EfEvRepository(EvbulContext context)
    {
        _context = context;
    }
    public IQueryable<Ev> Evler => _context.Evler;

    public void EvOlustur(Ev ev)
    {
        _context.Evler.Add(ev);
        _context.SaveChanges();
    }
}
