using Project.CoreMVC.Areas.Admin.Models.Products.PureVMs;
using Project.ENTITIES.Models;

namespace Project.CoreMVC.Areas.Admin.Models.Products.PageVMs
{
    public class ProductPageVM
    {
        public List<CategoryProductRequestModel> Categories { get; set; }
        public  ProductRequestModel Product { get; set; }
    }
}
