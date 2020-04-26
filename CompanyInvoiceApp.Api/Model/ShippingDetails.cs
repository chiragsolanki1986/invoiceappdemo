using System;
using System.ComponentModel.DataAnnotations.Schema;
using CompanyInvoiceApp.Api.Repository;

namespace CompanyInvoiceApp.Api.Model
{
    public class ShippingDetails : IEntity
    {
        public Guid Id { get; set ; }

        //[ForeignKey(nameof(Invoice))]
        public Guid InvoiceId { get; set; }

        public Invoice Invoice { get; set; }


        public string Name { get; set; }

        public string ShipCompanyName { get; set; }

        public string ShippingAddress { get; set; }

        public string PhoneNumber { get; set; }
        


    }
}