namespace Evbul.Entity;

public class Kullanici
{
    public int KullaniciId { get; set; }
    public string? KullaniciAd { get; set; }
    public List<Ev> Evler { get; set; } = new List<Ev>();
    public List<Yorum> Yorumlar { get; set; } = new List<Yorum>();
}
