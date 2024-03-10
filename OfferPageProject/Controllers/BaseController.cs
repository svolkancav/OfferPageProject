using Microsoft.AspNetCore.Mvc;

namespace OfferPageProject.Controllers
{
    public class BaseController : Controller
    {
        protected void Toastr(string type, string message)
        {
            TempData[$"Toastr{type}"] = message;
        }
    }
}
