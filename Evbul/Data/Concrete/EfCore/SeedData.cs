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
                    new Entity.Ozellik { Yazi = "Deniz Manzarası", Url = "deniz-manzarasi", Renk = OzellikRenkleri.danger, Icon = "tsunami"},
                    new Entity.Ozellik { Yazi = "Denize Sıfır", Url = "denize-sifir", Renk = OzellikRenkleri.warning, Icon = "water"},
                    new Entity.Ozellik { Yazi = "Dağ Bisikleti", Url = "dag-bisikleti", Renk = OzellikRenkleri.secondary, Icon = "bicycle"},
                    new Entity.Ozellik { Yazi = "Güneşli", Url = "gunesli", Renk = OzellikRenkleri.success, Icon = "brightness-alt-high"},
                    new Entity.Ozellik { Yazi = "Açık Hava", Url = "acik-hava", Renk = OzellikRenkleri.primary, Icon = "cloud-moon-fill"},
                    new Entity.Ozellik { Yazi = "Bütçe Dostu", Url = "butce-dostu", Renk = OzellikRenkleri.danger, Icon = "coin"},
                    new Entity.Ozellik { Yazi = "Manzaralı", Url = "manzarali", Renk = OzellikRenkleri.success, Icon = "file-image-fill"},
                    new Entity.Ozellik { Yazi = "Turistik", Url = "turistik", Renk = OzellikRenkleri.warning, Icon = "globe-central-south-asia"}
                    ,
                    new Entity.Ozellik { Yazi = "Balayı", Url = "balayı", Renk = OzellikRenkleri.primary, Icon = "hearts"} ,
                    new Entity.Ozellik { Yazi = "Yıldızlı Gökyüzü", Url = "yildizli-gokyuzu", Renk = OzellikRenkleri.danger, Icon = "moon-stars"},
                    new Entity.Ozellik { Yazi = "Kar Tatili", Url = "kar-tatili", Renk = OzellikRenkleri.primary, Icon = "snow2"},
                    new Entity.Ozellik { Yazi = "Havalimanı", Url = "havalimani", Renk = OzellikRenkleri.secondary, Icon = "airplane-fill"}
                    ,
                    new Entity.Ozellik { Yazi = "Ödüllü", Url = "odullu", Renk = OzellikRenkleri.warning, Icon = "award-fill"}
                     ,
                    new Entity.Ozellik { Yazi = "Sinema", Url = "sinema", Renk = OzellikRenkleri.danger, Icon = "badge-8k"}
                    ,
                    new Entity.Ozellik { Yazi = "Tarihi", Url = "tarihi", Renk = OzellikRenkleri.primary, Icon = "bank"}
                );
                context.SaveChanges();
            }
            if(!context.Kullanicilar.Any())
            {
                context.Kullanicilar.AddRange(
                    new Entity.Kullanici { KullaniciAd = "ahmet ağgöz",Ad = "Ahmet Ağgöz", Parola = "123456", Eposta ="info@ahmetaggoz.com", Image = "p1.jpg"},
                    new Entity.Kullanici { KullaniciAd = "mahmut orhan",Ad = "Mahmut Orhan", Eposta = "info@mahmutorhan.com",Parola = "123456", Image = "p2.jpg"}
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
                        Ozellikler = context.Ozellikler.Take(15).ToList(),
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
                        Ozellikler = context.Ozellikler.Take(15).ToList(),
                        Image = "2.jpg"
                    },
                    new Entity.Ev {
                        Baslik = "Patara Resort",
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
                        Ozellikler = context.Ozellikler.Take(6).ToList(),
                        Image = "3.jpg"
                    },
                    new Entity.Ev {
                        Baslik = "Yazlık Villa",
                        Url = "yazlik-villa",
                        Kapasite = 4,
                        YatakOdasi = 2,
                        YatakSayisi = 3,
                        Banyo = 2,
                        Fiyat = 410,
                        AktifMi = true,
                        YayinlamaTarihi = DateTime.Now.AddDays(-5),
                        KullaniciId = 2,
                        Aciklama = "Tüm odalarda tam deniz manzaralı 2 yatak odası tasarımcı villa.Özel plaja, havuzlara ücretsiz erişim.",
                        Ozellikler = context.Ozellikler.Take(6).ToList(),
                        Image = "1.jpg"
                    },
                    new Entity.Ev {
                        Baslik = "Expamo Resort",
                        Url = "expamo-villa",
                        Kapasite = 4,
                        YatakOdasi = 2,
                        YatakSayisi = 3,
                        Banyo = 2,
                        Fiyat = 410,
                        AktifMi = true,
                        YayinlamaTarihi = DateTime.Now.AddDays(-15),
                        KullaniciId = 2,
                        Aciklama = "Tüm odalarda tam deniz manzaralı 2 yatak odası tasarımcı villa.Özel plaja, havuzlara ücretsiz erişim.",
                        Ozellikler = context.Ozellikler.Take(9).ToList(),
                        Image = "101.jpg"
                    },
                    new Entity.Ev {
                        Baslik = "Detayo Brandon",
                        Url = "detayo-villa",
                        Kapasite = 4,
                        YatakOdasi = 2,
                        YatakSayisi = 3,
                        Banyo = 2,
                        Fiyat = 610,
                        AktifMi = true,
                        YayinlamaTarihi = DateTime.Now.AddDays(-25),
                        KullaniciId = 2,
                        Aciklama = "Tüm odalarda tam deniz manzaralı 2 yatak odası tasarımcı villa.Özel plaja, havuzlara ücretsiz erişim.",
                        Ozellikler = context.Ozellikler.Take(6).ToList(),
                        Image = "102.jpg"
                    },
                    new Entity.Ev {
                        Baslik = "Yalbayu tekano",
                        Url = "yalbayo-villa",
                        Kapasite = 4,
                        YatakOdasi = 2,
                        YatakSayisi = 3,
                        Banyo = 2,
                        Fiyat = 410,
                        AktifMi = true,
                        YayinlamaTarihi = DateTime.Now.AddDays(-55),
                        KullaniciId = 2,
                        Aciklama = "Tüm odalarda tam deniz manzaralı 2 yatak odası tasarımcı villa.Özel plaja, havuzlara ücretsiz erişim.",
                        Ozellikler = context.Ozellikler.Take(6).ToList(),
                        Image = "103.jpg"
                    },
                    new Entity.Ev {
                        Baslik = "Emila",
                        Url = "emilia-villa",
                        Kapasite = 4,
                        YatakOdasi = 2,
                        YatakSayisi = 3,
                        Banyo = 2,
                        Fiyat = 410,
                        AktifMi = true,
                        YayinlamaTarihi = DateTime.Now.AddDays(-5),
                        KullaniciId = 2,
                        Aciklama = "Tüm odalarda tam deniz manzaralı 2 yatak odası tasarımcı villa.Özel plaja, havuzlara ücretsiz erişim.",
                        Ozellikler = context.Ozellikler.Take(6).ToList(),
                        Image = "104.jpg"
                    },
                    new Entity.Ev {
                        Baslik = "kadara",
                        Url = "kadara-villa",
                        Kapasite = 4,
                        YatakOdasi = 2,
                        YatakSayisi = 3,
                        Banyo = 2,
                        Fiyat = 710,
                        AktifMi = true,
                        YayinlamaTarihi = DateTime.Now.AddDays(-5),
                        KullaniciId = 2,
                        Aciklama = "Tüm odalarda tam deniz manzaralı 2 yatak odası tasarımcı villa.Özel plaja, havuzlara ücretsiz erişim.",
                        Ozellikler = context.Ozellikler.Take(15).ToList(),
                        Image = "105.jpg"
                    },
                    new Entity.Ev {
                        Baslik = "Yazlık Villa",
                        Url = "yazlik-villa",
                        Kapasite = 4,
                        YatakOdasi = 2,
                        YatakSayisi = 3,
                        Banyo = 2,
                        Fiyat = 410,
                        AktifMi = true,
                        YayinlamaTarihi = DateTime.Now.AddDays(-5),
                        KullaniciId = 2,
                        Aciklama = "Tüm odalarda tam deniz manzaralı 2 yatak odası tasarımcı villa.Özel plaja, havuzlara ücretsiz erişim.",
                        Ozellikler = context.Ozellikler.Take(6).ToList(),
                        Image = "106.jpg"
                    },
                    new Entity.Ev {
                        Baslik = "Uryaı Villa",
                        Url = "uryai-villa",
                        Kapasite = 4,
                        YatakOdasi = 2,
                        YatakSayisi = 3,
                        Banyo = 2,
                        Fiyat = 610,
                        AktifMi = true,
                        YayinlamaTarihi = DateTime.Now.AddDays(-5),
                        KullaniciId = 2,
                        Aciklama = "Tüm odalarda tam deniz manzaralı 2 yatak odası tasarımcı villa.Özel plaja, havuzlara ücretsiz erişim.",
                        Ozellikler = context.Ozellikler.Take(15).ToList(),
                        Image = "107.jpg"
                    },
                    new Entity.Ev {
                        Baslik = "Retye Villa",
                        Url = "reyue-villa",
                        Kapasite = 4,
                        YatakOdasi = 2,
                        YatakSayisi = 3,
                        Banyo = 2,
                        Fiyat = 810,
                        AktifMi = true,
                        YayinlamaTarihi = DateTime.Now.AddDays(-5),
                        KullaniciId = 2,
                        Aciklama = "Tüm odalarda tam deniz manzaralı 2 yatak odası tasarımcı villa.Özel plaja, havuzlara ücretsiz erişim.",
                        Ozellikler = context.Ozellikler.Take(6).ToList(),
                        Image = "108.jpg"
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
