using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A2ZPortal.Core.ViewModel.RequestFolder
{
    public class PropertyRequestModel: BaseRequestModel
    {
        public int LocationId { get; set; }
        public int SubLocationId { get; set; }
        public int PropertyId { get; set; }
        public int PropertyStatusId  { get; set; }
        public int BedRoomId { get; set; }
        public int BathRoomId { get; set; }
        public int BUdgetID { get; set; }

    }
}
