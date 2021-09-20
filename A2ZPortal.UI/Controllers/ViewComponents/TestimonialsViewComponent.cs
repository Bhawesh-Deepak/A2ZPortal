using A2ZPortal.Infrastructure.Repository.CustomerRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace A2ZPortal.UI.Controllers.ViewComponents
{
    public class TestimonialsViewComponent : ViewComponent
    {
        private readonly ITestimonialRepository _ITestimonialRepository;
        private readonly IConfiguration _configuration;
        private readonly string APIURL = string.Empty;
        public TestimonialsViewComponent( ITestimonialRepository TestimonialRepository, IConfiguration configuration)
        {
            _ITestimonialRepository = TestimonialRepository;
            _configuration = configuration;
            APIURL = configuration.GetSection("APIURL").Value;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            
            var response = await _ITestimonialRepository.GetTestimonialList();
          
            return await Task.FromResult((IViewComponentResult)View("TestimonialIndex", response));
        }


    }
}
