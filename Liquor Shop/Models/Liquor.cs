using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Liquor_Shop.Models
{
    public class Liquor
    {

        [Key]
        //LiquorStore  Id
        public int Id { get; set; }
        //LiquorStore Name
        public string LiquorStore_Name { get; set; }
    }
}
