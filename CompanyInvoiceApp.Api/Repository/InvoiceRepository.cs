
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CompanyInvoiceApp.Api.Data;
using CompanyInvoiceApp.Api.Model;
using Microsoft.EntityFrameworkCore;

namespace CompanyInvoiceApp.Api.Repository
{

    //May we could have created a generic implementation of the repository for the invoice and company ?
    // Yes, but due to time constraint, keeping it separate...but area of improvement

    public class InvoiceRepository : IRepository<Invoice>
    {
        private readonly CompanyInvoiceAppDbContext _context;
        public InvoiceRepository(CompanyInvoiceAppDbContext context)
        {
            _context = context;
        }


        public async Task<Invoice> Add(Invoice entity)
        {
            if (entity.Id == Guid.Empty)
                entity.Id = Guid.NewGuid();

            entity.Company = _context.Companies.First(c => c.CompanyCode == entity.CompanyCode);

            //Get the Invoice Number
            UpdateInvoiceNumber(entity);

            UpdateTotals(entity);

            await _context.Invoices.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        private void UpdateInvoiceNumber(Invoice entity)
        {
            var invoicesForTheDayForCompany = _context.Invoices.Include(i => i.Company)
            .Where(c => c.CompanyCode == entity.CompanyCode && c.InvoiceDate == entity.InvoiceDate)
            .OrderBy(i => i.InvoiceNumber);

            if (invoicesForTheDayForCompany.Any())
            {
                var invoiceNumber = $"{entity.CompanyCode}-{entity.InvoiceDate.ToString("yyMMdd")}-";
            
                var latestInvoice = invoicesForTheDayForCompany.Last();
                int.TryParse(latestInvoice.InvoiceNumber.Substring(14, latestInvoice.InvoiceNumber.Length), out int maxNumber);
                entity.InvoiceNumber = $"{invoiceNumber}{maxNumber++}";
            }
            else
            {
                entity.InvoiceNumber = $"{entity.CompanyCode}-{entity.InvoiceDate.ToString("yyMMdd")}-1";
            }
        }

        public async Task<Invoice> Delete(Invoice entity)
        {
            _context.Invoices.Remove(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<List<Invoice>> GetAllEntities()
        {
            return await _context.Invoices.ToListAsync();
        }

        public async Task<List<Invoice>> GetAllEntitiesForId(string id)
        {
            id = id.ToUpper();
            //Get all the invoice for the company Id
            return await _context.Invoices
            .Include(i => i.LineItems)
            //.Include(i => i.Company)            
            .Where(i => i.CompanyCode == id).ToListAsync();
        }

        public async Task<Invoice> GetById(Guid id)
        {
            return await _context.Invoices
            .Include(i => i.CustomerDetails)
            .Include(i => i.ShippingDetails)
            .Include(i => i.LineItems)
            .Include(i => i.Company)
            .FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<Invoice> Update(Invoice entity)
        {
            UpdateTotals(entity);
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return entity;
        }

        private void UpdateTotals(Invoice i)
        {
            i.SubTotal = 0;
            if (i.LineItems != null)
            {
                foreach (var item in i.LineItems)
                {
                    item.Total = item.UnitPrice * item.Quantity;
                    i.SubTotal += item.Total;
                }
            }

            i.SubTotalLessDiscount = i.SubTotal - i.Discount;
            i.TotalTax = i.SubTotalLessDiscount * ((i.TaxRate / 100));
            i.BalanceDue = i.SubTotalLessDiscount - i.TotalTax + i.ShippingCharges;
        }
    }
}