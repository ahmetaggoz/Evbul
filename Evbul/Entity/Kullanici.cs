namespace Evbul.Entity;

public class Kullanici
{
    public int KullaniciId { get; set; }
    public string? KullaniciAd { get; set; }
    public string? Eposta { get; set; }
    public string? Ad { get; set; }
    public string? Parola { get; set; }
    public string? Image { get; set; }
    public List<Ev> Evler { get; set; } = new List<Ev>();
    public List<Yorum> Yorumlar { get; set; } = new List<Yorum>();
}
