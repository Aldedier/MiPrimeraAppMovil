using MiPrimeraApp.Clases;
using MiPrimeraApp.Generic;
using MiPrimeraApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MiPrimeraApp.ViewPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProductoCategoriaConsulta : ContentPage
    {
        public ProductoCategoriaConsultaModel productoCategoriaConsultaModel { get; set; }
        private List<ClsCategoria> LstCategorias;
        private List<ClsProducto> LstProductos;
        public ProductoCategoriaConsulta()
        {
            InitializeComponent();
            productoCategoriaConsultaModel = new ProductoCategoriaConsultaModel();
            BindingContext = this;
            ListarDatos();
        }

        private async void ListarDatos()
        {
            LstCategorias = await ServiciosGenericos.GetAll<ClsCategoria>("http://aldedier-001-site1.dtempurl.com/api/categoria");
            productoCategoriaConsultaModel.LstCategorias = LstCategorias.Select(p => p.Nombre).ToList();
            LstProductos = await ServiciosGenericos.GetAll<ClsProducto>("http://aldedier-001-site1.dtempurl.com/api/producto/get");
            productoCategoriaConsultaModel.LstProductos = LstProductos;
        }

        private void pickerCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Picker p = sender as Picker;
            //string item = p.SelectedItem.ToString();
            //DisplayAlert("Valor", item, "Cancelar");

            string itemSeleccionado = productoCategoriaConsultaModel.nombreCategoria;
            productoCategoriaConsultaModel.LstProductos = LstProductos.Where(x => x.NombreCategoria == itemSeleccionado).ToList();
        }

        private void ListaProductos_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

        }

        private void menuEliminar_Clicked(object sender, EventArgs e)
        {

        }
    }
}