
using Microsoft.AspNetCore.Mvc;
using SalesWebMVC.Data;
using SalesWebMVC.Models.Entities;
using SalesWebMVC.Models.ViewModels;
using SalesWebMVC.Services;
using SalesWebMVC.Services.Exceptions;
using System.Diagnostics;
using System.Linq;
using WebApplication1.Models;

namespace SalesWebMVC.Controllers
{
    public class SellersController : Controller
    {
        private readonly SellerService _sellerService;
        private readonly DepartmentService _departmentservice;
        private readonly SalerRecordService _salesService;

        public SellersController(SellerService sellerService, DepartmentService departmentService, SalerRecordService salesService)
        {
            _sellerService = sellerService;
            _salesService = salesService;
            _departmentservice = departmentService;
        }

        public async Task<IActionResult> Index()
        {
            var list = await _sellerService.FindAllAsync();
            return View(list);
        }

        public async Task<IActionResult> Create(SellerFromViewModel viewModel)
        {
            var departments = await _departmentservice.FindAllAsync();
            var viewmodel = new SellerFromViewModel { Departments = departments };
            return View(viewmodel);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return View("Error");
            }
            var obj = await _sellerService.FindByIdAsync(id.Value);
            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "ID Not Provided" });
            }

            return View(obj);
        }
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return View("Error");
            }

            var departments = await _departmentservice.FindAllAsync();
            var seller = await _sellerService.FindByIdAsync(id.Value);
            if(seller == null)
            {
                return RedirectToAction(nameof(Error), new { message = "ID Not found" });
            }
            var viewModel = new SellerFromViewModel() { Seller = seller, Departments = departments, };
            return View(viewModel);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "ID Not Provided" });
            }
            var seller = await _sellerService.FindByIdAsync(id.Value);
            var salesrecord = await _salesService.FindAllAsync(seller);
            var viewModel = new SellerRecordFromViewModel() { Seller = seller, SalesRecord = salesrecord};
            if (seller == null)
            {
                return RedirectToAction(nameof(Error), new { message = "ID Not found" });
            }

            return View(viewModel);
        }

        public IActionResult Error(string message)
        {
            var viewModel = new ErrorViewModel { 
                Message = message,
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            };
            return View(viewModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Seller seller)
        {
            if (!ModelState.IsValid)
            {
                var departaments = await _departmentservice.FindAllAsync();
                var viewModel = new SellerFromViewModel { Seller = seller, Departments = departaments };
                return View(Create(viewModel));
            }
            await _sellerService.InsertAsync(seller);
            return RedirectToAction(nameof(Index));
        }


        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await _sellerService.RemoveAsync(id);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Seller seller)
        {
            if (!ModelState.IsValid)
            {
                var departaments = await _departmentservice.FindAllAsync();
                var viewModel = new SellerFromViewModel { Seller = seller, Departments = departaments };
                return View(Edit(id, seller));
            }
            if (id != seller.Id)
            {
                return RedirectToAction(nameof(Error), new { message = "ID mismatch" });
            }
            try
            {
                _sellerService.UpdateAsync(seller);
                return RedirectToAction(nameof(Index));
            }
            catch (NotFoundException e)
            {
                return RedirectToAction(nameof(Error), new { message = e.Message });
            }
            catch (DbConcurrencyException e)
            {
                return RedirectToAction(nameof(Error), new { message = e.Message });
            }
        }
    }
}
