using A2ZPortal.Core.Entities.Master;
using A2ZPortal.Helper.ExcelHelper;
using A2ZPortal.Infrastructure.Repository.GenericRepository;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace A2ZAdmin.UI.Controllers.Common
{
    public class DownlaodController : Controller
    {
        private readonly IGenericRepository<AdditionalRoom, int> _IAdditionalRoomRepository;
        public DownlaodController(IGenericRepository<AdditionalRoom, int> additionalRoomRepository)
        {
            _IAdditionalRoomRepository = additionalRoomRepository;
        }
        public async Task<IActionResult> Index()
        {
            var result = await _IAdditionalRoomRepository.GetList(x => x.IsActive == true && x.IsDeleted == false);
            var downloadExcel = DownloadExcelFile<AdditionalRoom>.GetExcelFile(result.Entities, "AdditionalRoom Detail", "Master Additional Room");
            return  File(downloadExcel.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Master_Additional_Room.xlsx");
        }
    }
}
