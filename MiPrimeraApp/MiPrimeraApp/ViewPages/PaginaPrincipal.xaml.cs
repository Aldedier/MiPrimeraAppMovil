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
    public partial class PaginaPrincipal : MasterDetailPage
    {
        public PaginaPrincipal()
        {
            InitializeComponent();
            App.Navegacion = Navegacion;
            App.MenuApp = this;
        }
    }
}