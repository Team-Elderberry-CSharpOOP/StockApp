namespace StockWatchApplication.Timers
{
    public interface IRequestTimer
    {
        void StartWithCallback(int t, ElapsedEventHadler callback);
    }
}
