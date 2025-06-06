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

using DependencyInjectionIntro.Interfaces;
using MyUser = DependencyInjectionIntro.Data.User;

namespace DependencyInjectionIntro.Services {
    internal class ListAuthManager : IAuthManager {

        private readonly List<MyUser> users = new List<MyUser>();

        public ListAuthManager() {
            users.Add(new MyUser { Login = "admin", Password = "admin" });
        }

        public bool TryLogin(string login, string password) {
            return users.Any(u => u.Login == login && u.Password == password);
        }

        public bool IsLoginTaken(string login) {
            return users.Any(u => u.Login == login);
        }

        public bool Register(string login, string password) {

            if (IsLoginTaken(login))
                return false;

            users.Add(new MyUser { Login = login, Password = password });

            return true;
        }
    }
}
