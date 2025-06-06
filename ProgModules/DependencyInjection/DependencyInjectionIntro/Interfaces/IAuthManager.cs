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

namespace DependencyInjectionIntro.Interfaces {
    public interface IAuthManager {
        /// <summary>
        /// Выполняет вход пользователя.
        /// </summary>
        /// <param name="login">Логин пользователя.</param>
        /// <param name="password">Пароль пользователя.</param>
        /// <returns>Истина, если вход выполнен успешно; иначе ложь.</returns>
        bool TryLogin(string login, string password);

        /// <summary>
        /// Проверяет, занят ли указанный логин.
        /// </summary>
        /// <param name="login">Логин для проверки.</param>
        /// <returns>Истина, если логин уже занят; иначе ложь.</returns>
        bool IsLoginTaken(string login);

        /// <summary>
        /// Выполняет регистрацию нового пользователя.
        /// </summary>
        /// <param name="login">Логин нового пользователя.</param>
        /// <param name="password">Пароль нового пользователя.</param>
        /// <returns>Истина, если регистрация выполнена успешно; иначе ложь.</returns>
        bool Register(string login, string password);
    }
}
