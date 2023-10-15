using Mango.Web.Models;

namespace Mango.Web.Service.IService
{
    public interface IBaseService
    {                                                      // For having access in front to Apis
        Task<ResponseDto?> SendAsync(RequestDto requestDto, bool withBearer = true);
    }
}
