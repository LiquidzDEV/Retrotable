using Insight.Database;
using Insight.Database.Providers.MySql;
using MySql.Data.MySqlClient;
using RetroTable.MySql.Tables;

namespace RetroTable.MySql
{
    internal static class Database
    {
        private static MySqlConnectionStringBuilder _connection;

        internal static TableUser User;
        internal static TableRecords Records;
        internal static TableHistory History;
        internal static TableGame Game;

        internal static void Init()
        {
            MySqlInsightDbProvider.RegisterProvider();

            _connection = new MySqlConnectionStringBuilder
            {
                Server = "",
                UserID = "",
                Password = "",
                Port = 3306,
                Database = "retrotable",
                SslMode = MySqlSslMode.None
            };

            User = _connection.Connection().AsParallel<TableUser>();
            Records = _connection.Connection().AsParallel<TableRecords>();
            History = _connection.Connection().AsParallel<TableHistory>();
            Game = _connection.Connection().AsParallel<TableGame>();

            //14-10-2018 10:00:00
        }
    }
}
