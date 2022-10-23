using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace MiPrimeraApp.Clases
{
    public class ClsEntity : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

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

        private List<ClsProducto> _LstProductos { get; set; }

        public List<ClsProducto> LstProductos
        {
            get
            {
                return this._LstProductos;
            }
            set
            {
                if (this._LstProductos != value)
                {
                    this._LstProductos = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.LstProductos)));
                }
            }
        }
    }
}
