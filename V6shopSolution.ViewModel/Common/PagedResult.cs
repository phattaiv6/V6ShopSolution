using System;
using System.Collections.Generic;
using System.Text;
using V6shopSolution.ViewModel.Catalog.Products;
using V6shopSolution.ViewModel.System.Users;

namespace V6shopSolution.ViewModel.Common
{
    public class PagedResult<T> : PagedResultBase
    {
        
            public List<T> Items { set; get; }
           
        


    }
}
