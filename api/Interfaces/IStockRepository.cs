using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Stock;
using api.Helpers;
using api.Models;

namespace api.Interfaces
{
    public interface IStockRepository
    {
        Task<List<Stocks>> GetAllAsync(QueryObject query);
        Task<Stocks?> GetByIdAsync(int id);
        Task<Stocks?> GetBySymbolAsync(string symbol);
        Task<Stocks> CreateAsync(Stocks stock);
        Task<Stocks?> UpdateAsync(int id, UpdateStockRequestDto stockRequestDto);
        Task<StockDto?> DeleteAsync(int id);
        Task<bool> IsStockExistsAsync(int id);
    }
}