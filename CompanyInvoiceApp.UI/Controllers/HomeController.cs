using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CompanyInvoiceApp.UI.Models;
using CompanyInvoiceApp.UI.Services;
using CompanyInvoiceApp.UI.Model;

namespace CompanyInvoiceApp.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApiService<Company> _apiService;

        public HomeController(ILogger<HomeController> logger, ApiService<Company> apiService)
        {
            _logger = logger;
            this._apiService = apiService;
        }

        public async Task<IActionResult> Index()
        {
            var listOfCompanies = await ApiService<Company>.GetList("Company");

            return View(listOfCompanies);
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
