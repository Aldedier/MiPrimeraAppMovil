using MiPrimeraApp.Clases;
using MiPrimeraApp.Generic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace MiPrimeraApp.Model
{
    public class ProductoModel : BaseBinding
    {
        private bool _IsLoadingForm;

        public bool IsLoadingForm
        {
            get { return this._IsLoadingForm; }
            set { SetValue(ref this._IsLoadingForm, value); }
        }

        private ClsProducto _ClsProducto;

        public ClsProducto ClsProducto
        {
            get { return this._ClsProducto; }
            set { SetValue(ref this._ClsProducto, value); }
        }

        private List<string> _LstMarcas;

        public List<string> LstMarcas
        {
            get { return this._LstMarcas; }
            set { SetValue(ref this._LstMarcas, value); }
        }

        private List<string> _LstCategorias;

        public List<string> LstCategorias
        {
            get { return this._LstCategorias; }
            set { SetValue(ref this._LstCategorias, value); }
        }

        private List<ClsProducto> _LstProductos;

        public List<ClsProducto> LstProductos
        {
            get { return this._LstProductos; }
            set { SetValue(ref this._LstProductos, value); }
        }
    }
}
