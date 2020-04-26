
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
    public class InvoiceController : Controller
    {
        //private readonly ApiService<Invoice> _apiserviceInvoice;
        //private readonly ApiService<Company> _apiserviceCompany;

        public InvoiceController()
        {

        }

        public async Task<IActionResult> Index(string code, string name)
        {
            InvoiceListViewModel invoiceListViewModel = new InvoiceListViewModel();
            invoiceListViewModel.Invoices = await ApiService<InvoiceDetailedModel>.GetList("Invoice/GetByCompany", code);
            invoiceListViewModel.CompanyName = name;

            return View(invoiceListViewModel);
        }

        

        public async Task<IActionResult> Print(Guid id)
        {
            InvoiceDetailedModel invoice = await ApiService<InvoiceDetailedModel>.GetById($"invoice/{id}", null);

            return View(invoice);
        }

        public IActionResult Create(string cid)
        {
            InvoiceViewModel invoice = new InvoiceViewModel() { CompanyCode = cid };
            invoice.InvoiceDate = DateTime.Today.Date;
            invoice.CustomerDetails = new CustomerDetails();
            invoice.ShippingDetails = new ShippingDetails();
            invoice.LineItems = new List<InvoiceLineITem>();
            invoice.NewLineItem = new InvoiceLineITem();
            return View(invoice);
        }

        [HttpPost]
        public async Task<IActionResult> Create(InvoiceViewModel invoice)
        {
            if (ModelState.IsValid)
            {
                (bool isSuccsess, string errorMessage) = await ApiService<Invoice>.Create("Invoice", invoice as Invoice);

                if (isSuccsess)
                    return RedirectToAction("Index", "Home");
                else
                {
                    ModelState.AddModelError("CompanyId", errorMessage);
                }
            }
            return View();
        }

        public IActionResult AddNewItem(InvoiceViewModel invoice)
        {
            invoice.LineItems = invoice.LineItems ?? new List<InvoiceLineITem>();
            invoice.LineItems.Add(new InvoiceLineITem()
            {
                Desccription = invoice.NewLineItem.Desccription,
                Quantity = invoice.NewLineItem.Quantity,
                UnitPrice = invoice.NewLineItem.UnitPrice,
                Total = invoice.NewLineItem.UnitPrice * invoice.NewLineItem.Quantity
            });
            invoice.NewLineItem = new InvoiceLineITem();

            return View(nameof(Create), invoice);
        }
    }
}