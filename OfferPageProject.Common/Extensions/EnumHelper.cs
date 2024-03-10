using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace OfferPageProject.Common.Extensions
{
    public static class EnumHelper
    {
        public static SelectList GetEnumSelectList<TEnum>() where TEnum : struct, Enum
        {
            var values = Enum.GetValues(typeof(TEnum))
                .Cast<TEnum>()
                .Select(e => new
                {
                    Value = Convert.ToInt32(e),
                    Display = (e.GetDisplayName() ?? e.ToString())
                });

            return new SelectList(values, "Value", "Display");
        }

        public static string GetDisplayName(this Enum value)
        {
            var displayAttribute = value
                .GetType()
                .GetMember(value.ToString())
                .FirstOrDefault()
                ?.GetCustomAttribute<DisplayAttribute>();

            return displayAttribute?.Name ?? value.ToString();
        }


    }
}
