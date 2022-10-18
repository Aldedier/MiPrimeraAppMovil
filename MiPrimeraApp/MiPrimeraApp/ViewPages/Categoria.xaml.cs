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
        public List<ClsCategoria> LstCategorias { get; set; }

        public Categoria()
        {
            InitializeComponent();
            LstCategorias = new List<ClsCategoria>();
            LstCategorias.Add(new ClsCategoria { Id = 1, Nombre = "Aldedier", Descripcion = "Desarrollador" });
            LstCategorias.Add(new ClsCategoria { Id = 2, Nombre = "Deicy", Descripcion = "Comunicadora social" });
            LstCategorias.Add(new ClsCategoria { Id = 3, Nombre = "Hedy", Descripcion = "Hogar" });
            BindingContext = this;
        }

        private void lstCategoria_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            ClsCategoria clsCategoria = (ClsCategoria)e.SelectedItem;
            Navigation.PushAsync(new CategoriaDetalle(clsCategoria));
        }

        private void toolbarAgregar_Clicked(object sender, EventArgs e)
        {

        }
    }
}