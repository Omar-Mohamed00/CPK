using cpk.Models;
using Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace cpk.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly Cpk25Context _context;
        public HomeController(ILogger<HomeController> logger, Cpk25Context context)
        {
            _logger = logger;
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllData()
        {
            var line1003Data = await _context.Line1003s
                .Select(entry => new {
                    timestamp = entry.CpkLin3We3Timestamp,
                    value = entry.CpkLin3We3Value
                })
                .ToListAsync();

            var line1010Data = await _context.Line1010s
                .Select(entry => new {
                    timestamp = entry.CpkLin10We10Timestamp,
                    value = entry.CpkLin10We10Value
                })
                .ToListAsync();

            var line1011Data = await _context.Line1011s
                .Select(entry => new {
                    timestamp = entry.CpkLin11We11Timestamp,
                    value = entry.CpkLin11We11Value
                })
                .ToListAsync();

            var line1013Data = await _context.Line1013s
                .Select(entry => new {
                    timestamp = entry.CpkLine13Wei13Timestamp,
                    value = entry.CpkLine13Wei13Value
                })
                .ToListAsync();

            var line1014Data = await _context.Line1014s
                .Select(entry => new {
                    timestamp = entry.CpkLine14We14Timestamp,
                    value = entry.CpkLine14We14Value
                })
                .ToListAsync();

            // Store data in ViewBag
            ViewBag.Line1003Data = line1003Data;
            ViewBag.Line1010Data = line1010Data;
            ViewBag.Line1011Data = line1011Data;
            ViewBag.Line1013Data = line1013Data;
            ViewBag.Line1014Data = line1014Data;

            return View();
        }
        //[HttpGet]
        //public async Task<IActionResult> GetAllData()
        //{
        //    var line1003Data = await _context.Line1003s
        //        .Select(entry => new {
        //            timestamp = entry.CpkLin3We3Timestamp,
        //            value = entry.CpkLin3We3Value
        //        })
        //        .ToListAsync();

        //    var line1010Data = await _context.Line1010s
        //        .Select(entry => new {
        //            timestamp = entry.CpkLin10We10Timestamp,
        //            value = entry.CpkLin10We10Value
        //        })
        //        .ToListAsync();

        //    var line1011Data = await _context.Line1011s
        //        .Select(entry => new {
        //            timestamp = entry.CpkLin11We11Timestamp,
        //            value = entry.CpkLin11We11Value
        //        })
        //        .ToListAsync();

        //    // Store data in ViewBag
        //    ViewBag.Line1003Data = line1003Data;
        //    ViewBag.Line1010Data = line1010Data;
        //    ViewBag.Line1011Data = line1011Data;

        //    return View();
        //}


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
