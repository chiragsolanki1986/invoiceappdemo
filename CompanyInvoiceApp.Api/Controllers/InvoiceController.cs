using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using CompanyInvoiceApp.Api.Model;
using CompanyInvoiceApp.Api.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CompanyInvoiceApp.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InvoiceController : ControllerBase
    {
        private readonly IRepository<Invoice> invoiceRepository;
        public InvoiceController(IRepository<Invoice> invoiceRepository)
        {
            this.invoiceRepository = invoiceRepository;
        }

        [Route("[action]")]        
        [HttpGet]
        public async Task<IActionResult> GetByCompany(string id)
        {
            return Ok(await invoiceRepository.GetAllEntitiesForId(id));
        }

        [Route("{id:Guid}")]
        [HttpGet]//("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            return Ok(await invoiceRepository.GetById(id));
        }

        [HttpPost]
        public async Task<IActionResult> AddInvoice(Invoice invoice)
        {
            // try
            // {

            await invoiceRepository.Add(invoice);
            return Ok(invoice.InvoiceNumber);

            //To implement exception filter
            // }
            // catch (Exception ex)
            // {
            //     this.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            //     await this.HttpContext.Response.Body.WriteAsync(Encoding.UTF8. ex.Message)
            //     //this.HttpContext.Response.Body.
            //     //return Task.FromResult( new Exce("Error occured while creating the invoice", ex));
            // }

        }
    }
}
