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

        public Producto()
        {
            InitializeComponent();

            LstProductos = new List<ClsProducto>();
            LstProductos.Add(new ClsProducto { Nombre = "Computador", NombreCategoria = "Aldedier", Precio= 4054, Stock= 41 });
            LstProductos.Add(new ClsProducto { Nombre = "Portatil", NombreCategoria = "Deicy", Precio= 2054, Stock= 43 });
            LstProductos.Add(new ClsProducto { Nombre = "Moto", NombreCategoria = "Aldedier", Precio= 12400, Stock= 89 });

            BindingContext = this;
        }
    }
}