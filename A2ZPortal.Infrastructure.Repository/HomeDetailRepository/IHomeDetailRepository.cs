using A2ZPortal.Core.ViewModel.HomeDetail;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace A2ZPortal.Infrastructure.Repository.HomeDetailRepository
{
    public interface IHomeDetailRepository
    {
        Task<List<RecentPropertyDetail>> GetRecentPropertyDetail();
        Task<List<PropertyLocationWiseCountVm>> GetPropertyLocatonWiseCount();
    }
}
