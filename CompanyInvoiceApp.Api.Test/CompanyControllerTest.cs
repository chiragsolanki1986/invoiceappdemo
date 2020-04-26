using NUnit.Framework;
using CompanyInvoiceApp.Api.Controllers;
using CompanyInvoiceApp.Api.Repository;
using CompanyInvoiceApp.Api.Model;
using CompanyInvoiceApp.Api.Test.MockRepository;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CompanyInvoiceApp.Api.Test
{
    public class CompanyControllerTest
    {
        CompanyController _companyController; 


        [SetUp]
        public void Setup()
        {
            IRepository<Company> repository = new MockCompanyRepository(); 
            _companyController = new CompanyController(repository);
        }

        [Test]
        public async void Create_Company_Test()
        {

            Company comp1 = new Company();
            comp1.CompanyName = "Test Company";
            comp1.AddressLine1 = "AddressLine 1";
            comp1.AddressLine2 = "AddressLine 2";
            comp1.AddressLine3 = "AddressLine 3";
            comp1.ZipCode = "600001";
            comp1.ContactEmailId = "mocktest@gmail.com";


            OkObjectResult createCompanyResult = await _companyController.AddCompany(comp1) as OkObjectResult;

            Assert.IsNotNull(createCompanyResult);
            Assert.IsTrue(createCompanyResult.StatusCode == (int)HttpStatusCode.OK);
            Assert.IsTrue(createCompanyResult.Value.ToString() == "TE0001");            
            
        }
    }
}