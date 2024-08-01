using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopMonolitica.Web.Data.ProductModel;
using ShopSol.Web.Models;
using ShopSol.Web.Service.IService;

namespace ShopSol.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService productService;

        public ProductController(IProductService productService)
        {
            this.productService = productService;
        }
        // GET: ProductController
        public async Task< ActionResult> Index()
        {
            var ProductGetList = await productService.GetList();

            if (!ProductGetList.success)
            {
                ViewBag.Message = ProductGetList.message;
                return View();
            }
            return View(ProductGetList.data); ;
        }

        // GET: ProductController/Details/5
        public async Task< ActionResult> Details(int id)
        {
            var ProductGetList = await productService.GetById(id);

            if (!ProductGetList.success)
            {
                ViewBag.Message = ProductGetList.message;
                return View();
            }
            return View(ProductGetList.data);
        }

        // GET: ProductController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task <ActionResult>  Create(ProductSaveModel productSaveModel)
        {
            try
            {
                var saveResult = await productService.Save(productSaveModel);

                if (!saveResult.success)
                {
                    ViewBag.Message = saveResult.message;
                    return View();
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductController/Edit/5
        public async Task <ActionResult> Edit(int id)
        {
            var ProductGetList = await productService.GetById(id);

            if (!ProductGetList.success)
            {
                ViewBag.Message = ProductGetList.message;
                return View();
            }
            return View(ProductGetList.data);
        }

        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task <ActionResult> Edit(ProductUpdateModel productUpdateModel)
        {
            try
            {

                var updateResult = await productService.Update(productUpdateModel);

                if (!updateResult.success)
                {
                    ViewBag.Message = updateResult.message;
                    return View(productUpdateModel);
                }

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Message = $"Error inesperado: {ex.Message}";
                return View(productUpdateModel);
            }
        }

    }
}
