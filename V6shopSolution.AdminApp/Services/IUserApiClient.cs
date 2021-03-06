using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using V6shopSolution.ViewModel.Common;
using V6shopSolution.ViewModel.System.Users;

namespace V6shopSolution.AdminApp.Services
{
  public  interface IUserApiClient
    {
        Task<ApiResult<string>> Authenticate(LoginRequest request);

        Task<ApiResult<PagedResult<UserVM>>> GetUsersPagings(GetUserPagingRequest request);

        Task<ApiResult<bool>> RegisterUser(RegisterRequest registerRequest);

        Task<ApiResult<bool>> UpdateUser(Guid id, UserUpdateRequest request);

        Task<ApiResult<UserVM>> GetById(Guid id);
        Task<ApiResult<bool>> Delete(Guid id);
    }
}
