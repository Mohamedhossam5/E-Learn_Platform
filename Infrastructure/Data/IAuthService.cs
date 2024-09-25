using System.ComponentModel.DataAnnotations;
using Infrastructure.Data;


namespace Infrastructure.Services.Auth;
    public interface IAuthService {
        Task<AuthModel> RegisterAsync(RegisterModel model);

        Task<AuthModel> GetTokenAsync(TokenRequestModel model);

        Task<string> AddRoleAsync(AddRoleModel model);
    }
