namespace StockApp.Profile
{
    internal interface IUser
    {
        void SignUp(string email, string password);
        void SignIn(string email, string password);
    }
}