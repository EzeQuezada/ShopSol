
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopSol.Web.Models;
using ShopSol.Web.Services.IServvice;

namespace ShopProMa.Web.Controllers
{
    public class SuppliersController : Controller
    {
        private readonly ISupplierService supplierService;

        // GET: SupplierController
        public SuppliersController(ISupplierService supplierService)
        {
            this.supplierService = supplierService;
        }
        public async Task<ActionResult> Index()
        {
            var supplierGetList = await supplierService.GetList();

            if (!supplierGetList.success)
            {
                ViewBag.Message = supplierGetList.message;
                return View();
            }
            return View (supplierGetList.data);
        }

        // GET: SupplierController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var supplierGetList = await supplierService.GetById(id);

            if (!supplierGetList.success)
            {
                ViewBag.Message = supplierGetList.message;
                return View();
            }
            return View(supplierGetList.data);
            
        }

        // GET: SupplierController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SupplierController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task <ActionResult> Create(SupplierSaveModel supplierSaveModel)
        {
            try
            {
                var saveResult = await supplierService.Save(supplierSaveModel);

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

        // GET: SupplierController/Edit/5
        public async Task<ActionResult>  Edit(int id)
        {

            var supplierGetList = await supplierService.GetById(id);

            if (!supplierGetList.success)
            {
                ViewBag.Message = supplierGetList.message;
                return View();
            }
            return View(supplierGetList.data);
        }

        // POST: SupplierController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(SupplierUpdateModel supplierUpdateModel)
        {
            try
            {

                var updateResult = await supplierService.Update(supplierUpdateModel);

                if (!updateResult.success)
                {
                    ViewBag.Message = updateResult.message;
                    return View(supplierUpdateModel);
                }

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Message = $"Error inesperado: {ex.Message}";
                return View(supplierUpdateModel);
            }
        }

       
    }
}
