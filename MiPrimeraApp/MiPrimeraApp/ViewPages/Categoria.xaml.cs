using Android.Webkit;
using MiPrimeraApp.Clases;
using MiPrimeraApp.Generic;
using MiPrimeraApp.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MiPrimeraApp.ViewPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Categoria : ContentPage
    {
        public static Categoria instance { get; set; }

        public CategoriaModel categoriaModel { get; set; }

        public List<ClsCategoria> LstCategorias { get; set; }

        public static Categoria GetInstance()
        {
            if (instance == null)
            {
                return new Categoria();
            }
            else
            {
                return instance;
            }
        }

        public Categoria()
        {
            instance = this;
            InitializeComponent();
            categoriaModel = new CategoriaModel();
  
            //ClsEntity.LstCategorias = new List<ClsCategoria>();
            //ClsEntity.LstCategorias.Add(new ClsCategoria { Id = 1, Nombre = "Aldedier", Descripcion = "Desarrollador" });
            //ClsEntity.LstCategorias.Add(new ClsCategoria { Id = 2, Nombre = "Deicy", Descripcion = "Comunicadora social" });
            //ClsEntity.LstCategorias.Add(new ClsCategoria { Id = 3, Nombre = "Hedy", Descripcion = "Hogar" });
            //LstCategorias = ClsEntity.LstCategorias;

            BindingContext = this;
            ListarCategorias();
            lstCategoria.RefreshCommand = new Command(() =>
            {
                ListarCategorias();
            });
        }

        private void lstCategoria_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            ClsCategoria clsCategoria = (ClsCategoria)e.SelectedItem;
            Navigation.PushAsync(new CategoriaDetalle(clsCategoria, "Editar Categoría"));
        }

        private void toolbarAgregar_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new CategoriaDetalle(new ClsCategoria(), "Crear Categoría"));
        }

        private async void menuEliminar_Clicked(object sender, EventArgs e)
        {
            MenuItem oMenuItem = sender as MenuItem;
            ClsCategoria clsCategoria = (ClsCategoria)oMenuItem.BindingContext;

            var respuesta = await ServiciosGenericos.Delete("http://aldedier-001-site1.dtempurl.com/api/categoria/delete", clsCategoria.Id);

            if (respuesta == 0)
                await DisplayAlert("Error", "No se pudo eliminar", "Cancelar");
            else
            {
                ListarCategorias();
                await DisplayAlert("Exito", "Se eliminó correctamente", "Aceptar");
            }

            //ClsEntity.LstCategorias.Remove(clsCategoria);
            //ClsEntity.LstCategorias = ClsEntity.LstCategorias.ToList();
            //DisplayAlert("Aviso", clsCategoria.Nombre, "Aceptar");
        }

        private void buscarCategoria_TextChanged(object sender, TextChangedEventArgs e)
        {
            string valor = e.NewTextValue;
            categoriaModel.LstCategorias = LstCategorias.Where(X => X.Nombre.ToLower().Contains(valor.ToLower())).ToList();
            //DisplayAlert("Aviso", valor, "Aceptar");
        }

        public async void ListarCategorias()
        {
            categoriaModel.IsLoading = true;
            categoriaModel.LstCategorias = await ServiciosGenericos.GetAll<ClsCategoria>("http://aldedier-001-site1.dtempurl.com/api/categoria/get");
            categoriaModel.IsLoading = false;
            LstCategorias = categoriaModel.LstCategorias;
        }
    }
}