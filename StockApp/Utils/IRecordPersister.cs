namespace StockApp.Utils
{
    interface IRecordPersister
    {
        void AddRecord(string record);
        void ClearRecords();
        string GetRecords();
    }
}
