using Microsoft.AspNetCore.Mvc;
using SalesWebMVC.Models;
using SalesWebMVC.Models.ViewModels;
using SalesWebMVC.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebMVC.Controllers
{
    public class SellerController : Controller
    {
        private readonly SellerService _sellerService;
        private readonly DepartmentsService _departmentsService;

        public SellerController(SellerService sellerService, DepartmentsService departmentsService)
        {
            _sellerService = sellerService;
            _departmentsService = departmentsService;
        }

        public IActionResult Index()
        {
            var list = _sellerService.FindAll();
            return View(list);
        }

        public IActionResult Create()
        {
            var departments = _departmentsService.FindAll();
            var viewModel = new SellerFormViewModel { Departments = departments };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Seller seller)
        {
            _sellerService.Insert(seller);
            return RedirectToAction(nameof(Index));
        }
    }
}
