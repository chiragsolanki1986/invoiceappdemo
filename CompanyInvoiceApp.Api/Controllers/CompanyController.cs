using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CompanyInvoiceApp.Api.Model;
using CompanyInvoiceApp.Api.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CompanyInvoiceApp.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CompanyController : ControllerBase
    {
        private readonly IRepository<Company> companyRepository;
        public CompanyController(IRepository<Company> companyRepository)
        {
            this.companyRepository = companyRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await companyRepository.GetAllEntities());
        }

        [HttpPost]
        public async Task<IActionResult> AddCompany(Company company)
        {
            await companyRepository.Add(company);
            return Ok(company.CompanyCode);

            //To implement exception filter to handle the specific errors
        }
    }
}
