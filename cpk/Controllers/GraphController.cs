//using energy.Data;
//using energy.Models;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using System.Data;

//namespace energy.Controllers
//{
//    public class GraphController : Controller
//    {
//        public readonly AppDbContext _dbContext;
//        public GraphController(AppDbContext dbContext)
//        {
//            _dbContext = dbContext;
//        }

//        public IActionResult Index()
//        {
//            return View();
//        }
//        public IActionResult showData()
//        {
//            return View();
//        }
//        [HttpPost]
//        public List<object> GetSalesData()
//        {
//            List<object> data = new List<object>();
//            List<DateTime> labels = _dbContext.Device1.Select(p => p.Time).ToList();

//            data.Add(labels);
//            List<int> salesCurrent = _dbContext.Device1.Select(p => p.DeviceCurrent).ToList();
//            List<int> salesKWHour = _dbContext.Device1.Select(p => p.KWHour).ToList();
//            List<int> salesVolt = _dbContext.Device1.Select(p => p.volt).ToList();
//            data.Add(salesCurrent);
//            data.Add(salesKWHour);
//            data.Add(salesVolt);

//            return data;
//        }
//        public IActionResult showData2()
//        {
//            return View();
//        }
//        [HttpPost]
//        public List<object> Device2()
//        {
//            List<object> data = new List<object>();
//            List<DateTime> labels = _dbContext.Device2.Select(p => p.Time).ToList();

//            data.Add(labels);
//            List<int> salesCurrent = _dbContext.Device2.Select(p => p.DeviceCurrent).ToList();
//            List<int> salesKWHour = _dbContext.Device2.Select(p => p.KWHour).ToList();
//            List<int> salesVolt = _dbContext.Device2.Select(p => p.volt).ToList();
//            data.Add(salesCurrent);
//            data.Add(salesKWHour);
//            data.Add(salesVolt);

//            return data;
//        }
//        public IActionResult showDevice1PerHour()
//        {
//            return View();
//        }
//        [HttpPost]
//        public List<object> Device1PerHour()
//        {
//            List<object> data = new List<object>();
//            List<DateTime> labels = _dbContext.CurrentVoltKWHourPerHour.Select(p => p.Time).ToList();

//            data.Add(labels);
//            List<int> salesCurrent = _dbContext.CurrentVoltKWHourPerHour.Select(p => p.DeviceCurrent).ToList();
//            List<int> salesKWHour = _dbContext.CurrentVoltKWHourPerHour.Select(p => p.KWHour).ToList();
//            List<int> salesVolt = _dbContext.CurrentVoltKWHourPerHour.Select(p => p.volt).ToList();
           
//            data.Add(salesCurrent);
//            data.Add(salesKWHour);
//            data.Add(salesVolt);

//            return data;
//        }
//        public IActionResult showDevice1PerMinute()
//        {
//            return View();
//        }
//        [HttpPost]
//        public List<object> Device1PerMinute()
//        {
//            List<object> data = new List<object>();
//            List<DateTime> labels = _dbContext.CurrentVoltMinutes.Select(p => p.Time).ToList();

//            data.Add(labels);
//            List<int> salesCurrent = _dbContext.CurrentVoltMinutes.Select(p => p.DeviceCurrent).ToList();
//            List<int> salesVolt = _dbContext.CurrentVoltMinutes.Select(p => p.volt).ToList();

//            data.Add(salesCurrent);
//            data.Add(salesVolt);

//            return data;
//        }
//        public IActionResult showDevice1PerDay()
//        {
//            return View();
//        }
//        [HttpPost]
//        public List<object> Device1PerDay()
//        {
//            List<object> data = new List<object>();
//            List<DateTime> labels = _dbContext.CurrentVoltKWHourPerDay.Select(p => p.Time).ToList();

//            data.Add(labels);
//            List<int> salesCurrent = _dbContext.CurrentVoltKWHourPerDay.Select(p => p.DeviceCurrent).ToList();
//            List<int> salesKWHour = _dbContext.CurrentVoltKWHourPerDay.Select(p => p.KWHour).ToList();
//            List<int> salesVolt = _dbContext.CurrentVoltKWHourPerDay.Select(p => p.volt).ToList();

//            data.Add(salesCurrent);
//            data.Add(salesKWHour);
//            data.Add(salesVolt);

//            return data;
//        }
//        public IActionResult showDevice1PerMonth()
//        {
//            return View();
//        }
//        [HttpPost]
//        public List<object> Device1PerMonth()
//        {
//            List<object> data = new List<object>();
//            List<DateTime> labels = _dbContext.CurrentVoltKWHourPerMonth.Select(p => p.Time).ToList();

//            data.Add(labels);
//            List<int> salesCurrent = _dbContext.CurrentVoltKWHourPerMonth.Select(p => p.DeviceCurrent).ToList();
//            List<int> salesKWHour = _dbContext.CurrentVoltKWHourPerMonth.Select(p => p.KWHour).ToList();
//            List<int> salesVolt = _dbContext.CurrentVoltKWHourPerMonth.Select(p => p.volt).ToList();

//            data.Add(salesCurrent);
//            data.Add(salesKWHour);
//            data.Add(salesVolt);

//            return data;
//        }

//        public IActionResult showDevice1ConsumptionPerDay()
//        {
//            return View();
//        }
//        [HttpPost]
//        public List<object> Device1ConsumptionPerDay()
//        {
//            List<object> data = new List<object>();
//            List<DateTime> labels = _dbContext.ConsumptionPerDay.Select(p => p.Time).ToList();

//            data.Add(labels);
//            List<int> salesCurrent = _dbContext.ConsumptionPerDay.Select(p => p.DeviceCurrent).ToList();
//            List<int> salesKWHour = _dbContext.ConsumptionPerDay.Select(p => p.KWHour).ToList();
//            List<int> salesVolt = _dbContext.ConsumptionPerDay.Select(p => p.volt).ToList();

//            data.Add(salesCurrent);
//            data.Add(salesKWHour);
//            data.Add(salesVolt);

//            return data;
//        }
//        public IActionResult showDevice1ConsumptionPerMonth()
//        {
//            return View();
//        }
//        [HttpPost]
//        public List<object> Device1ConsumptionPerMonth()
//        {
//            List<object> data = new List<object>();
//            List<DateTime> labels = _dbContext.ConsumptionPerMonth.Select(p => p.Time).ToList();

//            data.Add(labels);
//            List<int> salesCurrent = _dbContext.ConsumptionPerMonth.Select(p => p.DeviceCurrent).ToList();
//            List<int> salesKWHour = _dbContext.ConsumptionPerMonth.Select(p => p.KWHour).ToList();
//            List<int> salesVolt = _dbContext.ConsumptionPerMonth.Select(p => p.volt).ToList();

//            data.Add(salesCurrent);
//            data.Add(salesKWHour);
//            data.Add(salesVolt);

//            return data;
//        }
//    }
//}
