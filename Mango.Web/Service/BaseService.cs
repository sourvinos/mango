using System.Net;
using System.Text;
using Newtonsoft.Json;
using static Mango.Web.StaticDetails;

namespace Mango.Web {

    public class BaseService : IBaseService {

        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ITokenProvider _tokenProvider;

        public BaseService(IHttpClientFactory httpClientFactory, ITokenProvider tokenProvider) {
            _httpClientFactory = httpClientFactory;
            _tokenProvider = tokenProvider;
        }

        public async Task<ResponseDto> SendAsync(RequestDto requestDto, bool withBearer = true) {
            try {
                HttpClient client = _httpClientFactory.CreateClient("MangoAPI");
                HttpRequestMessage message = new();
                message.Headers.Add("Accept", "application/json");
                if (withBearer) {
                    var token = _tokenProvider.GetToken();
                    message.Headers.Add("Authorization", $"Bearer {token}");
                }
                message.RequestUri = new Uri(requestDto.Url);
                if (requestDto.Data != null) {
                    message.Content = new StringContent(JsonConvert.SerializeObject(requestDto.Data), Encoding.UTF8, "application/json");
                }
                HttpResponseMessage? apiResponse = null;
                message.Method = requestDto.ApiType switch {
                    ApiType.POST => HttpMethod.Post,
                    ApiType.PUT => HttpMethod.Put,
                    ApiType.DELETE => HttpMethod.Delete,
                    _ => HttpMethod.Get,
                };
                apiResponse = await client.SendAsync(message);
                switch (apiResponse.StatusCode) {
                    case HttpStatusCode.NotFound:
                        return new() { IsSuccess = false, Message = "Not found" };
                    case HttpStatusCode.Forbidden:
                        return new() { IsSuccess = false, Message = "Access denied" };
                    case HttpStatusCode.Unauthorized:
                        return new() { IsSuccess = false, Message = "Unauthorized" };
                    case HttpStatusCode.InternalServerError:
                        return new() { IsSuccess = false, Message = "Server Error" };
                    default:
                        var apiContent = await apiResponse.Content.ReadAsStringAsync();
                        var apiResponseDto = JsonConvert.DeserializeObject<ResponseDto>(apiContent);
                        return apiResponseDto;
                }
            } catch (Exception ex) {
                var responseDto = new ResponseDto {
                    IsSuccess = false,
                    Message = ex.Message.ToString()
                };
                return responseDto;
            }
        }

    }

}