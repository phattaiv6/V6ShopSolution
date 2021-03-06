using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using V6shopSolution.ViewModel.Common;
using V6shopSolution.ViewModel.System.Users;

namespace V6ShopSolution.Application.System.Users
{
   public interface IUserService
    {
        Task<ApiResult<string>> Authencate(LoginRequest request);


        Task<ApiResult<bool>> Register(RegisterRequest request);
        Task<ApiResult<PagedResult<UserVM>>> GetUsersPaging(GetUserPagingRequest request);
        Task<ApiResult<bool>> Update(Guid id, UserUpdateRequest request);// phương thức này lấy ra danh sách user và trả về model phân trang
        Task<ApiResult<UserVM>> GetById(Guid id);
        Task<ApiResult<bool>> Delete(Guid id);
    }
}
