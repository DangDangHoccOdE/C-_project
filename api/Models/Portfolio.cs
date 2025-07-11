using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    [Table("Portfolio")]
    public class Portfolio
    {
        public string AppUserId { get; set; }

        public int stockId { get; set; }

        public AppUser appUser { get; set; }
        public Stocks stock { get; set; }
    }
}