namespace AppFakeStore.Models
{
    public class LoginRequest
    {
        public string username { get; set; }
        public string password { get; set; }
    }

    public class LoginResponse
    {
        public string Token { get; set; } // Si usas tokens de autenticaci�n
        public Usuario Usuario { get; set; } // Informaci�n del usuario logueado
    }
}
