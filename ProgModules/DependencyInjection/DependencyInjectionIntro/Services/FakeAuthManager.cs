using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DependencyInjectionIntro.Interfaces;

namespace DependencyInjectionIntro.Services {
    internal class FakeAuthManager : IAuthManager {

        public bool TryLogin(string login, string password) {
            return true;
        }

        public bool IsLoginTaken(string login) {
            return false;
        }

        public bool Register(string login, string password) {
            return true;
        }
    }
}
