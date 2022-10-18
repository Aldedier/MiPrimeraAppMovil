using MiPrimeraApp.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MiPrimeraApp.ViewPages
{
    public partial class MainPage : ContentPage
    {
        public ClsUsuario ClsUsuario { get; set; }

        public MainPage()
        {
            InitializeComponent();
            ClsUsuario = new ClsUsuario();
            BindingContext = this;
        }

        private void BtnVerMas_Clicked(object sender, EventArgs e)
        {
            // 1. Ocultar Boton
            //BtnVerMas.IsVisible = false;

            // 2. Mostrar texto
            // LblTexto.LineBreakMode = LineBreakMode.WordWrap;

            //string texto = LblTexto.Text;
            //DisplayAlert("Alerta", texto, "Salir");
        }

        private async void Registrarse_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RegistroUsuario());
        }

        private async void Ingresar_Clicked(object sender, EventArgs e)
        {
            if (ClsUsuario.Usuario == "aldedier" && ClsUsuario.Contrasena == "1234")
                Application.Current.MainPage = new PaginaPrincipal();
            else
                await DisplayAlert("Error", "Usuario y contraseña no validos", "Aceptar");
        }

        private async void toolbarAgregar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RegistroUsuario());
        }
    }
}
