using cpk.Controllers;
using Models;
using TableDependency.SqlClient;

namespace cpk.SubscribeTableDependencies
{
    public class SubscribeLine1011TableDependency : ISubscribeTableDependencies
    {
        SqlTableDependency<Line1011> tableDependency;
        DataHub dashboardHub;

        public SubscribeLine1011TableDependency(DataHub dashboardHub)
        {
            this.dashboardHub = dashboardHub;
        }

        public void SubscribeTableDependency(string connectionString)
        {
            tableDependency = new SqlTableDependency<Line1011>(connectionString);

            tableDependency.OnChanged += TableDependency_OnChanged;
            tableDependency.OnError += TableDependency_OnError;
            tableDependency.Start();
        }

        private void TableDependency_OnChanged(object sender, TableDependency.SqlClient.Base.EventArgs.RecordChangedEventArgs<Line1011> e)
        {
            if (e.ChangeType != TableDependency.SqlClient.Base.Enums.ChangeType.None)
            {
                dashboardHub.Sendline1011();
            }
        }

        private void TableDependency_OnError(object sender, TableDependency.SqlClient.Base.EventArgs.ErrorEventArgs e)
        {
            Console.WriteLine($"{nameof(Line1011)} SqlTableDependency error: {e.Error.Message}");
        }
    }
}
