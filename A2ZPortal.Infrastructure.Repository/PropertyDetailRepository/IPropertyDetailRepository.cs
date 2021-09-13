using A2ZPortal.Core.ViewModel.PropertyDetail;
using A2ZPortal.Core.ViewModel.PropertyList;
using A2ZPortal.Core.ViewModel.RequestFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A2ZPortal.Infrastructure.Repository.PropertyDetailRepository
{
    public interface IPropertyDetailRepository
    {
        Task<List<PropertyDetailVm>> GetPropertyDetails(PropertyRequestModel requestModel);
        Task<List<PropertyListVm>> GetPropertyListVm();
        Task<PropertyDetailListVm> GetPropertyDetail(int id);

        Task<List<PropertyCompleteListVm>> GetPropertyCompleteDetail(PropertyRequestModel searchModel);
    }
}
