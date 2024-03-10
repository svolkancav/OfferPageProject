using OfferPageProject.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfferPageProject.Common.DTOs
{
    public class OfferDTO
    {
        public int Id { get; set; }
        public int ModeId { get; set; }
        public int MovementTypeId { get; set; }
        public int IncotermsId { get; set; }
        public int CountryId { get; set; }
        public int? CityId { get; set; }
        public int Unit1Id { get; set; }
        public int Unit2Id { get; set; }
        public Currency Currency { get; set; }
        public PackageType PackageType { get; set; }
    }
}
