using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DependencyInjectionIntro.Interfaces;
using Microsoft.VisualBasic.ApplicationServices;
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
