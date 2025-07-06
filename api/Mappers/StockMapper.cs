using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Stock;
using api.Models;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace api.Mappers
{
    public static class StockMapper
    {
        public static StockDto ToStockDto(this Models.Stocks stock)
        {
            return new StockDto
            {
                Id = stock.Id,
                Symbol = stock.Symbol,
                companyName = stock.companyName,
                Purchase = stock.Purchase,
                LastDiv = stock.LastDiv,
                Industry = stock.Industry,
                MarketCap = stock.MarketCap,
                Comments = stock.Comments.Select(c => c.ToCommentDto()).ToList() 
            };
        }

        public static Stocks ToStockFromCreateDto(this CreateStockRequestDto stockDto)
        {
            return new Stocks
            {
                Symbol = stockDto.Symbol,
                companyName = stockDto.companyName,
                Purchase = stockDto.Purchase,
                LastDiv = stockDto.LastDiv,
                Industry = stockDto.Industry,
                MarketCap = stockDto.MarketCap
            };
        }
    }
}