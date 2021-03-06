using System;
using System.Collections.Generic;
using System.Text;
using V6shopSolution.ViewModel.Common;

namespace V6shopSolution.ViewModel.System.Users
{
   public  class GetUserPagingRequest : PagingRequestBase
    {
        public string KeyWord { get; set; }
    }
}
