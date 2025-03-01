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
    }
}
