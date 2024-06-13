using Evbul.Entity;

namespace Evbul.Data.Abstract;

public interface IKullaniciRepository
{
    IQueryable<Kullanici> Kullanicilar {get;}
    void KullaniciOlustur(Kullanici kullanici);
}
