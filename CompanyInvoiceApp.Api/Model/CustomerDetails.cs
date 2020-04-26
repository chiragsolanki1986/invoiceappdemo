using System;
using System.ComponentModel.DataAnnotations.Schema;
using CompanyInvoiceApp.Api.Repository;

namespace CompanyInvoiceApp.Api.Model
{
    public class CustomerDetails : IEntity
    {
        public Guid Id { get; set; }

        //[ForeignKey(nameof(Invoice))]
        public Guid InvoiceId { get; set; }

        public Invoice Invoice { get; set; }

        public string CustomerContactName { get; set; }

        public string CustomerCompanyName { get; set; }

        public string CustomerAddress { get; set; }

        public string PhoneNumber { get; set; }

        public string CustomerEmail { get; set; }
        

    }
}