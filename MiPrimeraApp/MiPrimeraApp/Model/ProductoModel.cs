using MiPrimeraApp.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace MiPrimeraApp.Model
{
    public class ProductoModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private ClsProducto _ClsProducto;

        public ClsProducto ClsProducto
        {
            get
            {
                return this._ClsProducto;
            }
            set
            {
                if (this._ClsProducto != value)
                {
                    this._ClsProducto = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.ClsProducto)));
                }
            }
        }

        private List<string> _LstMarcas;

        public List<string> LstMarcas
        {
            get
            {
                return this._LstMarcas;
            }
            set
            {
                if (this._LstMarcas != value)
                {
                    this._LstMarcas = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.LstMarcas)));
                }
            }
        }

        private List<string> _LstCategorias;

        public List<string> LstCategorias
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
