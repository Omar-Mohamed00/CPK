using cpk.Controllers;
using Models;
using TableDependency.SqlClient;

namespace cpk.SubscribeTableDependencies
{
    public class SubscribeLine1010TableDependency : ISubscribeTableDependencies
    {
        SqlTableDependency<Line1010> tableDependency;
        DataHub dashboardHub;

        public SubscribeLine1010TableDependency(DataHub dashboardHub)
        {
            this.dashboardHub = dashboardHub;
        }

        public void SubscribeTableDependency(string connectionString)
        {
            tableDependency = new SqlTableDependency<Line1010>(connectionString);

            tableDependency.OnChanged += TableDependency_OnChanged;
            tableDependency.OnError += TableDependency_OnError;
            tableDependency.Start();
        }

        private void TableDependency_OnChanged(object sender, TableDependency.SqlClient.Base.EventArgs.RecordChangedEventArgs<Line1010> e)
        {
            if (e.ChangeType != TableDependency.SqlClient.Base.Enums.ChangeType.None)
            {
                dashboardHub.Sendline1010();
            }
        }

        private void TableDependency_OnError(object sender, TableDependency.SqlClient.Base.EventArgs.ErrorEventArgs e)
        {
            Console.WriteLine($"{nameof(Line1010)} SqlTableDependency error: {e.Error.Message}");
        }
    }
}
