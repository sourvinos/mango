namespace Mango.Services.AuthAPI {

    public interface IJwtTokenGenerator {

        public string GenerateToken(ApplicationUser applicationUser, IEnumerable<string> roles);

    }

}