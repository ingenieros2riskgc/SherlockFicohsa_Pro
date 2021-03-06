using System;

namespace ListasSarlaft.Classes
{
    public class clsDTOParaCalificacionRiesgo
    {
        #region Variables
        private int _IdClasificacionRiesgo;
        private string _NombreClasificacionRiesgo;
        private string _Color;
        private int _IdUsuario;
        private DateTime _FechaRegistro;
        #endregion Variables
        #region Get/Set
        public int intIdClasificacionRiesgo
        {
            get { return _IdClasificacionRiesgo; }
            set { _IdClasificacionRiesgo = value; }
        }
        public string strNombreClasificacionRiesgo
        {
            get { return _NombreClasificacionRiesgo; }
            set { _NombreClasificacionRiesgo = value; }
        }

        public string Color
        {
            get { return _Color; }
            set { _Color = value; }
        }
        public int intIdUsuario
        {
            get { return _IdUsuario; }
            set { _IdUsuario = value; }
        }
        public DateTime dtFechaRegistro
        {
            get { return _FechaRegistro; }
            set { _FechaRegistro = value; }
        }
        #endregion Get/Set
        #region Constructor
        public clsDTOParaCalificacionRiesgo() { }
        #endregion Constructor
    }
}