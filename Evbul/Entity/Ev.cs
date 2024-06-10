namespace Evbul.Entity;

public class Ev
{
    public int EvId { get; set; }
    public string? Baslik { get; set; }
    public string? Image { get; set; }
    public string? Url { get; set; }
    public int Kapasite { get; set; }
    public int YatakOdasi { get; set; }
    public int YatakSayisi { get; set; }
    public int Banyo { get; set; }
    public int Fiyat { get; set; }
    public bool AktifMi { get; set; }
    public DateTime YayinlamaTarihi { get; set; }
    public int KullaniciId { get; set; }
    public Kullanici Kullanici { get; set; } = null!;
    public string? Aciklama { get; set; }
    public List<Yorum> Yorumlar { get; set; } = new List<Yorum>();
    public List<Ozellik> Ozellikler { get; set; } = new List<Ozellik>();
}
