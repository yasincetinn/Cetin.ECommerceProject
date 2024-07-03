using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Project.BLL.Managers.Abstracts;
using Project.CoreMVC.Areas.Admin.Models.OrderDetails.PureVms;
using Project.CoreMVC.Areas.Admin.Models.Orders.PureVMs;
using Project.CoreMVC.Models.Orders.PureVMs;
using Project.ENTITIES.Models;
using System.Globalization;

namespace Project.CoreMVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class OrderController : Controller
    {
        readonly IOrderManager _orderManager;

        public OrderController(IOrderManager orderManager)
        {
            _orderManager = orderManager;
        }

        public IActionResult Index()
        {

            List<Order> orders = _orderManager.GetAll();

            List<OrderRequestViewModel> orderViewModels = orders.Select(order => new OrderRequestViewModel //orders listesindeki her Order objesi için bir OrderRequestViewModel oluşturulur. Select metodu kullanılarak her sipariş objesi üzerinde döngü yapılır ve her bir sipariş için yeni bir OrderRequestViewModel oluşturulur.
            {
                ID = order.ID,
                ShippingAddress = order.ShippingAddress,
                NameDescription = order.NameDescription,
                OrderDetails = order.OrderDetails.Select(detail => new OrderDetailViewModel //OrderDetails detaylarını temsil eder. OrderDetails bir liste olduğundan, her bir detay için Select metodu kullanılarak OrderDetailViewModel oluşturulur. 
                {
                    Quantity = detail.Quantity,
                    ProductName = detail.Product.ProductName

                }).ToList()
            }).ToList();

            return View(orderViewModels);
        }
    }
}
