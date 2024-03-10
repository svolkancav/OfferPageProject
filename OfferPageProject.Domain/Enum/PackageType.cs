using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace OfferPageProject.Domain.Enum
{
    public enum PackageType
    {
        [Display(Name = "Pallets")]
        Pallets = 1,
        [Display(Name = "Boxes")]
        Boxes = 2,
        [Display(Name = "Cartons")]
        Cartons =3
    }
}
