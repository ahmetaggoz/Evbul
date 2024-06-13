using Evbul.Data.Abstract;
using Evbul.Entity;

namespace Evbul.Data.Concrete.EfCore;

public class EfKullaniciRepository : IKullaniciRepository
{
    private EvbulContext _context;
    public EfKullaniciRepository(EvbulContext context)
    {
        _context = context;        
    }
    public IQueryable<Kullanici> Kullanicilar => _context.Kullanicilar;

    public void KullaniciOlustur(Kullanici kullanici)
    {
        _context.Kullanicilar.Add(kullanici);
    }
}
