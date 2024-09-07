using AppFakeStore.Services;
using AppFakeStore.ViewModels;
using Microsoft.Maui.Controls;

namespace AppFakeStore.Views
{
    public partial class UsuarioListaPage : ContentPage
    {
        public UsuarioListaPage()
        {
            UsuarioService service = new UsuarioService();
            UsuarioListaViewModel vm = new UsuarioListaViewModel(service);
            InitializeComponent(); // Asegúrate de que esto esté presente y correcto
            this.BindingContext = vm;
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            var vm = BindingContext as UsuarioListaViewModel;

            if (vm != null)
            {
                await vm.GetUserCommand.ExecuteAsync(null);
            }
        }
    }
}
