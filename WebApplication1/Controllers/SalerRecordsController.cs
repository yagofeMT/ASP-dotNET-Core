#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SalesWebMVC.Data;
using SalesWebMVC.Models.Entities;
using SalesWebMVC.Services;

namespace SalesWebMVC.Controllers
{
    public class SalerRecordsController : Controller
    {
        private readonly SalerRecordService _context;

        public SalerRecordsController(SalerRecordService context)
        {
            _context = context;
        }

        // GET: SalesRecords
        public async Task<IActionResult> Index()
        {
            
            return View();
        }

        public async Task<IActionResult> SimpleSearch(DateTime? minDate, DateTime? maxDate)
        {
            if (!minDate.HasValue)
            {
                minDate = new DateTime(DateTime.Now.Year, 1, 1);
            };
            if (!maxDate.HasValue)
            {
                maxDate = DateTime.Now;
            }

            ViewData["minDate"] = minDate.Value.ToString("mm-dd-yyyy");
            ViewData["maxDate"] = maxDate.Value.ToString("mm-dd-yyyy");
            var result =  await _context.FindByDateAsync(minDate, maxDate);
            return View(result);

        }

        public async Task<IActionResult> GroupingSearch(DateTime? minDate, DateTime? maxDate)
        {
            if (!minDate.HasValue)
            {
                minDate = new DateTime(DateTime.Now.Year, 1, 1);
            };
            if (!maxDate.HasValue)
            {
                maxDate = DateTime.Now;
            }

            ViewData["minDate"] = minDate.Value.ToString("mm-dd-yyyy");
            ViewData["maxDate"] = maxDate.Value.ToString("mm-dd-yyyy");
            var result = await _context.FindByDateGroupAsync(minDate, maxDate);
            return View(result);
        }
    }
}
