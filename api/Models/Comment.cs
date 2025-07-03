using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public String Title { get; set; } = string.Empty;

        public String Content { get; set; } = string.Empty;

        public DateTime createOn { get; set; } = DateTime.Now;

        public int? StockId { get; set; }

        public Stocks? Stock { get; set; }


    }
}