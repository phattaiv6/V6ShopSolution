using System;
using System.Collections.Generic;
using System.Text;
using V6shopSolution.ViewModel.Common;

namespace V6shopSolution.ViewModel.Catalog.Products
{
    public class GetPublicProductPagingRequest : PagingRequestBase
    {

        public int? CategoryId { get; set; } //int? để gán giá trị null
    }
}
