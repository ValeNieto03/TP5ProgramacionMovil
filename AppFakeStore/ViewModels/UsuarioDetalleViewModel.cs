using AppFakeStore.Models;
using AppFakeStore.Services;
using AppFakeStore.Utils;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace AppFakeStore.ViewModels;

public partial class UsuarioDetalleViewModel : BaseViewModel
{
    [ObservableProperty]
    Usuario user = new Usuario();

    [ObservableProperty]
    int id;
    IUsuarioService _usuarioService;
    public UsuarioDetalleViewModel()
    {
        Title = "Detalle de Usuario";
        _usuarioService = new UsuarioService();
    }

    [RelayCommand]
    public async Task UsuarioIdAsync()
    {
        if (!IsBusy)
        {
            IsBusy = true;
            try
            {
                user = await _usuarioService.GetUsuarioIdAsync(id);
                OnPropertyChanged(nameof(User));
                if(user == null)
                {
                    await Application.Current.MainPage.DisplayAlert("Alerta", "No existe un Usuario con ese ID", "OK");
                }
            }
            catch (Exception)
            {
                await Application.Current.MainPage.DisplayAlert("Alerta", "No se puede mostrar la informacion", "OK");
                throw;
            }
            finally { IsBusy = false; }
        }
    }

    [RelayCommand]
    private async Task GoBack()
    {
        await Application.Current.MainPage.Navigation.PopAsync();
    }

    
}
