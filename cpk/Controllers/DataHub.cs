using cpk.Repositories;
using Microsoft.AspNetCore.SignalR;

namespace cpk.Controllers
{
    public class DataHub : Hub
    {
        LineRepositorie lineRepositorie;

        public DataHub(IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            lineRepositorie = new LineRepositorie(connectionString);
        }
        public async Task Sendline1003()
        {
            var line1003ForGraph = lineRepositorie.GetLine1003ForGraph();
            await Clients.All.SendAsync("ReceivedLine1003ForGraph", line1003ForGraph);
        }
        public async Task Sendline1010()
        {
            var line1010ForGraph = lineRepositorie.GetLine1010ForGraph();
            await Clients.All.SendAsync("ReceivedLine1010ForGraph", line1010ForGraph);
        }
        public async Task Sendline1011()
        {
            var line1011ForGraph = lineRepositorie.GetLine1011ForGraph();
            await Clients.All.SendAsync("ReceivedLine1011ForGraph", line1011ForGraph);
        }
        public async Task Sendline10113()
        {
            var line10113ForGraph = lineRepositorie.GetLine10113ForGraph();
            await Clients.All.SendAsync("ReceivedLine10113ForGraph", line10113ForGraph);
        }
        public async Task Sendline1013()
        {
            var line1013ForGraph = lineRepositorie.GetLine1013ForGraph();
            await Clients.All.SendAsync("ReceivedLine1013ForGraph", line1013ForGraph);
        }
        public async Task Sendline1014()
        {
            var line1014ForGraph = lineRepositorie.GetLine1014ForGraph();
            await Clients.All.SendAsync("ReceivedLine1014ForGraph", line1014ForGraph);
        }
    }
}
