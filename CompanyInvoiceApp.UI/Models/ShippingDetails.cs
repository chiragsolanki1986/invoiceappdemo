using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace CompanyInvoiceApp.UI.Model
{
    public class ShippingDetails
    {
        public Guid Id { get; set ; }

        public Guid InvoiceId { get; set; }

        public Invoice Invoice { get; set; }


        public string Name { get; set; }

        public string ShipCompanyName { get; set; }

        public string ShippingAddress { get; set; }

        public string PhoneNumber { get; set; }

    }
}