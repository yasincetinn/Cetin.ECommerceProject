using Project.CoreMVC.Models.Orders.PureVMs;
using Project.CoreMVC.Models.OuterRequestModel;

namespace Project.CoreMVC.Models.Orders.PageVMs
{
    public class OrderRequestPageVM
    {   
        public OrderViewModel Order { get; set; }
        public PaymentRequestModel PaymentRequestModel { get; set; }
    }
}
