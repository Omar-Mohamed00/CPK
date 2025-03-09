using cpk.Models;
using Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace cpk.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHubContext<DataHub> _hubContext;
        private readonly Cpk25Context _context;
        public HomeController(ILogger<HomeController> logger, Cpk25Context context, IHubContext<DataHub> hubContext)
        {
            _logger = logger;
            _context = context;
            _hubContext = hubContext;
        }
        public async Task<IActionResult> Index()
        {
            try
            {
                var line1003Data = await _context.Line1003s
              .OrderBy(l => l.CpkLin3We3Timestamp)
              .Take(1)
              .Select(entry => new {
                  timestamp = (DateTime?)entry.CpkLin3We3Timestamp,
                  value = (double?)entry.CpkLin3We3Value
              })
              .ToListAsync();

                double? line1003Avg = await _context.Line1003s
                    .OrderBy(entry => entry.CpkLin3We3Timestamp)
                    .Take(40)
                    .Select(entry => (double?)entry.CpkLin3We3Value)
                    .AverageAsync();
                ViewBag.Line1003Weight = line1003Data.FirstOrDefault()?.value;
                ViewBag.Line1003Average = line1003Avg;
            }
            catch
            {
                return View();
            }
            try
            {
                var line1010Data = await _context.Line1010s
                .OrderBy(entry => entry.CpkLin10We10Timestamp)
                .Take(1)
                .Select(entry => new {
                    timestamp = (DateTime?)entry.CpkLin10We10Timestamp,
                    value = (double?)entry.CpkLin10We10Value
                })
                .ToListAsync();

                double? line1010Avg = await _context.Line1010s
                    .OrderBy(entry => entry.CpkLin10We10Timestamp)
                    .Take(40)
                    .Select(entry => (double?)entry.CpkLin10We10Value)
                    .AverageAsync();
                ViewBag.Line1010Weight = line1010Data.FirstOrDefault()?.value;
                ViewBag.Line1010Average = line1010Avg;
            }
            catch
            {
                return View();
            }
            try
            {
                var line1011Data = await _context.Line1011s
                .OrderBy(entry => entry.CpkLin11We11Timestamp)
                .Take(1)
                .Select(entry => new {
                    timestamp = (DateTime?)entry.CpkLin11We11Timestamp,
                    value = (double?)entry.CpkLin11We11Value
                })
                .ToListAsync();

                double? line1011Avg = await _context.Line1011s
                    .OrderBy(entry => entry.CpkLin11We11Timestamp)
                    .Take(40)
                    .Select(entry => (double?)entry.CpkLin11We11Value)
                    .AverageAsync();
                ViewBag.Line1011Weight = line1011Data.FirstOrDefault()?.value;
                ViewBag.Line1011Average = line1011Avg;
            }
            catch
            {
                return View();
            }
            try
            {

                var line1013Data = await _context.Line1013s
                    .OrderBy(entry => entry.CpkLine13Wei13Timestamp)
                    .Take(1)
                    .Select(entry => new {
                        timestamp = (DateTime?)entry.CpkLine13Wei13Timestamp,
                        value = (double?)entry.CpkLine13Wei13Value
                    })
                    .ToListAsync();

                double? line1013Avg = await _context.Line1013s
                    .OrderBy(entry => entry.CpkLine13Wei13Timestamp)
                    .Take(40)
                    .Select(entry => (double?)entry.CpkLine13Wei13Value)
                    .AverageAsync();
                ViewBag.Line1013Weight = line1013Data.FirstOrDefault()?.value;
                ViewBag.Line1013Average = line1013Avg;
            }
            catch
            {
                return View();
            }
            try
            {
                var line10113Data = await _context.Line10113s
                    .OrderBy(entry => entry.CpkLin3We3Timestamp)
                    .Take(1)
                    .Select(entry => new {
                        timestamp = (DateTime?)entry.CpkLin3We3Timestamp,
                        value = (double?)entry.CpkLin3We3Value
                    })
                    .ToListAsync();

                double? line10113Avg = await _context.Line10113s
                    .OrderBy(entry => entry.CpkLin3We3Timestamp)
                    .Take(40)
                    .Select(entry => (double?)entry.CpkLin3We3Value)
                    .AverageAsync();

                ViewBag.Line10113Weight = line10113Data.FirstOrDefault()?.value;
                ViewBag.Line10113Average = line10113Avg;
            }
            catch
            {
                return View();
            }
            try
            {
                var line1014Data = await _context.Line1014s
               .OrderBy(entry => entry.CpkLine14We14Timestamp)
               .Take(1)
               .Select(entry => new {
                   timestamp = (DateTime?)entry.CpkLine14We14Timestamp,
                   value = (double?)entry.CpkLine14We14Value
               })
               .ToListAsync();

                double? line1014Avg = await _context.Line1014s
                   .OrderBy(entry => entry.CpkLine14We14Timestamp)
                   .Take(40)
                   .Select(entry => (double?)entry.CpkLine14We14Value)
                   .AverageAsync();

                ViewBag.Line1014Weight = line1014Data.FirstOrDefault()?.value;
                ViewBag.Line1014Average = line1014Avg;
            }
            catch
            {
                return View();
            }
            return View();
        }

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
