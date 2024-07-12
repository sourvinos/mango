namespace Mango.Services.AuthAPI {

    public class RegistrationRequestDto {

        public required string Email { get; set; }
        public required string Name { get; set; }
        public required string PhoneNumber { get; set; }
        public required string Password { get; set; }
        public required string Role { get; set; }

    }

}

