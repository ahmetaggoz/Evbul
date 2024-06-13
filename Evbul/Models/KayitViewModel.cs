using System.ComponentModel.DataAnnotations;

namespace Evbul.Models;

public class KayitViewModel
{   
    [Required]
    [Display(Name ="Kullanıcı Ad")]
    public string? KullaniciAd { get; set; }
    [Required]
    [Display(Name ="Ad Soyad")]
    public string? Ad { get; set; }
    [Required]
    [EmailAddress]
    [Display(Name ="Eposta")]
    public string? Eposta {get; set;}
    [Required]
    [StringLength(10, ErrorMessage ="{0} alanı en az {2} karakter uzunluğunda olmalıdır", MinimumLength =6)]
    [DataType(DataType.Password)]
    [Display(Name ="Parola")]
    public string? Parola { get; set; }
    [Required]
    [DataType(DataType.Password)]
    [Compare(nameof(Parola), ErrorMessage ="Parolanız eşleşmiyor")]
    [Display(Name ="Parola Tekrar")]
    public string? ParolaDogrula { get; set; }
}
