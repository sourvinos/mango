namespace Mango.Services.AuthAPI {

    public class LoginResponseDto {

        public required UserDto User { get; set; }
        public required string Token { get; set; }

    }

}

