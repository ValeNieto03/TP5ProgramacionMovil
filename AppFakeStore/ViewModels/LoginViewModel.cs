using AppFakeStore.Models;
using AppFakeStore.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Threading.Tasks;

namespace AppFakeStore.ViewModels
{
    public partial class LoginViewModel : BaseViewModel
    {
        private readonly ILoginService _loginService;

        [ObservableProperty]
        private string username;

        [ObservableProperty]
        private string password;

        public LoginViewModel(ILoginService loginService)
        {
            _loginService = loginService;
        }

        [RelayCommand]
        private async Task LoginAsync()
        {
            if (string.IsNullOrEmpty(Username) || string.IsNullOrEmpty(Password))
            {
                await App.Current.MainPage.DisplayAlert("Error", "Username y/o password no pueden estar vac�os.", "Ok");
                return;
            }

            var response = await _loginService.LoginAsync(Username, Password);

            if (response != null)
            {
                // Guarda el token, redirige al usuario, etc.
                await App.Current.MainPage.DisplayAlert("�xito", "Inicio de sesi�n exitoso!", "Ok");
                // Por ejemplo, navega a la p�gina de inicio
                await App.Current.MainPage.Navigation.PushAsync(new MainPage(), true);
            }
            else
            {
                await App.Current.MainPage.DisplayAlert("Error", "Credenciales inv�lidas.", "Ok");
            }
        }
    }
}
