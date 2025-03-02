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
            var line1003Data = await _context.Line1003s
               .OrderByDescending(entry => entry.CpkLin3We3Timestamp)
               .Take(1)
               .Select(entry => new {
                   timestamp = entry.CpkLin3We3Timestamp,
                   value = entry.CpkLin3We3Value
               })
               .ToListAsync();
            var line1003Avg = await _context.Line1003s
                .OrderByDescending(entry => entry.CpkLin3We3Timestamp)
                .Take(30)
                .Select(entry => entry.CpkLin3We3Value)
                .AverageAsync();
            await _hubContext.Clients.All.SendAsync("ReceiveLatestDataline1003", "line1003", line1003Avg);

            var line1010Data = await _context.Line1010s
                .OrderByDescending(entry => entry.CpkLin10We10Timestamp)
                .Take(1)
                .Select(entry => new {
                    timestamp = entry.CpkLin10We10Timestamp,
                    value = entry.CpkLin10We10Value
                })
                .ToListAsync();
            var line1010Avg = await _context.Line1010s
                .OrderByDescending(entry => entry.CpkLin10We10Timestamp)
                .Take(30)
                .Select(entry => entry.CpkLin10We10Value)
                .AverageAsync();

            var line1011Data = await _context.Line1011s
                .OrderByDescending(entry => entry.CpkLin11We11Timestamp)
                .Take(1)
                .Select(entry => new {
                    timestamp = entry.CpkLin11We11Timestamp,
                    value = entry.CpkLin11We11Value
                })
                .ToListAsync();
            var line1011Avg = await _context.Line1011s
                .OrderByDescending(entry => entry.CpkLin11We11Timestamp)
                .Take(30)
                .Select(entry => entry.CpkLin11We11Value)
                .AverageAsync();

            var line1013Data = await _context.Line1013s
                .OrderByDescending(entry => entry.CpkLine13Wei13Timestamp)
                .Take(1)
                .Select(entry => new {
                    timestamp = entry.CpkLine13Wei13Timestamp,
                    value = entry.CpkLine13Wei13Value
                })
                .ToListAsync();

            var line1013Avg = await _context.Line1013s
                .OrderByDescending(entry => entry.CpkLine13Wei13Timestamp)
                .Take(30)
                .Select(entry => entry.CpkLine13Wei13Value)
                .AverageAsync();

            var line10113Data = await _context.Line10113s
                .OrderByDescending(entry => entry.CpkLin3We3Timestamp)
                .Take(1)
                .Select(entry => new {
                    timestamp = entry.CpkLin3We3Timestamp,
                    value = entry.CpkLin3We3Value
                })
                .ToListAsync();
            var line10113Avg = await _context.Line10113s
                .OrderByDescending(entry => entry.CpkLin3We3Timestamp)
                .Take(30)
                .Select(entry => entry.CpkLin3We3Value)
                .AverageAsync();
                
            var line1014Data = await _context.Line1014s
                .OrderByDescending(entry => entry.CpkLine14We14Timestamp)
                .Take(1)
                .Select(entry => new {
                    timestamp = entry.CpkLine14We14Timestamp,
                    value = entry.CpkLine14We14Value
                })
                .ToListAsync();

            var line1014Avg = await _context.Line1014s
               .OrderByDescending(entry => entry.CpkLine14We14Timestamp)
               .Take(30)
               .Select(entry => entry.CpkLine14We14Value)
               .AverageAsync();

            ViewBag.Line1003Weight = line1003Data.FirstOrDefault()?.value ?? 0;
            ViewBag.Line1010Weight = line1010Data.FirstOrDefault()?.value ?? 0;
            ViewBag.Line1011Weight = line1011Data.FirstOrDefault()?.value ?? 0;
            ViewBag.Line1013Weight = line1013Data.FirstOrDefault()?.value ?? 0;
            ViewBag.Line10113Weight = line10113Data.FirstOrDefault()?.value ?? 0;
            ViewBag.Line1014Weight = line1014Data.FirstOrDefault()?.value ?? 0;

            ViewBag.Line1003Average = line1003Avg; // Store it in ViewBag
            ViewBag.Line1010Average = line1010Avg; // Store it in ViewBag
            ViewBag.Line1011Average = line1011Avg; // Store it in ViewBag
            ViewBag.Line1013Average = line1013Avg; // Store it in ViewBag
            ViewBag.Line10113Average = line10113Avg; // Store it in ViewBag
            ViewBag.Line1014Average = line1014Avg; // Store it in ViewBag


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
