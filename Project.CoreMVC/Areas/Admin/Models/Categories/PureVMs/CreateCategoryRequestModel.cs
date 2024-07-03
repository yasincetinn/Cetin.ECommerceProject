using System.ComponentModel.DataAnnotations;

namespace Project.CoreMVC.Areas.Admin.Models.Categories.PureVMs
{
    public class CreateCategoryRequestModel
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Category name is required")]
        [StringLength(50, ErrorMessage = "Category name must be less than 50 characters")]
        public string CategoryName { get; set; }

        [StringLength(200, ErrorMessage = "Category description must be less than 200 characters")]
        public string Description { get; set; }
    }
}
