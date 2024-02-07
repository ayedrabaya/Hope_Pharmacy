using HopePharmacy.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace HopePharmacy.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            Entities.HopeDecemberPharmacyContext context = new Entities.HopeDecemberPharmacyContext();
            ViewBag.Revenue = context.Invoices.ToList().Sum(x =>x.ProfitPrice);
            ViewBag.Patient = context.Patients.ToList().Count();
            ViewBag.Supplier = context.Suppliers.ToList().Count();
            ViewBag.Medicine = context.Medicines.ToList().Count();

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

