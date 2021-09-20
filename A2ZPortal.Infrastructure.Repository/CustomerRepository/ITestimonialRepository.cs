using A2ZPortal.Core.ViewModel.CustomersModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A2ZPortal.Infrastructure.Repository.CustomerRepository
{
    public interface ITestimonialRepository
    {
        Task<List<TestimonialVM>> GetTestimonialList();
    }
}
