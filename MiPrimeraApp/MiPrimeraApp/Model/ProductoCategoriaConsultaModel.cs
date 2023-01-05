using MiPrimeraApp.Clases;
using MiPrimeraApp.Generic;
using System;
using System.Collections.Generic;
using System.Text;

namespace MiPrimeraApp.Model
{
    public class ProductoCategoriaConsultaModel : BaseBinding
    {
        private List<string> _LstCategorias;

        public List<string> LstCategorias
        {
            get { return this._LstCategorias; }
            set { SetValue(ref this._LstCategorias, value); }
        }

        private string _nombreCategoria;

        public string nombreCategoria
        {
            get { return this._nombreCategoria; }
            set { SetValue(ref this._nombreCategoria, value); }
        }

        private List<ClsProducto> _LstProductos;

        public List<ClsProducto> LstProductos
        {
            get { return this._LstProductos; }
            set { SetValue(ref this._LstProductos, value); }
        }
    }
}
