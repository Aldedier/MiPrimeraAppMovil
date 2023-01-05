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
            productoModel.IsLoadingForm = true;
            ClsCategoriaMarca clsCategoriaMarca = await ServiciosGenericos.Get<ClsCategoriaMarca>("http://aldedier-001-site1.dtempurl.com/api/categoriamarca/get");
            productoModel.IsLoadingForm = false;
            ListaCategorias = clsCategoriaMarca.ListaCategoria;
            ListaMarcas = clsCategoriaMarca.ListaMarca;
            productoModel.LstCategorias = ListaCategorias.Select(x => x.Nombre).ToList();
            productoModel.LstMarcas = ListaMarcas.Select(x => x.Nombre).ToList();
            productoModel.ClsProducto = oClsProducto;
        }

        private async void btnGuardarProducto_Clicked(object sender, EventArgs e)
        {
            Producto obj = Producto.GetInstance();
            List<ClsProducto> lista = obj.productoModel.LstProductos.ToList();

            productoModel.ClsProducto.IdCategoria = ListaCategorias
                .Where(x => x.Nombre == productoModel.ClsProducto.NombreCategoria).First().Id;

            productoModel.ClsProducto.IdMarca = ListaMarcas
                .Where(x => x.Nombre == productoModel.ClsProducto.NombreMarca).First().Iidmarca;

            productoModel.IsLoadingForm = true;

            bool respuesta = await ServiciosGenericos.Post("http://aldedier-001-site1.dtempurl.com/api/producto/post", productoModel.ClsProducto);

            productoModel.IsLoadingForm = false;

            if (respuesta)
            {
                await DisplayAlert("Exito", "Se creó correctamente", "Aceptar");
                obj.ListarProductos();
            }
            else
                await DisplayAlert("Error", "No se pudo crear", "Cancelar");

            //if (Titulo == "Agregar Producto")
            //{
            //    lista.Add(productoModel.ClsProducto);
            //}
            //else
            //{
            //    int indice = lista.FindIndex(x => x.IdProducto == productoModel.ClsProducto.IdProducto);
            //    lista[indice] = productoModel.ClsProducto;
            //}

            //obj.productoModel.LstProductos = lista;


            Navigation.PopAsync();
        }

        private void btnRegresarProducto_Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }
    }
}