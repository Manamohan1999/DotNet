using BookTurf.Data.Models;
using BookTurf.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookTurf.Repository
{
    public class LoginRepository : GenericRepository<Login>, ILoginRepository
    {
        public LoginRepository(BookTurfContext context) : base(context)
        {
        }
        public Login GetById(string userName, string password)
        {
            var user = Context.Login
                              .Where(x => x.IsStatus == true && x.IsDeleted == false && x.UserName == userName && x.Password == password)
                              .FirstOrDefault();
            return user;
        }

        public Login GetByToken(string token)
        {
            var user = Context.Login.Where(e => e.Token == token).FirstOrDefault();
            return user;
        }

        public string GetPassword(string password)
        {
            var user = Context.Login.Where(x => x.Password == password);
            if (user != null)
                return "success";

            return "Failed";
        }

        public string GetUserName(string userName)
        {
            var user = Context.Login.Where(x => x.UserName == userName);
            if (user != null)
                return "success";

            return "Failed";
        }

        public bool UpdateForgotPasswordToken(string userName, string token)
        {
            var user = Context.Login.Where(e => e.UserName == userName).FirstOrDefault();
            if (user != null)
                user.Token = token;
            var state = Context.SaveChanges();
            if (state != 0)
                return true;
            else
                return false;
        }

        public bool UpdatePassword(string userName, string newPassword)
        {
            var user = Context.Login.Where(e => e.UserName == userName).FirstOrDefault();
            if (user != null)
                user.Password = newPassword;
            var state = Context.SaveChanges();
            if (state != 0)
                return true;
            else
                return false;
        }
    }
}
