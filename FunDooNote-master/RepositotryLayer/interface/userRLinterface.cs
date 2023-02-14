using CommonLayer.model;
using RepositotryLayer.entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RepositotryLayer.Interface
{
    public interface iUserRlinterface
    {
        public userentity UserRegestration(UserRegitrationModel userRegestartion);
        //Login//
        public string UserLogin(UserLoginModel userLoginModel);
        //Login//
        
        public string ForgetPassword(string email);

        public bool ResetPassword(string email, string Password, string ConfirmPassword);

        /////////////
        public IEnumerable<UserDetailsModel> UserDetails();

    }
}
