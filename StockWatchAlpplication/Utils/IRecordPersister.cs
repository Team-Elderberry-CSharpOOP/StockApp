namespace Utils
{
    public interface IRecordPersister
    {
        void AddRecord(string record);
        void ClearRecords();
        string GetRecords();
    }

}
