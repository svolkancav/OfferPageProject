using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OfferPageProject.APIService;
using OfferPageProject.Common.DTOs;
using OfferPageProject.Common.VM;
using System.Security.Claims;
using X.PagedList;

namespace OfferPageProject.Controllers
{
    public class OfferController : BaseController
    {
        private readonly IAPIService _apiService;

        public OfferController(IAPIService apiService)
        {
            _apiService = apiService;
        }
        public async Task<IActionResult> Index(string searchText, int pageNumber = 1, int pageSize = 10, string sortColumn = "", string sortOrder = "")
        {
            if (!string.IsNullOrEmpty(searchText))
            {

                List<OfferVM> offers = await _apiService.GetAsync<List<OfferVM>>("offer", HttpContext.Request.Cookies["access-token"]);
                List<OfferVM> selectedOffers = offers.Where(x => x.PackageType.ToString().ToLower().Contains(searchText.ToLower()) || x.ModeName.ToString().ToLower().Contains(searchText.ToLower()) || x.MovementTypeName.ToString().ToLower().Contains(searchText.ToLower()) || x.IncoTermsName.ToString().ToLower().Contains(searchText.ToLower()) || x.Currency.ToString().ToLower().Contains(searchText.ToLower())).ToList();
                // Apply sorting
                selectedOffers = ApplySorting(selectedOffers.AsQueryable(), sortColumn, sortOrder).ToList();

                return View(selectedOffers.ToPagedList(pageNumber, pageSize));
            }
            else
            {
                List<OfferVM> offers = await _apiService.GetAsync<List<OfferVM>>("offer", HttpContext.Request.Cookies["access-token"]);
                offers = ApplySorting(offers.AsQueryable(), sortColumn, sortOrder).ToList();

                return View(offers.ToPagedList(pageNumber, pageSize));
            }

        }

        private IQueryable<OfferVM> ApplySorting(IQueryable<OfferVM> offerList, string sortColumn, string sortOrder)
        {
            switch (sortColumn)
            {
                case "PackageType":
                    offerList = sortOrder == "asc" ? offerList.OrderBy(p => p.PackageType) : offerList.OrderByDescending(p => p.PackageType);
                    break;
				case "CountryName":
					offerList = sortOrder == "asc" ? offerList.OrderBy(p => p.CountryName) : offerList.OrderByDescending(p => p.CountryName);
					break;
				case "ModeName":
                    offerList = sortOrder == "asc" ? offerList.OrderBy(p => p.ModeName) : offerList.OrderByDescending(p => p.ModeName);
                    break;
                case "MovementTypeName":
                    offerList = sortOrder == "asc" ? offerList.OrderBy(p => p.MovementTypeName) : offerList.OrderByDescending(p => p.MovementTypeName);
                    break;
                case "IncoTermsName":
                    offerList = sortOrder == "asc" ? offerList.OrderBy(p => p.IncoTermsName) : offerList.OrderByDescending(p => p.IncoTermsName);
                    break;
                case "CurrencyCode":
                    offerList = sortOrder == "asc" ? offerList.OrderBy(p => p.Currency) : offerList.OrderByDescending(p => p.Currency);
                    break;

                // Add cases for other columns as needed
                default:
                    // Default sorting by Name in ascending order
                    offerList = offerList.OrderByDescending(p => p.CreatedDate);
                    break;
            }

            return offerList;
        }


        public async Task<IActionResult> Create()
        {
            List<CountryDTO> countries = await _apiService.GetAsync<List<CountryDTO>>("country", HttpContext.Request.Cookies["access-token"]);
            List<CityDTO> cities = await _apiService.GetAsync<List<CityDTO>>("city", HttpContext.Request.Cookies["access-token"]);
            List<ModeDTO> modes = await _apiService.GetAsync<List<ModeDTO>>("mode", HttpContext.Request.Cookies["access-token"]);
            List<IncoTermsDTO> incoTerms = await _apiService.GetAsync<List<IncoTermsDTO>>("incoTerms", HttpContext.Request.Cookies["access-token"]);
            List<MovementTypeDTO> movementTypes = await _apiService.GetAsync<List<MovementTypeDTO>>("movementType", HttpContext.Request.Cookies["access-token"]);
            List<Unit1DTO> unit1s = await _apiService.GetAsync<List<Unit1DTO>>("unit1", HttpContext.Request.Cookies["access-token"]);
            List<Unit2DTO> unit2s = await _apiService.GetAsync<List<Unit2DTO>>("unit2", HttpContext.Request.Cookies["access-token"]);

            CreateOfferDTO model = new CreateOfferDTO();
            model.CountryList = countries.Select(c => new SelectListItem
            {
                Value = c.Id.ToString(),
                Text = c.Name
            }).ToList();
            model.CityList = cities.Select(d => new SelectListItem
            {
                Value = d.Id.ToString(),
                Text = d.Name
            }).ToList();

            model.ModeList = modes.Select(d => new SelectListItem
            {
                Value = d.Id.ToString(),
                Text = d.Name
            }).ToList();
            model.IncoTermsList = incoTerms.Select(d => new SelectListItem
            {
                Value = d.Id.ToString(),
                Text = d.Name
            }).ToList();
            model.MovementTypeList = movementTypes.Select(d => new SelectListItem
            {
                Value = d.Id.ToString(),
                Text = d.Name
            }).ToList();
            model.Unit1List = unit1s.Select(d => new SelectListItem
            {
                Value = d.Id.ToString(),
                Text = d.Quantity.ToString()+d.UnitType
            }).ToList();
            model.Unit2List = unit2s.Select(d => new SelectListItem
            {
                Value = d.Id.ToString(),
                Text = d.Quantity.ToString() + d.UnitType
            }).ToList();

            return View(model);
        }



        [HttpPost]
        public async Task<IActionResult> Create(CreateOfferDTO model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }

                await _apiService.PostAsync<CreateOfferDTO, CreateOfferDTO>("offer", model, HttpContext.Request.Cookies["access-token"]);
                Toastr("success", "Create Success");
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                Toastr("error", $"Create Failed : {ex.Message}");
                return View(model);
            }

        }
        [HttpGet]
        public async Task<JsonResult> GetCities(int countryId)
        {
            List<CityDTO> cityList = await _apiService.GetAsyncWoToken<List<CityDTO>>("city");
            var cities = cityList
                .Where(d => d.Id == countryId)
                .Select(d => new SelectListItem
                {
                    Value = d.Id.ToString(),
                    Text = d.Name
                })
                .ToList();

            return Json(cities);
        }


    }
}
