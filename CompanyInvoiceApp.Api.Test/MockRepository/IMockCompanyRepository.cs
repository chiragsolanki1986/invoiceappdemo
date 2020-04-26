
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CompanyInvoiceApp.Api.Model;
using CompanyInvoiceApp.Api.Repository;

namespace CompanyInvoiceApp.Api.Test.MockRepository
{

    //Ma we could have created a generic implementation of the repository for the invoice and company ?
    // Yes, but due to time constraint, keeping it separate

    public class MockCompanyRepository : IRepository<Company>
    {
        // private readonly CompanyInvoiceAppDbContext _context;
        // public CompanyRepository(CompanyInvoiceAppDbContext context)
        // {
        //     _context = context;
        // }


        //We can also use in-memory database to test the repository pattern
        List<Company> _companyList = new List<Company>();

        public Task<Company> Add(Company entity)
        {

            //Get a unique 6 digit Alpha numeric for the CompanyId column
            SetUniqueIdForCompany(entity);
            // if(entity.Id == Guid.Empty)
            //     entity.Id = Guid.NewGuid();

            _companyList.Add(entity);
            return Task.FromResult(entity);
        }

        public Task<Company> Delete(Company entity)
        {
            throw new NotImplementedException();
        }

        public Task<List<Company>> GetAllEntities()
        {
            throw new NotImplementedException();
        }

        public Task<List<Company>> GetAllEntitiesForId(string id)
        {
            throw new NotImplementedException();
        }

        public Task<Company> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Company> Update(Company entity)
        {
            throw new NotImplementedException();
        }

        private void SetUniqueIdForCompany(Company entity)
        {
            var firstTwoLetters = entity.CompanyName[0..2].ToUpper();
            var similarCodes = _companyList.Where(c=>c.CompanyName.StartsWith(firstTwoLetters));

            if(similarCodes.Any())
            {
                int _cntr = 0;
               foreach (var item in similarCodes)
               {
                    _cntr= Math.Max(_cntr,  Convert.ToInt16(item.CompanyCode[2..4]));                    
               }
               entity.CompanyCode = firstTwoLetters + _cntr.ToString("D4");
            }
            else
            {
                entity.CompanyCode = firstTwoLetters + "0001";
            }
        }

    }
}