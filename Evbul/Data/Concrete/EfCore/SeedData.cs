using Evbul.Entity;
using Microsoft.EntityFrameworkCore;

namespace Evbul.Data.Concrete.EfCore;

public static class SeedData
{
    public static void TestVerileriniDoldur(IApplicationBuilder app)
    {
       var context = app.ApplicationServices.CreateScope().ServiceProvider.GetService<EvbulContext>(); 
       if(context != null)
        {
            if(context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }
            if(!context.Ozellikler.Any())
            {
                context.Ozellikler.AddRange(
                    new Entity.Ozellik { Yazi = "Deniz Manzarası", Url = "deniz-manzarasi", Renk = OzellikRenkleri.danger},
                    new Entity.Ozellik { Yazi = "Açık hava duşu", Url = "acik-hava-dusu", Renk = OzellikRenkleri.warning},
                    new Entity.Ozellik { Yazi = "ütü", Url = "utu", Renk = OzellikRenkleri.secondary},
                    new Entity.Ozellik { Yazi = "TV", Url = "tv", Renk = OzellikRenkleri.success},
                    new Entity.Ozellik { Yazi = "Klima", Url = "klima", Renk = OzellikRenkleri.primary}
                );
                context.SaveChanges();
            }
            if(!context.Kullanicilar.Any())
            {
                context.Kullanicilar.AddRange(
                    new Entity.Kullanici { KullaniciAd = "ahmet ağgöz", Image = "p1.jpg"},
                    new Entity.Kullanici { KullaniciAd = "mahmut orhan", Image = "p2.jpg"}
                );
                context.SaveChanges();
            }
            if(!context.Evler.Any())
            {
                context.Evler.AddRange(
                    new Entity.Ev {
                        Baslik = "Tiny Malaika",
                        Url = "tiny-malaika",
                        Kapasite = 2,
                        YatakOdasi = 2,
                        YatakSayisi = 4,
                        Banyo = 1,
                        Fiyat = 586,
                        AktifMi = true,
                        YayinlamaTarihi = DateTime.Now.AddDays(-10),
                        KullaniciId = 1,
                        Aciklama = "Şovalye adasındaki evimiz, etkileyici deniz, körfez ve doğa manzaralarıyla benzersiz bir konaklama deneyimi sunuyor.",
                        Ozellikler = context.Ozellikler.Take(3).ToList(),
                        Image = "1.jpg",
                        Yorumlar = new List<Yorum> {
                            new Yorum { Yazi = "huzur dolu bir tatil geçirdim", Tarih = DateTime.Now.AddDays(-10), KullaniciId = 1 },
                            new Yorum { Yazi = "eşyalar çok temiz ve hijyen konusunda çok memnun kaldık", Tarih = DateTime.Now.AddDays(-10), KullaniciId = 2 }
                        }
                    },
                    new Entity.Ev {
                        Baslik = "My Evilia Villa",
                        Url = "my-evilia-villa",
                        Kapasite = 6,
                        YatakOdasi = 3,
                        YatakSayisi = 3,
                        Banyo = 3,
                        Fiyat = 480,
                        AktifMi = true,
                        YayinlamaTarihi = DateTime.Now.AddDays(-20),
                        KullaniciId = 1,
                        Aciklama = "Villa, Mikonos'un güneybatı tarafında, Lia plajına kadar yer almaktadır. Dinlendirici bir tatil için ideal.",
                        Ozellikler = context.Ozellikler.Take(4).ToList(),
                        Image = "2.jpg"
                    },
                    new Entity.Ev {
                        Baslik = "Patara Resort'ta  2 yatak odalı lüks deniz kenarında villa",
                        Url = "patara-resortta-2-yatak-odali-luks-deniz-kenarinda-villa",
                        Kapasite = 4,
                        YatakOdasi = 2,
                        YatakSayisi = 3,
                        Banyo = 2,
                        Fiyat = 310,
                        AktifMi = true,
                        YayinlamaTarihi = DateTime.Now.AddDays(-5),
                        KullaniciId = 2,
                        Aciklama = "Tüm odalarda tam deniz manzaralı 2 yatak odası tasarımcı villa.Özel plaja, havuzlara ücretsiz erişim.",
                        Ozellikler = context.Ozellikler.Take(2).ToList(),
                        Image = "3.jpg"
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
