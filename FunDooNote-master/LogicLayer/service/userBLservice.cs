using CommonLayer.model;
using LogicLayer.Interface;
using RepositotryLayer.entity;
using RepositotryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LogicLayer.service
{

    public class UserBlservice : UserBlinterface
    {
        private readonly iUserRlinterface iUserRlinterface;


        public UserBlservice(iUserRlinterface iUserRlinterface)
        {
            this.iUserRlinterface = iUserRlinterface;
        }

        public userentity UserRegestration(UserRegitrationModel userRegestartion)
        {
            try
            {
                return iUserRlinterface.UserRegestration(userRegestartion);
            }
            catch (Exception B)
            {
                throw B;
            }
        }

        public string UserLogin(UserLoginModel userLoginModel)
        {
            try
            {
                return iUserRlinterface.UserLogin(userLoginModel);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public string ForgetPassword(string email)
        {
            try
            {
                return iUserRlinterface.ForgetPassword(email);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool ResetPassword(string email, string Password, string ConfirmPassword)
        {
            try
            {
                return iUserRlinterface.ResetPassword(email, Password, ConfirmPassword);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<UserDetailsModel> UserDetails()
        {
            try
            {
                return iUserRlinterface.UserDetails();
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}

