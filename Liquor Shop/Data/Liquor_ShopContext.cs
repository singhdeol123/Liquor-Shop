using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Liquor_Shop.Models;

namespace Liquor_Shop.Data
{
    public class Liquor_ShopContext : DbContext
    {
        public Liquor_ShopContext (DbContextOptions<Liquor_ShopContext> options)
            : base(options)
        {
        }

        public DbSet<Liquor_Shop.Models.Liquor> Liquor { get; set; }

        public DbSet<Liquor_Shop.Models.Seller> Seller { get; set; }

        public DbSet<Liquor_Shop.Models.Buyer> Buyer { get; set; }
    }
}
