using MiPrimeraApp.Clases;
using MiPrimeraApp.Generic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace MiPrimeraApp.Model
{
    public class CategoriaModel : BaseBinding
    {
        private bool _IsLoading;

        public bool IsLoading
        {
            get { return this._IsLoading; }
            set { SetValue(ref this._IsLoading, value); }
        }

        private List<ClsCategoria> _LstCategorias;

        public List<ClsCategoria> LstCategorias
        {
            get { return this._LstCategorias; }
            set { SetValue(ref this._LstCategorias, value); }
        }
    }
}
