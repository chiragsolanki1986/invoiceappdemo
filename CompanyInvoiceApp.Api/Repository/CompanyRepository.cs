
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CompanyInvoiceApp.Api.Data;
using CompanyInvoiceApp.Api.Model;
using Microsoft.EntityFrameworkCore;

namespace CompanyInvoiceApp.Api.Repository
{

    //Ma we could have created a generic implementation of the repository for the invoice and company ?
    // Yes, but due to time constraint, keeping it separate

    public class CompanyRepository : IRepository<Company>
    {
        private readonly CompanyInvoiceAppDbContext _context;
        public CompanyRepository(CompanyInvoiceAppDbContext context)
        {
            _context = context;
        }


        public async Task<Company> Add(Company entity)
        {

            //Get a unique 6 digit Alpha numeric for the CompanyId column
            SetUniqueIdForCompany(entity);
            // if(entity.Id == Guid.Empty)
            //     entity.Id = Guid.NewGuid();

            await _context.Companies.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        private void SetUniqueIdForCompany(Company entity)
        {
            var firstTwoLetters = entity.CompanyName[0..2].ToUpper();
            var similarCodes = _context.Companies.Where(c=>c.CompanyName.StartsWith(firstTwoLetters));

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

        public async Task<Company> Delete(Company entity)
        {
             _context.Companies.Remove(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<List<Company>> GetAllEntities()
        {
            return await _context.Companies.ToListAsync();
        }

        public async Task<Company> GetById(Guid id)
        {
            return await _context.Companies.FindAsync(id);
        }

        public async Task<Company> Update(Company entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task<List<Company>> GetAllEntitiesForId(string id)
        {
            return await _context.Companies.Where(c => c.CompanyCode == id).ToListAsync();
        }

    }
}