using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CompanyInvoiceApp.UI.Model
{
    public class Invoice
    {
        public Guid Id { get; set; }


        //public virtual Company Company { get; set; }
        public string CompanyCode { get; set; }

        public string InvoiceNumber { get; set; }

        [DataType(DataType.Date)]
        public DateTime InvoiceDate { get; set; }

        public string Remarks { get; set; }

        public virtual CustomerDetails CustomerDetails { get; set; }

        public ShippingDetails ShippingDetails { get; set; }

        public List<InvoiceLineITem> LineItems { get; set; }

        public double Discount { get; set; }

        public double TaxRate { get; set; }

        public double ShippingCharges { get; set; }

    }

    public class InvoiceViewModel : Invoice
    {
        public InvoiceLineITem NewLineItem { get; set; }
    }

    
    public class InvoiceDetailedModel : Invoice
    {
        public double SubTotal { get; set; }

        public double SubTotalLessDiscount { get; set; }

        public double TotalTax { get; set; }

        public double BalanceDue { get; set; }
        
        public Company Company { get; set; }

    }

    public class InvoiceListViewModel
    {
        public List<InvoiceDetailedModel> Invoices { get; set; }

        public string CompanyName { get; set; }

    }
}