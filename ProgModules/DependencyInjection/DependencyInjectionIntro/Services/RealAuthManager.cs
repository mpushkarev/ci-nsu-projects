/******************************************************************************\
*                                                                              *
*  Author:     Mikhail Pushkarev (CI NSU)                                      *
*  Created:    Approx. February – June 2025                                    *
*                                                                              *
*  Description:                                                                *
*    Basic demonstration of dependency injection in a WinForms                 *
*    application, featuring a simple user authentication and                   *
*    registration system. The core logic is separated into service             *
*    interfaces and multiple implementations (including fake,                  *
*    list, and real authentication managers).                                  *
*    As one of my early projects using these patterns, some aspects            *
*    may be simplistic or suitable for further improvement.                    *
*                                                                              *
\******************************************************************************/

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
