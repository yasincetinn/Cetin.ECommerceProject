using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Project.BLL.Managers.Abstracts;
using Project.CoreMVC.Areas.Admin.Models.Categories.PureVMs;
using Project.ENTITIES.Models;

namespace Project.CoreMVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")] //sadece admin girebilir

    public class CategoryController : Controller
    {
        readonly ICategoryManager _categoryManager;
        
        public CategoryController(ICategoryManager categoryManager)
        {
            _categoryManager = categoryManager;
        }

        public IActionResult Index()
        {
            List<Category> allCategories = _categoryManager.GetAll();

            // Category varlıklarını CategoryRequestModel'e dönüştür
            List<CategoryRequestModel> categoryRequestModels = allCategories.Select(category => new CategoryRequestModel
            {
                ID = category.ID,
                CategoryName = category.CategoryName,
                Description = category.Description,
                Status = category.Status
            }).ToList();

            return View(categoryRequestModels);
        }

        public IActionResult CreateCategory()
        {
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> CreateCategory(CreateCategoryRequestModel model)
        {
            if (ModelState.IsValid)
            {
                Category category = new()
                {
                    ID = model.ID,
                    CategoryName = model.CategoryName,
                    Description = model.Description,
                };

                await _categoryManager.AddAsync(category);
                return RedirectToAction("Index");
            }

            return View(model);
        }

        public async Task<IActionResult> DeleteCategory(int id)
        {
            _categoryManager.Delete(await _categoryManager.FindAsync(id));
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DestroyCategory(int id)
        {
            TempData["Message"] = _categoryManager.Destroy(await _categoryManager.FindAsync(id));
            return RedirectToAction("Index");
        }

        // Veri Identity açık olduğu sürece ID'leri Transaction Log'dan alır. ID'ler Log'dan asla silinmez. Yani biz buradan sildik ve SQL'in bizim veri tabanı Log'unda mesela "şu oturumdaki kullanıcı 13 ID'li veriyi sildi" diye bir şey görürüz. Identity Log'u asla gidipte verinin orjinalinden değil Log'daki taraflarını alır. 

        public async Task<IActionResult> UpdateCategory(int id)
        {

            Category category = await _categoryManager.FindAsync(id);

            CreateCategoryRequestModel model = new()
            {
                ID = category.ID,
                CategoryName = category.CategoryName,
                Description = category.Description,
            };
            return View(model);
        }

        [HttpPost]

        public async Task<IActionResult> UpdateCategory(CreateCategoryRequestModel model)
        {
            if (ModelState.IsValid)
            {
                Category category = new()
                {
                    ID = model.ID,
                    CategoryName = model.CategoryName,
                    Description = model.Description,
                };
                await _categoryManager.UpdateAsync(category);
                return RedirectToAction("Index");
            }

            return View(model);
        }
    }
}
