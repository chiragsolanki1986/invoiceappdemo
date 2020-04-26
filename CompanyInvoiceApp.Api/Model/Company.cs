using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using CompanyInvoiceApp.Api.Repository;

namespace CompanyInvoiceApp.Api.Model
{
     public class Company : IEntity
    {

        //The Company Id to be a 6 digit AlphaNumeric Code
        //Using First two letters of Company Name and then an incremental counter for the day        
        //[StringLength(6)]
        [Key]
        public string CompanyCode { get; set; }

        [Required]
        [StringLength(30)]
        public string CompanyName { get; set; }

        //public string CompanyLogo { get; set; }

        [Required]
        public string AddressLine1 { get; set; }

        public string AddressLine2 { get; set; }

        public string AddressLine3 { get; set; }

        public string ZipCode { get; set; }

        //[Required]
        public string ContactEmailId { get; set; }
                
       public ICollection<Invoice> Invoices { get; set; }

        public ICollection<CustomerDetails> CustomerList { get; set; }
    }    
}