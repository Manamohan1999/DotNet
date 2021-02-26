using BookTurf.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookTurf.Services.Interfaces
{
    public interface ILoginService : IEntityService<Login>
    {
        Login GetById(string userName, string password);
        string GetPassword(string password);
        string GetUsername(string userName);
        bool UpdateForgotPasswordToken(string userName, string token);
        Login GetByToken(string token);
        bool UpdatePassword(string userName, string newPassword);
    }
}
