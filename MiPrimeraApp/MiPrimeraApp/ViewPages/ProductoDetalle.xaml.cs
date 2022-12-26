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
    public partial class ProductoDetalle : ContentPage
    {
        private List<ClsCategoria> ListaCategorias; 
        private List<ClsMarca> ListaMarcas;
        public string Titulo { get; set; }
        //public ClsProducto oClsProducto { get; set; }
        private ClsProducto oClsProducto { get; set; }
        public ProductoModel productoModel { get; set; }

        //public List<string> ListaCategoria { get; set; }
        public ProductoDetalle(ClsProducto clsProducto, string _nombreTitulo)
        {
            InitializeComponent();
            productoModel = new ProductoModel();
            productoModel.LstCategorias = new List<string>();
            productoModel.LstMarcas = new List<string>();
            //ListaCategoria.Add("Aldedier");
            //ListaCategoria.Add("Deicy");
            //ListaCategoria.Add("Hedy");
            Titulo = _nombreTitulo;
            productoModel.ClsProducto = new ClsProducto();
            oClsProducto = clsProducto;
            //oClsProducto = new ClsProducto();
            //oClsProducto.Nombre = "Galleta";

            BindingContext = this;
            ListarCombos();
        }

        public async void ListarCombos()
        {
            ClsCategoriaMarca clsCategoriaMarca = await GenericList.Get<ClsCategoriaMarca>("http://aldedier-001-site1.dtempurl.com/api/categoriamarca/get");
            ListaCategorias = clsCategoriaMarca.ListaCategoria;
            ListaMarcas = clsCategoriaMarca.ListaMarca;
            productoModel.LstCategorias = ListaCategorias.Select(x => x.Nombre).ToList();
            productoModel.LstMarcas = ListaMarcas.Select(x => x.Nombre).ToList();
            productoModel.ClsProducto = oClsProducto;
        }

        private void btnGuardarProducto_Clicked(object sender, EventArgs e)
        {
            Producto obj = Producto.GetInstance();
            List<ClsProducto> lista = obj.productoModel.LstProductos.ToList();

            if (Titulo == "Agregar Producto")
            {
                lista.Add(productoModel.ClsProducto);
            }
            else
            {
                int indice = lista.FindIndex(x => x.IdProducto == productoModel.ClsProducto.IdProducto);
                lista[indice] = productoModel.ClsProducto;
            }

            obj.productoModel.LstProductos = lista;
            Navigation.PopAsync();
        }

        private void btnRegresarProducto_Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }
    }
}