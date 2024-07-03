using System.ComponentModel.DataAnnotations;

namespace Project.CoreMVC.Models.Orders.PureVMs
{
    public class OrderViewModel
    {
        public int ID { get; set; }


        [Required(ErrorMessage = "{0} is required.")]
        [MinLength(20, ErrorMessage = "{0} must be at least {1} characters.")]
        public string ShippingAddress { get; set; }


        [Required(ErrorMessage = "{0} field is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address format.")]
        public string? Email { get; set; }


        [Required(ErrorMessage = "{0} is required.")]
        public string NameDescription { get; set; }

        public int? AppUserID { get; set; }

        public decimal PriceOfOrder { get; set; }
    }
}
