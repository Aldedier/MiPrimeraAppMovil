using MiPrimeraApp.Clases;
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

        private void btnGuardar_Clicked(object sender, EventArgs e)
        {
            Categoria obj = Categoria.GetInstance();
            List<ClsCategoria> lista = obj.ClsEntity.LstCategorias.ToList();

            if (Titulo == "Crear Categoría")
            {
                lista.Add(ClsCategoria);
            }
            else
            {
                int indice = lista.FindIndex(x => x.Id == ClsCategoria.Id);
                lista[indice].Descripcion = ClsCategoria.Descripcion;
                lista[indice].Nombre = ClsCategoria.Nombre;
            }
            
            obj.ClsEntity.LstCategorias = lista;
            Navigation.PopAsync();
        }

        private void btnRegresar_Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }
    }
}