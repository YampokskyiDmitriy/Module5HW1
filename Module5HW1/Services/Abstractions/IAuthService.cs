using Module5HW1.Models;
using Module5HW1.Models.Response;

namespace Module5HW1.Services.Abstractions
{
    public interface IAuthService
    {
        Task<AuthToken?> PostLoginSuccessfulAsync();
        Task<NotFoundResponse?> PostLoginUnsuccessfulAsync();
        Task<AuthToken?> PostRegisterSuccessfulAsync();
        Task<ErrorResponse?> PostRegisterUnsuccessfulAsync();
    }
}