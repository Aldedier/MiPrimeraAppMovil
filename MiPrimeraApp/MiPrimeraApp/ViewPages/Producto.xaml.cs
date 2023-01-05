using MiPrimeraApp.Clases;
using MiPrimeraApp.Generic;
using MiPrimeraApp.Model;
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
    public partial class Producto : ContentPage
    {
        public static Producto Instance { get; set; }

        public static Producto GetInstance()
        {
            if (Instance == null)
                return new Producto();
            return Instance;
        }

        public List<ClsProducto> LstProductos { get; set; }
        public ProductoModel productoModel { get; set; }
        public string NombreProducto { get; set; }

        public Producto()
        {
            Instance = this;
            InitializeComponent();
            productoModel = new ProductoModel();
            //productoModel.LstProductos = new List<ClsProducto>();
            //productoModel.LstProductos.Add(new ClsProducto { IdProducto = 1, Nombre = "Computador", NombreCategoria = "Aldedier", Precio = 4054, Stock = 41 });
            //productoModel.LstProductos.Add(new ClsProducto { IdProducto = 2, Nombre = "Portatil", NombreCategoria = "Deicy", Precio = 2054, Stock = 43 });
            //productoModel.LstProductos.Add(new ClsProducto { IdProducto = 3, Nombre = "Moto", NombreCategoria = "Aldedier", Precio = 12400, Stock = 89 });
            ListarProductos();
            BindingContext = this;
        }

        public async void ListarProductos()
        {
            productoModel.LstProductos = await ServiciosGenericos.GetAll<ClsProducto>("http://aldedier-001-site1.dtempurl.com/api/producto/get");
            LstProductos = productoModel.LstProductos;
        }

        private void buscarProducto_SearchButtonPressed(object sender, EventArgs e)
        {
            SearchBar obj = sender as SearchBar;
            string texto = obj.Text;
            productoModel.LstProductos = LstProductos.Where(x => x.Nombre.Contains(texto)).ToList();

            // DisplayAlert("Aviso", texto, "Cancelar");
        }

        private void toolbarAgregarProducto_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ProductoDetalle(new ClsProducto(), "Agregar Producto"));
        }

        private void ListaProductos_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            ClsProducto clsProducto = (ClsProducto)e.SelectedItem;
            Navigation.PushAsync(new ProductoDetalle(clsProducto, "Editar Producto"));
        }

        private async void menuEliminar_Clicked(object sender, EventArgs e)
        {
            MenuItem oMenuItem = sender as MenuItem;
            ClsProducto clsProducto = (ClsProducto)oMenuItem.BindingContext;

            var respuesta = await ServiciosGenericos.Delete("http://aldedier-001-site1.dtempurl.com/api/producto/delete", clsProducto.IdProducto);

            if (respuesta == 0)
                await DisplayAlert("Error", "No se pudo eliminar", "Cancelar");
            else
            {
                ListarProductos();
                await DisplayAlert("Exito", "Se eliminó correctamente", "Aceptar");
            }

        }
    }
}