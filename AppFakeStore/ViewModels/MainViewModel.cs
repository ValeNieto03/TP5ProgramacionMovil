using AppFakeStore.Views;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Maui.Controls; // Asegúrate de que esta referencia esté incluida

namespace AppFakeStore.ViewModels
{
    public partial class MainViewModel : BaseViewModel
    {
        public MainViewModel()
        {
            Title = "TP5 Programacion Movil";
        }

        [RelayCommand]
        public async Task GoToProductoLista()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new ProductoListaPage());
        }

        [RelayCommand]
        public async Task GoToUsuarioId()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new ProductoListaPage());
        }

        [RelayCommand]
        public async Task GoToUsuarioLista()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new UsuarioListaPage());
        }

        [RelayCommand]
        public async Task GoToAcerca()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new AcercaPage());
        }

        [RelayCommand]
        public async Task Exit()
        {
            // Muestra una alerta para confirmar que el usuario desea salir
            var result = await Application.Current.MainPage.DisplayAlert("Salir", "¿Desea terminar la sesión y salir?", "Aceptar", "Cancelar");

            if (result) // Si el usuario acepta
            {
                // Navega a la página de inicio de sesión
                await Application.Current.MainPage.Navigation.PushAsync(new LoginPage(), true);

                // Opcional: Limpiar el estado de la sesión
                // Por ejemplo, puedes eliminar tokens de autenticación o limpiar datos de usuario
            }
        }
    }
}
