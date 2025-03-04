using cpk.Repositories;
using Microsoft.AspNetCore.SignalR;
using Models;

namespace cpk.Controllers
{
    public class DataHub : Hub
    {
        LineRepositorie lineRepositorie;
        private static Timer? _timer;
        private static bool _isRunning = false;
        public DataHub(IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            lineRepositorie = new LineRepositorie(connectionString);
        }
        public async Task Sendline1003()
        {
            var (avgValue, lastValue) = lineRepositorie.GetLine1003DetailsFromDb();

            var line1003 = new Line1003
            {
                CpkLin3We3Value = lastValue
            };

            // Send last value and avg value separately
            await Clients.All.SendAsync("ReceivedLine1003", line1003);
            await Clients.All.SendAsync("ReceivedAvgValue", avgValue);

            var line1003ForGraph = lineRepositorie.GetLine1003ForGraph();
            await Clients.All.SendAsync("ReceivedLine1003ForGraph", line1003ForGraph);
        }
        
        public async Task Sendline1010()
        {
            var (avgValue, lastValue) = lineRepositorie.GetLine1010DetailsFromDb();

            var line1010 = new Line1010
            {
                CpkLin10We10Value = lastValue
            };

            // Send last value and avg value separately
            await Clients.All.SendAsync("ReceivedLine1010", line1010);
            await Clients.All.SendAsync("ReceivedAvgValueLine1010", avgValue);

            var line1010ForGraph = lineRepositorie.GetLine1010ForGraph();
            await Clients.All.SendAsync("ReceivedLine1010ForGraph", line1010ForGraph);
        }
        public async Task Sendline1011()
        {
            var (avgValue, lastValue) = lineRepositorie.GetLine1011DetailsFromDb();

            var line1011 = new Line1011
            {
                CpkLin11We11Value = lastValue
            };

            // Send last value and avg value separately
            await Clients.All.SendAsync("ReceivedLine1011", line1011);
            await Clients.All.SendAsync("ReceivedAvgValueLine1011", avgValue);

            var line1011ForGraph = lineRepositorie.GetLine1011ForGraph();
            await Clients.All.SendAsync("ReceivedLine1011ForGraph", line1011ForGraph);
        }
        public async Task Sendline10113()
        {
            var (avgValue, lastValue) = lineRepositorie.GetLine10113DetailsFromDb();

            var line10113 = new Line10113
            {
                CpkLin3We3Value = lastValue
            };

            // Send last value and avg value separately
            await Clients.All.SendAsync("ReceivedLine10113", line10113);
            await Clients.All.SendAsync("ReceivedAvgValueLine10113", avgValue);

            var line10113ForGraph = lineRepositorie.GetLine10113ForGraph();
            await Clients.All.SendAsync("ReceivedLine10113ForGraph", line10113ForGraph);
        }
        public async Task Sendline1013()
        {
            var (avgValue, lastValue) = lineRepositorie.GetLine1013DetailsFromDb();

            var line1013 = new Line1013
            {
                CpkLine13Wei13Value = lastValue
            };

            // Send last value and avg value separately
            await Clients.All.SendAsync("ReceivedLine1013", line1013);
            await Clients.All.SendAsync("ReceivedAvgValueLine1013", avgValue);

            var line1013ForGraph = lineRepositorie.GetLine1013ForGraph();
            await Clients.All.SendAsync("ReceivedLine1013ForGraph", line1013ForGraph);
        }
        public async Task Sendline1014()
        {
            var (avgValue, lastValue) = lineRepositorie.GetLine1014DetailsFromDb();

            var line1014 = new Line1014
            {
                CpkLine14We14Value= lastValue
            };

            // Send last value and avg value separately
            await Clients.All.SendAsync("ReceivedLine1014", line1014);
            await Clients.All.SendAsync("ReceivedAvgValueLine1014", avgValue);

            var line1014ForGraph = lineRepositorie.GetLine1014ForGraph();
            await Clients.All.SendAsync("ReceivedLine1014ForGraph", line1014ForGraph);
        }
       
    }
}
