using System;

namespace ToDoApp
{
    public class AuthService
    {
        private readonly JwtService _jwtService;

        public AuthService(JwtService jwtService)
        {
            _jwtService = jwtService;
        }

        public string Authenticate(string username, string password)
        {
            // Kullanıcı kimlik doğrulamasını gerçekleştir
            var user = GetUserByUsernameAndPassword(username, password);

            // Kullanıcı kimlik doğrulaması başarılı ise JWT oluştur
            if (user != null)
            {
                return _jwtService.GenerateToken(user);
            }

            return null; // Kullanıcı kimlik doğrulaması başarısız ise null döndür
        }

        private User GetUserByUsernameAndPassword(string username, string password)
        {
            // Kullanıcıyı veritabanından al veya başka bir yerden doğrula
            // Örnek amaçlı, şifreyi kontrol etmeye gerek yok, gerçek uygulamada şifreleme ve doğrulama yapılmalıdır
            if (username == "example" && password == "password")
            {
                return new User { Id = Guid.NewGuid(), UserName = username };
            }

            return null;
        }
    }
}