using Project.ENTITIES.Enums;

namespace Project.CoreMVC.Areas.Admin.Models.Products.PureVMs
{
    public class ProductRequestModel
    {
        public int ID { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public string ImagePath { get; set; }
        public int UnitsInStock { get; set; }
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public DataStatus Status { get; set; }
    }
}
