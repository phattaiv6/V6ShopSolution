using System;
using System.Collections.Generic;
using System.Text;
using V6shopSolution.ViewModel.Common;

namespace V6shopSolution.ViewModel.Catalog.Products
{
    public class GetManageProductPagingRequest : PagingRequestBase
    {
        public string KeyWord { set; get; } //keyword và categoryIds để tìm kiếm
        public List<int> CategoryIds { set; get; }
    }
}
