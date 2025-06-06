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
