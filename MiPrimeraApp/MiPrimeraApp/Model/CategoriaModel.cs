using MiPrimeraApp.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace MiPrimeraApp.Model
{
    public class CategoriaModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private bool _IsLoading { get; set; }

        public bool IsLoading
        {
            get
            {
                return this._IsLoading;
            }
            set
            {
                if (this._IsLoading != value)
                {
                    this._IsLoading = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this._IsLoading)));
                }
            }
        }

        private List<ClsCategoria> _LstCategorias { get; set; }

        public List<ClsCategoria> LstCategorias
        {
            get
            {
                return this._LstCategorias;
            }
            set
            {
                if (this._LstCategorias != value)
                {
                    this._LstCategorias = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.LstCategorias)));
                }
            }
        }
    }
}
