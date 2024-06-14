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

    public void EditEv(Ev ev)
    {
        var entity = _context.Evler.FirstOrDefault(e => ev.EvId == ev.EvId);

        if(entity != null)
        {
            entity.Baslik = ev.Baslik;
            entity.Aciklama = ev.Aciklama;
            entity.Kapasite = ev.Kapasite;
            entity.YatakOdasi = ev.YatakOdasi;
            entity.YatakSayisi = ev.YatakSayisi;
            entity.Banyo = ev.Banyo;
            entity.Fiyat = ev.Fiyat;
            entity.Url = ev.Url;
            entity.AktifMi = ev.AktifMi;

            _context.SaveChanges();
        }
    }

    public void EvOlustur(Ev ev)
    {
        _context.Evler.Add(ev);
        _context.SaveChanges();
    }
}
