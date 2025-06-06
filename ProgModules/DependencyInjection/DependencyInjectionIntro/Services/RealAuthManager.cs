using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DependencyInjectionIntro.Data;
using DependencyInjectionIntro.Interfaces;

namespace DependencyInjectionIntro.Services {
    internal class RealAuthManager : IAuthManager {

        private readonly AppDbContext _appDbContext;

        public RealAuthManager(AppDbContext appDbContext) {
            _appDbContext = appDbContext;
        }

        public bool TryLogin(string login, string password) {
            return _appDbContext.Users.Any(u => u.Login == login && u.Password == password);
        }

        public bool IsLoginTaken(string login) {
            return _appDbContext.Users.Any(u => u.Login == login);
        }

        public bool Register(string login, string password) {

            if (IsLoginTaken(login))
                return false;

            _appDbContext.Users.Add(new User { Login = login, Password = password });
            _appDbContext.SaveChanges();

            return true;
        }
    }
}
