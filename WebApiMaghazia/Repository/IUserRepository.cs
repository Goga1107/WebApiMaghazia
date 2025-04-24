namespace WebApiMaghazia.Repository
{
    public interface IUserRepository
    {
        Task Register(string name, string password, string role,string email);
        string Login(string userName, string password);
    }
}
