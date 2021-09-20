using A2ZPortal.Core.Entities.Common;

namespace A2ZPortal.Core.Entities.Customers
{
    public class EmailSubscriber: BaseModel<int>
    {
        public string EmailAddress { get; set; }
    }
}
