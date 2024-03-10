using System.ComponentModel.DataAnnotations;

namespace OfferPageProject.Domain.Enum
{
    public enum Currency
    {
        [Display(Name = "USD")]
        USD =1,
        [Display(Name = "TRY")]
        TRY =2,
        [Display(Name = "CNY")]
        CNY =3
    }
}
