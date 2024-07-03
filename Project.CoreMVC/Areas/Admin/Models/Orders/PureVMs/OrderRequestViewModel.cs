using Project.CoreMVC.Areas.Admin.Models.OrderDetails.PureVms;

namespace Project.CoreMVC.Areas.Admin.Models.Orders.PureVMs
{
    public class OrderRequestViewModel
    {
        public int ID { get; set; }
        public string ShippingAddress { get; set; }
        public string NameDescription { get; set; }
        public List<OrderDetailViewModel> OrderDetails { get; set; }
    }
}
