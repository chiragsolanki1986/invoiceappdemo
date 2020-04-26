using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace CompanyInvoiceApp.UI.Model
{
    public class CustomerDetails
    {
        public Guid Id { get; set; }

        public Guid InvoiceId { get; set; }

        public Invoice Invoice { get; set; }

        public string CustomerContactName { get; set; }

        public string CustomerCompanyName { get; set; }

        public string CustomerAddress { get; set; }

        public string PhoneNumber { get; set; }

        public string CustomerEmail { get; set; }


    }
}