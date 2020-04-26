using System;
using System.ComponentModel.DataAnnotations.Schema;
using CompanyInvoiceApp.Api.Repository;

namespace CompanyInvoiceApp.Api.Model
{
    public class InvoiceLineITem: IEntity
    {
        public Guid Id { get; set; }

        //[ForeignKey(nameof(Invoice))]
        public Guid InvoiceId { get; set; }

        public Invoice Invoice { get; set; }

        public string Desccription { get; set; }

        public int Quantity { get; set; }

        public double UnitPrice { get; set; }

        public double Total { get; set;}


    }
}