using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.Stock
{
    public class UpdateStockRequestDto
    {
                [Required]
        [MinLength(5, ErrorMessage = "Symbol must be at least 5 characters long.")]
        [MaxLength(10, ErrorMessage = "Symbol must not exceed 10 characters.")]
        public string Symbol { get; set; } = string.Empty;

        [Required(ErrorMessage = "Company name is required.")]
        [MinLength(1, ErrorMessage = "Company name must be at least 1 character long.")]
        [MaxLength(100, ErrorMessage = "Company name must not exceed 100 characters.")]
        public string companyName { get; set; } = string.Empty;

        [Range(0, double.MaxValue, ErrorMessage = "Purchase price must be a non-negative value.")]
        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal Purchase { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Last dividend must be a non-negative value.")]
        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal LastDiv { get; set; }

        [Required(ErrorMessage = "Industry is required.")]
        [MinLength(1, ErrorMessage = "Industry must be at least 1 character long.")]
        [MaxLength(50, ErrorMessage = "Industry must not exceed 50 characters.")]
        public string Industry { get; set; } = string.Empty;

        [Range(0, long.MaxValue, ErrorMessage = "Market cap must be a non-negative value.")]
        [DisplayFormat(DataFormatString = "{0:N0}")]    
        public long MarketCap { get; set; }
    }
}