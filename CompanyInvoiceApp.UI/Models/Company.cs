using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CompanyInvoiceApp.UI.Model
{
     public class Company
    {

        public string CompanyCode { get; set; }

        public string CompanyName { get; set; }

        public string AddressLine1 { get; set; }

        public string AddressLine2 { get; set; }

        public string AddressLine3 { get; set; }

        public string ZipCode { get; set; }

        public string ContactEmailId { get; set; }
                
       public ICollection<Invoice> Invoices { get; set; }

        public ICollection<CustomerDetails> CustomerList { get; set; }
    }    
}