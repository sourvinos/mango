using Microsoft.AspNetCore.Identity;

namespace Mango.Services.AuthAPI {

    public class ApplicationUser : IdentityUser {

        public required string Name { get; set; }

    }

}