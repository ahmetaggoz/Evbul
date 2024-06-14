using System.ComponentModel.DataAnnotations;

namespace Evbul.Models;

public class EvOlusturViewModel
{
    public int EvId { get; set; }
    [Required]
    [Display(Name ="Başlık")]
    public string? Baslik { get; set; }

    [Required]
    [Display(Name ="Açıklama")]
    public string? Aciklama { get; set; }

    [Required]
    [Display(Name ="Kapasite")]
    public int Kapasite { get; set; }
    [Required]
    [Display(Name ="Yatak Odası")]
    public int YatakOdasi { get; set; }
    [Required]
    [Display(Name ="Yatak Sayısı")]
    public int YatakSayisi { get; set; }
    [Required]
    [Display(Name ="Banyo")]
    public int Banyo { get; set; }
    [Required]
    [Display(Name ="Fiyat")]
    public int Fiyat { get; set; }

    [Required]
    [Display(Name ="Url")]
    public string? Url { get; set; }
    public bool AktifMi { get; set; }
}
