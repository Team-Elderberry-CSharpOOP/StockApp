namespace Utils
{
    interface IRequestTimer
    {
        void StartWithCallback(int t, ElapsedEventHadler callback);
    }
}
