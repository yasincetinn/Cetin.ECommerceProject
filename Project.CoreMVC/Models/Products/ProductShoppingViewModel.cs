namespace Project.CoreMVC.Models.Products
{
    public class ProductShoppingViewModel
    {
     
            public int ID { get; set; }
            public string ProductName { get; set; }
            public decimal UnitPrice { get; set; }
            public int UnitsInStock { get; set; }
            public string ImagePath { get; set; }
            public int CategoryID { get; set; }
            public string CategoryName { get; set; }
        
    }
}
