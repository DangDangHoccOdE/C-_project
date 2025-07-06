using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    [Table("Comments")]
    public class Comment
    {
        public int Id { get; set; }
        public String Title { get; set; } = string.Empty;

        public String Content { get; set; } = string.Empty;

        public DateTime createOn { get; set; } = DateTime.Now;

        public int? StockId { get; set; }

        public Stocks? Stock { get; set; }

        public string? AppUserId { get; set; }

        public AppUser? appUser { get; set; }
    }
}