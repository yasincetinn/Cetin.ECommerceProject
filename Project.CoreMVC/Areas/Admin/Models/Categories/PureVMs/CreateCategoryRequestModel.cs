using System.ComponentModel.DataAnnotations;

namespace Project.CoreMVC.Areas.Admin.Models.Categories.PureVMs
{
    public class CreateCategoryRequestModel
    {
        public int ID { get; set; }

        public string CategoryName { get; set; }

        public string Description { get; set; }
    }
}
