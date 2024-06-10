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
                    new Entity.Ozellik { Yazi = "Deniz Manzarası"},
                    new Entity.Ozellik { Yazi = "Açık hava duşu"},
                    new Entity.Ozellik { Yazi = "ütü"},
                    new Entity.Ozellik { Yazi = "TV"},
                    new Entity.Ozellik { Yazi = "Klima"}
                );
                context.SaveChanges();
            }
            if(!context.Kullanicilar.Any())
            {
                context.Kullanicilar.AddRange(
                    new Entity.Kullanici { KullaniciAd = "ahmet ağgöz"},
                    new Entity.Kullanici { KullaniciAd = "mahmut orhan"}
                );
                context.SaveChanges();
            }
            if(!context.Evler.Any())
            {
                context.Evler.AddRange(
                    new Entity.Ev {
                        Baslik = "Tiny Malaika",
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
                        Image = "1.jpg"
                    },
                    new Entity.Ev {
                        Baslik = "My Evilia Villa",
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
