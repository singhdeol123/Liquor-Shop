using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Liquor_Shop.Models
{
    public class Seller
    {
        [Key]
        //Seller Id
        public int Id { get; set; }
        //Seller Name
        public string Seller_Name { get; set; }
        //Seller Address
        public string Seller_Address { get; set; }
        //Seller Contact
        public string Seller_Contact { get; set; }
    }
}
