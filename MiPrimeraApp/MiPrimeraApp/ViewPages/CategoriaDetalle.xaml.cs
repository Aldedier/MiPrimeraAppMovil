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
    public partial class CategoriaDetalle : ContentPage
    {
        public ClsCategoria ClsCategoria { get; set; } = new ClsCategoria();
        public CategoriaDetalle(ClsCategoria _clsCategoria)
        {
            InitializeComponent();
            ClsCategoria = _clsCategoria;
            BindingContext = this;
        }
    }
}