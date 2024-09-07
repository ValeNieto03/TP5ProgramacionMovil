using AppFakeStore.Models;
using AppFakeStore.ViewModels;

namespace AppFakeStore.Views;

public partial class UsuarioDetallePage : ContentPage
{
    public UsuarioDetallePage(Usuario param)
    {
        InitializeComponent(); // Esto debe existir en el archivo XAML correspondiente
        UsuarioDetalleViewModel vm = new UsuarioDetalleViewModel();
        this.BindingContext = vm;
        vm.User = param;
    }
}