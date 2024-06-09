namespace Evbul.Entity;

public class Yorum
{   
    public int YorumId { get; set; }
    public string? Yazi { get; set; }
    public DateTime Tarih { get; set; }
    public int KullaniciId { get; set; }
    public int EvId { get; set; }
    public Ev Ev { get; set; } = null!;
    public Kullanici Kullanici { get; set; } = null!;
}
