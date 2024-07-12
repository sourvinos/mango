namespace Mango.Web {

    public interface ITokenProvider {

        void SetToken(string token);
        string? GetToken();
        void ClearToken();

    }

}
