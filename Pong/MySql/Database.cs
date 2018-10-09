using Insight.Database;
using Insight.Database.Providers.MySql;
using MySql.Data.MySqlClient;
using RetroTable.MySql.Tables;

namespace RetroTable.MySql
{
    internal class Database
    {
        private static MySqlConnectionStringBuilder connection;

        internal static TableUser User;
        internal static TableRecords Records;
        internal static TableRankings Rankings;
        internal static TableGame Game;

        internal static void Init()
        {
            MySqlInsightDbProvider.RegisterProvider();

            connection = new MySqlConnectionStringBuilder();

            connection.Server = "85.214.66.124";
            connection.UserID = "retro";
            connection.Password = "BQnmDXC74p_WRT$8";
            connection.Port = 3306;
            connection.Database = "retro";

            User = connection.Connection().AsParallel<TableUser>();
            Records = connection.Connection().AsParallel<TableRecords>();
            Rankings = connection.Connection().AsParallel<TableRankings>();
            Game = connection.Connection().AsParallel<TableGame>();
        }
    }
}
