using Microsoft.EntityFrameworkCore;
using SalesWebMVC.Data;
using SalesWebMVC.Models.Entities;

namespace SalesWebMVC.Services
{
    public class SalerRecordService
    {
        private readonly SalesWebMVCContext _context;

        public SalerRecordService(SalesWebMVCContext context)
        {
            _context = context;
        }

        public async Task<List<SalerRecord>> FindAllAsync(Seller seller)
        {
           return await _context.SalerRecord.Include("Seller").Where(s => s.SellerId == seller.Id).ToListAsync();
        }

        public async Task<List<SalerRecord>> FindByDateAsync(DateTime? minDate, DateTime? maxDate)
        {
            var result = from obj in _context.SalerRecord select obj;
            if (minDate.HasValue)
            {
                result = result.Where(x => x.Date >= minDate.Value);
            }
            if (maxDate.HasValue)
            {
                result = result.Where(x => x.Date <= maxDate.Value);
            }
            return await result
                .Include(x => x.Seller)
                .Include(x => x.Seller.Department)
                .OrderBy(d => d.Date)
                .ToListAsync();
        }

        public async Task<List<IGrouping<Department, SalerRecord>>> FindByDateGroupAsync(DateTime? minDate, DateTime? maxDate)
        {
            var result = from obj in _context.SalerRecord select obj;
            if (minDate.HasValue)
            {
                result = result.Where(x => x.Date >= minDate.Value);
            }
            if (maxDate.HasValue)
            {
                result = result.Where(x => x.Date <= maxDate.Value);
            }

            return await result.Include(x => x.Seller).Include(x => x.Seller.Department).OrderByDescending(d => d.Date).GroupBy(x => x.Seller.Department).ToListAsync();
        }
    }

}
