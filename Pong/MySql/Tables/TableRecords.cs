using RetroTable.Pong;

namespace RetroTable.MySql.Tables
{
    public interface TableRecords
    {
        PongRecords RecordsLoad();
        void RecordsSave(PongRecords records);
    }
}
