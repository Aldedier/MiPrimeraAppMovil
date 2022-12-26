using MiPrimeraApp.Clases;
using MiPrimeraApp.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MiPrimeraApp.ViewPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CategoriaDetalle : ContentPage
    {
        public ClsCategoria ClsCategoria { get; set; } = new ClsCategoria();
        public string Titulo { get; set; }
        public CategoriaDetalle(ClsCategoria _clsCategoria, string _titulo)
        {
            InitializeComponent();
            ClsCategoria = _clsCategoria;
            BindingContext = this;
            Titulo = _titulo;
        }

        private async void btnGuardar_Clicked(object sender, EventArgs e)
        {
            Categoria obj = Categoria.GetInstance();
            List<ClsCategoria> lista = obj.categoriaModel.LstCategorias.ToList();

            bool respuesta = await GenericList.Post<ClsCategoria>("http://aldedier-001-site1.dtempurl.com/api/categoria/post", ClsCategoria);

            if (respuesta)
            {
                await DisplayAlert("Exito", "Se creó correctamente", "Aceptar");
                obj.ListarCategorias();
            }
            else
                await DisplayAlert("Error", "No se pudo crear", "Cancelar");

            //if (Titulo == "Crear Categoría")
            //{
            //    lista.Add(ClsCategoria);
            //}
            //else
            //{
            //    int indice = lista.FindIndex(x => x.Id == ClsCategoria.Id);
            //    lista[indice] = ClsCategoria;
            //}

            //obj.ClsEntity.LstCategorias = lista;
            await Navigation.PopAsync();
        }

        private void btnRegresar_Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }
    }
}