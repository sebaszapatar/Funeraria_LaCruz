namespace Funeraria_LaCruz.WEB.Auth
{
    public interface ILoginService
    {

        Task LoginAsync(string token);

        Task LogoutAsync();

    }
}
