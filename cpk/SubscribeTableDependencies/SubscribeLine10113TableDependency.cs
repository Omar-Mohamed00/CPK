using cpk.Controllers;
using Models;
using TableDependency.SqlClient;

namespace cpk.SubscribeTableDependencies
{
    public class SubscribeLine10113TableDependency : ISubscribeTableDependencies
    {
        SqlTableDependency<Line10113> tableDependency;
        DataHub dashboardHub;

        public SubscribeLine10113TableDependency(DataHub dashboardHub)
        {
            this.dashboardHub = dashboardHub;
        }

        public void SubscribeTableDependency(string connectionString)
        {
            tableDependency = new SqlTableDependency<Line10113>(connectionString);

            tableDependency.OnChanged += TableDependency_OnChanged;
            tableDependency.OnError += TableDependency_OnError;
            tableDependency.Start();
        }

        private void TableDependency_OnChanged(object sender, TableDependency.SqlClient.Base.EventArgs.RecordChangedEventArgs<Line10113> e)
        {
            if (e.ChangeType != TableDependency.SqlClient.Base.Enums.ChangeType.None)
            {
                dashboardHub.Sendline10113();
            }
        }

        private void TableDependency_OnError(object sender, TableDependency.SqlClient.Base.EventArgs.ErrorEventArgs e)
        {
            Console.WriteLine($"{nameof(Line10113)} SqlTableDependency error: {e.Error.Message}");
        }
    }
}
