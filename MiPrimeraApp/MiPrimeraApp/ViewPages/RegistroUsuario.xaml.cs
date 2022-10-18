using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MiPrimeraApp.ViewPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegistroUsuario : ContentPage
    {
        public RegistroUsuario()
        {
            InitializeComponent();
        }

        private async void btnRegresarLogin_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        private void btnRegistrarUsuario_Clicked(object sender, EventArgs e)
        {
            DisplayAlert("Valores", $"Nombres: {txtNombre.Text} / Apellidos: {txtApellidos.Text} / Identificación: {txtIdentificacion.Text} ", "Cancelar");
        }
    }
}