namespace Data
{
    public interface IRequestTimer
    {
        void StartWithCallback(int t, ElapsedEventHadler callback);
    }
}
