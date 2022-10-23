using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace MiPrimeraApp.Clases
{
    public class ClsUsuario : INotifyPropertyChanged
    {
        // Creamos una propiedad privada
        private string _Usuario { get; set; }
        private string _Contrasena { get; set; }


        public string Usuario
        {
            get
            {
                return _Usuario;
            }
            set
            {
                if (this._Usuario != value)
                {
                    this._Usuario = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.Usuario)));
                }
            }
        }

        public string Contrasena
        {
            get
            {
                return _Contrasena;
            }
            set
            {
                if (this._Contrasena != value)
                {
                    this._Contrasena = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.Contrasena)));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
