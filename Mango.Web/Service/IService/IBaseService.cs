namespace Mango.Web {

    public interface IBaseService {

        Task<ResponseDto?> SendAsync(RequestDto requestDto, bool withBearer = true);

    }

}