using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using OfferPageProject.Domain.Entities.Concrete;
using OfferPageProject.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using OfferPageProject.Domain.Enum;

namespace OfferPageProject.Application.SeedData
{
    public static class SeedData
    {
        public static async void Seed(IApplicationBuilder app)
        {
            using (var scope = app.ApplicationServices.CreateScope())
            {
                AppDbContext context = scope.ServiceProvider.GetService<AppDbContext>();
                context.Database.Migrate();

                if (!context.Modes.Any())
                {
                    List<Mode> modes = new List<Mode>()
                    {
                        new Mode { Name = "LCL" },
                        new Mode { Name = "FCL" },
                        new Mode { Name = "Air" }
                    };

                    context.Modes.AddRange(modes);

                    await context.SaveChangesAsync();
                }
                if (!context.MovementTypes.Any())
                {
                    List<MovementType> movementTypes = new List<MovementType>()
                    {
                        new MovementType { Name = "Door to Door" },
                        new MovementType { Name = "Port to Door" },
                        new MovementType { Name = "Port to Port" }
                    };

                    context.MovementTypes.AddRange(movementTypes);

                    await context.SaveChangesAsync();
                }
                if (!context.Incotermses.Any())
                {
                    List<Incoterms> incoTerms = new List<Incoterms>()
                    {
                        new Incoterms { Name = "Delivered Duty Paid (DDP)" },
                        new Incoterms { Name = "Delivered At Place (DAT)" }
                    };

                    context.Incotermses.AddRange(incoTerms);

                    await context.SaveChangesAsync();
                }

                if (!context.Unit1s.Any())
                {
                    List<Unit1> unit1s = new List<Unit1>()
                    {
                        new Unit1 { UnitType = "IN",Quantity = 10 },
                        new Unit1 { UnitType = "CM",Quantity = 5 }
                    };

                    context.Unit1s.AddRange(unit1s);

                    await context.SaveChangesAsync();
                }
                if (!context.Unit2s.Any())
                {
                    List<Unit2> unit2s = new List<Unit2>()
                    {
                        new Unit2 { UnitType = "LB",Quantity= 10 },
                        new Unit2 { UnitType = "KG",Quantity= 5 }
                    };

                    context.Unit2s.AddRange(unit2s);

                    await context.SaveChangesAsync();
                }
                if (!context.Countries.Any())
                {

                    var countryJson = File.ReadAllText("../OfferPageProject.Application/SeedData/Countries.json");
                    var countryDataList = JsonConvert.DeserializeObject<List<CountryData>>(countryJson);

                    if (countryDataList != null && countryDataList.Any())
                    {
                        var countries = countryDataList
                            .SelectMany(countryData => countryData.Countries.Select(countryWrapper => countryWrapper.Country))
                            .ToList();

                        context.Countries.AddRange(countries.Select(x => new Country { Name = x.Name }));
                        await context.SaveChangesAsync();
                    }

                }
                if (!context.Cities.Any())
                {
                    var cityJson = File.ReadAllText("../OfferPageProject.Application/SeedData/Cities.json");
                    var cityDataList = JsonConvert.DeserializeObject<List<CityData>>(cityJson);

                    if (cityDataList != null && cityDataList.Any())
                    {
                        var cities = cityDataList
                           .SelectMany(cityData => cityData.Cities.Select(cityWrapper => cityWrapper.City))
                           .ToList();
                        context.Cities.AddRange(cities.Select(x => new City { Name = x.Name, CountryId = x.CountryId }));
                        await context.SaveChangesAsync();
                    }
                }
                if (!context.Offers.Any())
                {
                    List<Mode> modes = new List<Mode>();
                    modes = await context.Modes.ToListAsync();

                    List<MovementType> movementTypes = new List<MovementType>();
                    movementTypes = await context.MovementTypes.ToListAsync();

                    List<Incoterms> incoterms = new List<Incoterms>();
                    incoterms = await context.Incotermses.ToListAsync();

                    List<Unit1> unit1 = new List<Unit1>();
                    unit1 = await context.Unit1s.ToListAsync();

                    List<Unit2> unit2 = new List<Unit2>();
                    unit2 = await context.Unit2s.ToListAsync();


                    List<Country> countries = new List<Country>();
                    countries = await context.Countries.ToListAsync();



                    List<Offer> offers = new List<Offer>()
                    {
                        new Offer { Mode = modes.FirstOrDefault(x => x.Name == "Air"),ModeId=3, MovementType = movementTypes.FirstOrDefault(x => x.Name == "Port to Port"), MovementTypeId =3, Incoterms = incoterms.FirstOrDefault(x => x.Name == "Delivered Duty Paid (DDP)"),IncotermsId=1,Country = countries.FirstOrDefault(x=>x.Name =="USA"),CountryId=1, PackageType =PackageType.Cartons,Unit1 = unit1.FirstOrDefault(x=>x.UnitType == "IN" & x.Quantity == 10), Unit1Id =1,Unit2 = unit2.FirstOrDefault (x=>x.UnitType == "LB" & x.Quantity ==10), Unit2Id =1, Currency = Currency.USD},

                        new Offer { Mode = modes.FirstOrDefault(x => x.Name == "LCL"),ModeId=1, MovementType = movementTypes.FirstOrDefault(x => x.Name == "Door to Door"), MovementTypeId =1, Incoterms = incoterms.FirstOrDefault(x => x.Name == "Delivered At Place (DAT)"),IncotermsId=2,Country = countries.FirstOrDefault(x=>x.Name =="Turkey"),CountryId=2,PackageType =PackageType.Boxes,Unit1 = unit1.FirstOrDefault(x=>x.UnitType == "CM" & x.Quantity == 5), Unit1Id =2,Unit2 = unit2.FirstOrDefault (x=>x.UnitType == "KG" & x.Quantity ==5), Unit2Id =2, Currency = Currency.TRY}
                    };

                    context.Offers.AddRange(offers);

                    await context.SaveChangesAsync();
                }

            }
        }
    }
    public class CountryData
    {
        public List<CountryWrapper> Countries { get; set; }
    }

    public class CountryWrapper
    {
        [JsonProperty("Country")]
        public Country Country { get; set; }
    }

    public class CityData
    {
        public List<CityWrapper> Cities { get; set; }
    }

    public class CityWrapper
    {
        [JsonProperty("City")]
        public City City { get; set; }
    }
}