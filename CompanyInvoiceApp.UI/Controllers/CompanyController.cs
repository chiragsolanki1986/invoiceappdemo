
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CompanyInvoiceApp.UI.Models;
using CompanyInvoiceApp.UI.Model;
using CompanyInvoiceApp.UI.Services;

namespace CompanyInvoiceApp.UI.Controllers
{
    public class CompanyController : Controller
    {
        public CompanyController()
        {
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Company company)
        {
            if (ModelState.IsValid)
            {
                (bool isSuccsess, string errorMessage) = await ApiService<Company>.Create("Company", company);

                if (isSuccsess)
                    return RedirectToAction("Index", "Home");
                else
                {
                    ModelState.AddModelError("CompanyName", errorMessage);
                }
            }
            return View();
        }
    }
}