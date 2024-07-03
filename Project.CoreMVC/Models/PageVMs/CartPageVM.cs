using Project.CoreMVC.Models.ShoppingTools;

namespace Project.CoreMVC.Models.PageVMs
{
    public class CartPageVM
    {
        public Cart Cart { get; set; }
        public List<CartItem> CartItems { get; set; }
    }
}
