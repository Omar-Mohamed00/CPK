using cpk.Controllers;
using Models;
using TableDependency.SqlClient;

namespace cpk.SubscribeTableDependencies
{
    public class SubscribeLine1003TableDependency : ISubscribeTableDependencies
    {
        SqlTableDependency<Line1003> tableDependency;
        DataHub dashboardHub;

        public SubscribeLine1003TableDependency(DataHub dashboardHub)
        {
            this.dashboardHub = dashboardHub;
        }

        public void SubscribeTableDependency(string connectionString)
        {
            //tableDependency = new SqlTableDependency<Line1003>(
            //    connectionString,
            //    tableName: "Line1003",
            //    executeUserPermissionCheck: false
            //);
            tableDependency = new SqlTableDependency<Line1003>(connectionString);

            tableDependency.OnChanged += TableDependency_OnChanged;
            tableDependency.OnError += TableDependency_OnError;
            tableDependency.Start();
        }

        private void TableDependency_OnChanged(object sender, TableDependency.SqlClient.Base.EventArgs.RecordChangedEventArgs<Line1003> e)
        {
            if (e.ChangeType != TableDependency.SqlClient.Base.Enums.ChangeType.None)
            {
                dashboardHub.Sendline1003();
            }
        }

        private void TableDependency_OnError(object sender, TableDependency.SqlClient.Base.EventArgs.ErrorEventArgs e)
        {
            Console.WriteLine($"{nameof(Line1003)} SqlTableDependency error: {e.Error.Message}");
        }
    }
}
