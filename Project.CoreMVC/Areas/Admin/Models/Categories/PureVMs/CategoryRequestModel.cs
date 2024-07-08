using Project.ENTITIES.Enums;
using System.ComponentModel.DataAnnotations;

namespace Project.CoreMVC.Areas.Admin.Models.Categories.PureVMs
{
    public class CategoryRequestModel
    {
        public int ID { get; set; }

        public string CategoryName { get; set; }

        public string Description { get; set; }

        public DataStatus Status { get; set; }
    }
}
