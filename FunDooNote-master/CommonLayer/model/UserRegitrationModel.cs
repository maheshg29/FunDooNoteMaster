using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLayer.model
{
    public class UserRegitrationModel
    {
       
        
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Email { get; set; }
            public string Password { get; set; }
        
    }

    public class UserLoginModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
