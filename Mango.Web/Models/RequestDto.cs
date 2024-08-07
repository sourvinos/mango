using static Mango.Web.StaticDetails;

namespace Mango.Web {

    public class RequestDto {

        public ApiType ApiType { get; set; } = ApiType.GET;
        public string? Url { get; set; }
        public object? Data { get; set; }
        public string? AccessToken { get; set; }

    }

}

