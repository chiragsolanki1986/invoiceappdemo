using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CompanyInvoiceApp.Api.Repository;

namespace CompanyInvoiceApp.Api.Model
{
    public class Invoice : IEntity
    {
        public Guid Id { get; set; }

        // [NotMapped]
        [ForeignKey(nameof(Company))]
        public string CompanyCode { get; set; }

        public virtual Company Company { get; set; }

        public string InvoiceNumber { get; set; }

        [DataType(DataType.Date)]
        public DateTime InvoiceDate { get; set; }

        public string Remarks { get; set; }

        public virtual CustomerDetails CustomerDetails { get; set; }

        public ShippingDetails ShippingDetails { get; set; }

        public ICollection<InvoiceLineITem> LineItems { get; set; }

        public double Discount { get; set; }

        public double TaxRate { get; set; }

        public double ShippingCharges { get; set; }

        public double SubTotal { get; set; }

        public double SubTotalLessDiscount { get; set; }

        public double TotalTax { get; set; }

        public double BalanceDue { get; set; }

    }
}