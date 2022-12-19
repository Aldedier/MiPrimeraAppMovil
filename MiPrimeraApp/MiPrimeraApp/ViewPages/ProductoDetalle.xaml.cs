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
    public partial class ProductoDetalle : ContentPage
    {
        public string Titulo { get; set; }
        public ClsProducto oClsProducto { get; set; }
        public List<string> ListaCategoria { get; set; }
        public ProductoDetalle(ClsProducto clsProducto, string _nombreTitulo)
        {
            InitializeComponent();
            ListaCategoria = new List<string>();
            ListaCategoria.Add("Aldedier");
            ListaCategoria.Add("Deicy");
            ListaCategoria.Add("Hedy");
            Titulo = _nombreTitulo;
            oClsProducto = clsProducto;

            //oClsProducto = new ClsProducto();
            //oClsProducto.Nombre = "Galleta";

            BindingContext = this;
        }

        private void btnGuardarProducto_Clicked(object sender, EventArgs e)
        {
            Producto obj = Producto.GetInstance();
            List<ClsProducto> lista = obj.ClsEntity.LstProductos.ToList();

            if (Titulo == "Agregar Producto")
            {
                lista.Add(oClsProducto);
            }
            else
            {
                int indice = lista.FindIndex(x => x.IdProducto == oClsProducto.IdProducto);
                lista[indice] = oClsProducto;
            }

            obj.ClsEntity.LstProductos = lista;
            Navigation.PopAsync();
        }

        private void btnRegresarProducto_Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }
    }
}