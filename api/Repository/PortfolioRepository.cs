using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class PortfolioRepository : IPortfolioRepository
    {
        private readonly ApplicationDBContext _context;

        public PortfolioRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<Portfolio> CreateAsync(Portfolio portfolio)
        {
            await _context.portfolios.AddAsync(portfolio);
            await _context.SaveChangesAsync();
            return portfolio;
        }

        public async Task<Portfolio> DeletePortfolio(AppUser appUser, string symbol)
        {
            var portfolioModel = await _context.portfolios.FirstOrDefaultAsync(x => x.AppUserId == appUser.Id && x.stock.Symbol.ToLower() == symbol.ToLower());

            if (portfolioModel == null)
            {
                return null;
            }

            _context.portfolios.Remove(portfolioModel);

            await _context.SaveChangesAsync();
            return portfolioModel;
        }

        public Task<List<Stocks>> GetUserPortfolio(AppUser user)
        {
            return _context.portfolios.Where(p => p.AppUserId == user.Id)
            .Select(stock => new Stocks
            {
                Id = stock.stockId,
                Symbol = stock.stock.Symbol,
                companyName = stock.stock.companyName,
                Purchase = stock.stock.Purchase,
                LastDiv = stock.stock.LastDiv,
                Industry = stock.stock.Industry,
                MarketCap = stock.stock.MarketCap
            }).ToListAsync();
        }
    }
}