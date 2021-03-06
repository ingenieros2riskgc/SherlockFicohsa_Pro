using System;

namespace ListasSarlaft.Classes
{
    public class clsTipoControl
    {
        private int _Id;
        private string _Nombre;
        private DateTime _FechaRegistro;
        private int _IdUsuario;

        public int intId
        {
            get
            {
                return _Id;
            }

            set
            {
                _Id = value;
            }
        }

        public string strNombre
        {
            get
            {
                return _Nombre;
            }

            set
            {
                _Nombre = value;
            }
        }

        public DateTime dtFechaRegistro
        {
            get
            {
                return _FechaRegistro;
            }

            set
            {
                _FechaRegistro = value;
            }
        }

        public int intIdUsuario
        {
            get
            {
                return _IdUsuario;
            }

            set
            {
                _IdUsuario = value;
            }
        }

        #region
        public clsTipoControl()
        {

        }

        public clsTipoControl(int intId, string strNombre, int intIdUsuario, DateTime dtFechaRegistro)
        {
            this.intId = intId;
            this.strNombre = strNombre;
            this.dtFechaRegistro = dtFechaRegistro;
            this.intIdUsuario = intIdUsuario;
        }
        #endregion
    }
}