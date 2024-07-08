using System.ComponentModel.DataAnnotations;

namespace Project.CoreMVC.Models.OuterRequestModel
{
    public class PaymentRequestModel
    {
        //Bankaların istediği tarzda - standartta bir veri göndermemiz lazım.

        public string CardNumber { get; set; }

        public string CardUserName { get; set; }

        public string CCV { get; set; }

        public int ExpiryYear { get; set; }

        public int ExpiryMonth { get; set; }

        public decimal ShoppingPrice { get; set; }
    }
}
