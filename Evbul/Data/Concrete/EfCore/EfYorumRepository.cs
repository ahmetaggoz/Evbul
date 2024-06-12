using Evbul.Data.Abstract;
using Evbul.Entity;

namespace Evbul.Data.Concrete.EfCore;

public class EfYorumRepository : IYorumRepository
{
    private EvbulContext _context;
    public EfYorumRepository(EvbulContext context)
    {
        _context = context;
    }
    public IQueryable<Yorum> Yorumlar => _context.Yorumlar;

    public void YorumOlustur(Yorum yorum)
    {
        _context.Yorumlar.Add(yorum);
        _context.SaveChanges();
    }
}
