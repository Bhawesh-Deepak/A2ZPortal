using A2ZPortal.Core.ViewModel.PropertyDetail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A2ZPortal.Infrastructure.Repository.PropertyDetailRepository
{
    public interface IPropertyDashBoradRepository
    {
        Task<List<FeaturedPropertyVm>> GetPropertyFeatureDetails(int pageNumber, int pageSize);
    }
}
