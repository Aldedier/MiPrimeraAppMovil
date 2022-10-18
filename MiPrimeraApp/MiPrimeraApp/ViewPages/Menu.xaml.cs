using MiPrimeraApp.Clases;
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
    public partial class Menu : ContentPage
    {
        public List<ClsMenu> LstMenu { get; set; }

        public Menu()
        {
            InitializeComponent();
            LstMenu = new List<ClsMenu>();
            LstMenu.Add(new ClsMenu { Nombre = "Categoria", Icono= "ic_Categoria" });
            LstMenu.Add(new ClsMenu { Nombre = "Producto", Icono= "ic_Producto" });
            LstMenu.Add(new ClsMenu { Nombre = "Cerrar Sesión", Icono= "ic_Cerrar_Sesion" });
            BindingContext = this;
        }

        private void lstMenu_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            ClsMenu clsMenu = (ClsMenu)e.SelectedItem;

            switch (clsMenu.Nombre)
            {
                case "Categoria":
                    App.Navegacion.PushAsync(new Categoria()); break;
                case "Producto":
                    App.Navegacion.PushAsync(new Producto()); break;
                case "Salir":
                    App.Current.MainPage = new MainPage(); break;
            }
            
            //DisplayAlert("Menu", clsMenu.Nombre, "Cancelar");
        }
    }
}