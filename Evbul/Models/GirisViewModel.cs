using System.ComponentModel.DataAnnotations;
namespace Evbul.Models;

public class GirisViewModel
{
    [Required]
    [EmailAddress]
    [Display(Name ="Eposta")]
    public string? Eposta {get; set;}
    [Required]
    [StringLength(10, ErrorMessage ="{0} alanı en az {2} karakter uzunluğunda olmalıdır", MinimumLength =6)]
    [DataType(DataType.Password)]
    [Display(Name ="Parola")]
    public string? Parola { get; set; }
}
