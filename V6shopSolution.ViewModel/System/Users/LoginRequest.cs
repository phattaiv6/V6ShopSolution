using System;
using System.Collections.Generic;
using System.Text;

namespace V6shopSolution.ViewModel.System.Users
{
   public class LoginRequest
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}
