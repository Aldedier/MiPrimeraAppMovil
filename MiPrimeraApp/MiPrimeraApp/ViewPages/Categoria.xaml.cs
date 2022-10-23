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
    public partial class Categoria : ContentPage
    {
        public static Categoria instance { get; set; }

        public ClsEntity ClsEntity { get; set; }

        public List<ClsCategoria> LstCategorias { get; set; }

        public static Categoria GetInstance()
        {
            if(instance == null)
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
            ClsEntity = new ClsEntity();
            ClsEntity.LstCategorias = new List<ClsCategoria>();
            ClsEntity.LstCategorias.Add(new ClsCategoria { Id = 1, Nombre = "Aldedier", Descripcion = "Desarrollador" });
            ClsEntity.LstCategorias.Add(new ClsCategoria { Id = 2, Nombre = "Deicy", Descripcion = "Comunicadora social" });
            ClsEntity.LstCategorias.Add(new ClsCategoria { Id = 3, Nombre = "Hedy", Descripcion = "Hogar" });
            LstCategorias = ClsEntity.LstCategorias;
            BindingContext = this;
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

        private void menuEliminar_Clicked(object sender, EventArgs e)
        {
            MenuItem oMenuItem = sender as MenuItem;
            ClsCategoria clsCategoria = (ClsCategoria)oMenuItem.BindingContext;
            ClsEntity.LstCategorias.Remove(clsCategoria);
            ClsEntity.LstCategorias = ClsEntity.LstCategorias.ToList();
            //DisplayAlert("Aviso", clsCategoria.Nombre, "Aceptar");
        }

        private void buscarCategoria_TextChanged(object sender, TextChangedEventArgs e)
        {
            string valor = e.NewTextValue;
            ClsEntity.LstCategorias = LstCategorias.Where(X => X.Nombre.Contains(valor)).ToList();
            //DisplayAlert("Aviso", valor, "Aceptar");
        }

       
    }
}