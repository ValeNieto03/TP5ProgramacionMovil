using AppFakeStore.ViewModels;
using AppFakeStore.Services;

namespace AppFakeStore.Views
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            BindingContext = new LoginViewModel(new LoginService());
        }
    }
}
