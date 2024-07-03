using System.ComponentModel.DataAnnotations;

namespace Project.CoreMVC.Models.OuterRequestModel
{
    public class PaymentRequestModel
    {
        //Bankaların istediği tarzda - standartta bir veri göndermemiz lazım.

        [Required(ErrorMessage = "{0} is required.")]
        [MaxLength(19, ErrorMessage = "{0} en fazla {1} karakter alabilir")]
        [MinLength(19, ErrorMessage = "{0} en az {1} karakter alabilir")]
        public string CardNumber { get; set; }


        [Required(ErrorMessage = "{0} is required.")]
        public string CardUserName { get; set; }


        [Required(ErrorMessage = "{0} is required.")]
        [StringLength(4, MinimumLength = 3, ErrorMessage = "Invalid CCV")]
        public string CCV { get; set; }


        [Required(ErrorMessage = "{0} is required.")]
        [Range(2014, 2050, ErrorMessage = "Invalid expiration year.")]
        public int ExpiryYear { get; set; }


        [Required(ErrorMessage = "{0} is mandatory.")]
        [Range(1, 12, ErrorMessage = "Invalid expiration month.")]
        public int ExpiryMonth { get; set; }

        public decimal ShoppingPrice { get; set; }
    }
}
