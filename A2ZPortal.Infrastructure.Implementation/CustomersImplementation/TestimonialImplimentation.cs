using A2ZPortal.Core.ViewModel.CustomersModel;
using A2ZPortal.Helper.Extension;
using A2ZPortal.Infrastructure.Repository.CustomerRepository;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A2ZPortal.Infrastructure.Implementation.CustomersImplementation
{
    public class TestimonialImplimentation : ITestimonialRepository
    {
        private readonly string _connectionString;

        public TestimonialImplimentation(IConfiguration configuration)
        {
            _connectionString = configuration.GetSection("ConnectionStrings:dbConnection").Value;

        }
        public async Task<List<TestimonialVM>> GetTestimonialList()
        {

            var reader = await SqlHelper.ExecuteReader(_connectionString, SqlConstant.GetTestimonialCompleteDetail,
               System.Data.CommandType.StoredProcedure);

            var response = new List<TestimonialVM>();

            while (reader.Read())
            {
                var model = new TestimonialVM();
                model.Id = reader.DefaultIfNull<int>("Id");
                model.Testimonial = reader.DefaultIfNull<string>("Testimonial");
                model.CustomerName = reader.DefaultIfNull<string>("CustomerName");
                model.CustomerEmail = reader.DefaultIfNull<string>("CustomerEmail");
                model.CustomerPhone = reader.DefaultIfNull<string>("CustomerPhone");
                model.PlaceAddress = (reader.DefaultIfNull<string>("PlaceAddress"));

                response.Add(model);
            }
            return response;
        }


    }
}
