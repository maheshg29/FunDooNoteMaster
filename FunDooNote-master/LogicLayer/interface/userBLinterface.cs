using CommonLayer.model;
using RepositotryLayer.entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LogicLayer.Interface
{
    public interface UserBlinterface
    {
        public userentity UserRegestration(UserRegitrationModel userRegestartion);
        public string UserLogin(UserLoginModel userLoginModel);

        public string ForgetPassword(string email);
        public bool ResetPassword(string email, string Password, string ConfirmPassword);

        /////////////////
        public IEnumerable<UserDetailsModel> UserDetails();

    }
}
