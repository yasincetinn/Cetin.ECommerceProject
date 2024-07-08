namespace Project.CoreMVC.Models.Orders.PureVMs
{
    public class OrderViewModel
    {
        public int ID { get; set; }

        public string ShippingAddress { get; set; }

        public string? Email { get; set; }

        public string NameDescription { get; set; }

        public int? AppUserID { get; set; }

        public decimal PriceOfOrder { get; set; }
    }
}
