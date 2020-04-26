using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace CompanyInvoiceApp.UI.Model
{
    public class InvoiceLineITem
    {
        public Guid Id { get; set; }

        public Guid InvoiceId { get; set; }

        public Invoice Invoice { get; set; }

        public string Desccription { get; set; }

        public int Quantity { get; set; }

        public double UnitPrice { get; set; }

        public double Total { get; set;}


    }
}