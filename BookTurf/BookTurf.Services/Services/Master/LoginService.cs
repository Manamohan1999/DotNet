using BookTurf.Data.Models;
using BookTurf.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using BookTurf.Repository.Interfaces;

namespace BookTurf.Services
{
    public class LoginService : EntityService<Login>, ILoginService
    {
        private readonly ILoginRepository _loginRepository;
        public LoginService(IUnitOfWork unitOfWork, ILoginRepository repository) :
            base(unitOfWork, repository)
        {
            UnitOfWork = unitOfWork;
            _loginRepository = repository;
        }
        public Login GetById(string userName, string password)
        {
            return _loginRepository.GetById(userName, password);
        }

        public Login GetByToken(string token)
        {
            return _loginRepository.GetByToken(token);
        }

        public string GetPassword(string password)
        {
            return _loginRepository.GetPassword(password);
        }

        public string GetUsername(string userName)
        {
            return _loginRepository.GetUserName(userName);
        }

        public bool UpdateForgotPasswordToken(string userName, string token)
        {
            return _loginRepository.UpdateForgotPasswordToken(userName, token);
        }

        public bool UpdatePassword(string userName, string newPassword)
        {
            return _loginRepository.UpdatePassword(userName, newPassword);
        }
    }
}
