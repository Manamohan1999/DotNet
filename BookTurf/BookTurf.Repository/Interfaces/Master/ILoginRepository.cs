using BookTurf.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookTurf.Repository.Interfaces
{
    public interface ILoginRepository : IGenericRepository<Login>
    {
        Login GetById(string userName, string password);
        string GetUserName(string userName);
        string GetPassword(string password);
        bool UpdateForgotPasswordToken(string userName, string token);
        Login GetByToken(string token);
        bool UpdatePassword(string userName, string newPassword);
        
    }
}
