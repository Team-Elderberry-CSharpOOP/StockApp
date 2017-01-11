namespace Profile
{
    internal interface IUser
    {
        void SignUp(string email, string password);
        bool SignIn(string email, string password);
    }
}