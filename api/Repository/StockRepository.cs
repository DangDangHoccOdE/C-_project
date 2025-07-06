
using api.Data;
using api.Dtos.Stock;
using api.Helpers;
using api.Interfaces;
using api.Mappers;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class StockRepository : IStockRepository
    {
        private readonly ApplicationDBContext _context;

        public StockRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<Stocks> CreateAsync(Stocks stock)
        {
            await _context.Stocks.AddAsync(stock);
            await _context.SaveChangesAsync();
            return stock;
        }

        public async Task<StockDto?> DeleteAsync(int id)
        {
            var stock = await _context.Stocks.FirstOrDefaultAsync(s => s.Id == id);

            if (stock == null)
            {
                return null;
            }

            _context.Stocks.Remove(stock);
            await _context.SaveChangesAsync();

            return stock.ToStockDto();
        }

        public async Task<List<Stocks>> GetAllAsync(QueryObject queryObject)
        {
            var stocks = _context.Stocks.Include(s => s.Comments)
                .ThenInclude(a => a.appUser)
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(queryObject.CompanyName))
            {
                stocks = stocks.Where(s => s.companyName.Contains(queryObject.CompanyName, StringComparison.OrdinalIgnoreCase));
            }

            if (!string.IsNullOrWhiteSpace(queryObject.Symbol))
            {
                stocks = stocks.Where(s => s.Symbol.Contains(queryObject.Symbol, StringComparison.OrdinalIgnoreCase));
            }

            if (!string.IsNullOrWhiteSpace(queryObject.SortBy))
            {
                if (queryObject.SortBy.Equals("Symbol", StringComparison.OrdinalIgnoreCase))
                {
                    stocks = queryObject.IsDescending ? stocks.OrderByDescending(s => s.Symbol) : stocks.OrderBy(s => s.Symbol);
                }
            }

            var skipNumber = (queryObject.PageNumber - 1) * queryObject.PageSize;



            return await stocks.Skip(skipNumber).Take(queryObject.PageSize).ToListAsync();
        }


        public async Task<Stocks?> GetByIdAsync(int id)
        {
           return await _context.Stocks.Include(s => s.Comments)
                                       .FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<Stocks?> GetBySymbolAsync(string symbol)
        {
            return await _context.Stocks.FirstOrDefaultAsync(s => s.Symbol == symbol);
        }

        public Task<bool> IsStockExistsAsync(int id)
        {
            return _context.Stocks.AnyAsync(s => s.Id == id);
        }

        public async Task<Stocks?> UpdateAsync(int id, UpdateStockRequestDto stockRequestDto)
        {
            var existingStock = await _context.Stocks.FirstOrDefaultAsync(s => s.Id == id);

            if (existingStock == null)
            {
                return null;
            }

            existingStock.Symbol = stockRequestDto.Symbol;
            existingStock.companyName = stockRequestDto.companyName;
            existingStock.Purchase = stockRequestDto.Purchase;
            existingStock.LastDiv = stockRequestDto.LastDiv;
            existingStock.Industry = stockRequestDto.Industry;
            existingStock.MarketCap = stockRequestDto.MarketCap;
            
            await _context.SaveChangesAsync();
            return existingStock;
        }
    }
}