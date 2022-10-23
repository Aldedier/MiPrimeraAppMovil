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
    public partial class Producto : ContentPage
    {
        public List<ClsProducto> LstProductos { get; set; }
        public ClsEntity ClsEntity { get; set; }
        public string NombreProducto { get; set; }

        public Producto()
        {
            InitializeComponent();
            ClsEntity = new ClsEntity();
            ClsEntity.LstProductos = new List<ClsProducto>();
            ClsEntity.LstProductos.Add(new ClsProducto { Nombre = "Computador", NombreCategoria = "Aldedier", Precio = 4054, Stock = 41 });
            ClsEntity.LstProductos.Add(new ClsProducto { Nombre = "Portatil", NombreCategoria = "Deicy", Precio = 2054, Stock = 43 });
            ClsEntity.LstProductos.Add(new ClsProducto { Nombre = "Moto", NombreCategoria = "Aldedier", Precio = 12400, Stock = 89 });
            LstProductos = ClsEntity.LstProductos;
            BindingContext = this;
        }

        private void buscarProducto_SearchButtonPressed(object sender, EventArgs e)
        {
            SearchBar obj = sender as SearchBar;
            string texto = obj.Text;
            ClsEntity.LstProductos = LstProductos.Where(x => x.Nombre.Contains(texto)).ToList();

            // DisplayAlert("Aviso", texto, "Cancelar");
        }
    }
}