using Project.CoreMVC.Models.Categories;
using Project.CoreMVC.Models.Products;
using Project.ENTITIES.Models;
using X.PagedList;

namespace Project.CoreMVC.Models.PageVMs
{
    public class ShoppingPageVM
    {

        public IPagedList<ProductShoppingViewModel> Products { get; set; }
        public List<CategoryShoppingViewModel> Categories { get; set; } //Kategorileri zaten parçalara bölmek istemiyoruz...
    }
}
