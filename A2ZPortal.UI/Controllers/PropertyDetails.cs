using A2ZPortal.Helper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace A2ZPortal.UI.Controllers
{
    public class PropertyDetails : Controller
    {
        //http://localhost:41291/PropertyDetails/Index?location=&sub_location=&status=&category
        //=&bedrooms=&bathrooms=&min_price=0&max_price=11000000&min_area=1&max_area=3077
        public IActionResult Index(int location, int sub_location,
            int status,int category, int bedrooms, int min_price, int max_price,int min_area,int max_area)
        {
            ViewBag.PropertySearch =new { Location=location,subLocation=sub_location,
                Status=status,Category=category,BedRooms= bedrooms,
                MinPrice=min_price, MaxPrice=max_price, MinArea= min_area, MaxArea= max_area};
            return View();
        }
        public IActionResult PropertyDetail()
        {
            return View(ViewPageHelper.InstanceHelper.GetPathDetail("PropertyDetails", "PropertyDetailIndex"));
        }
    }
}
