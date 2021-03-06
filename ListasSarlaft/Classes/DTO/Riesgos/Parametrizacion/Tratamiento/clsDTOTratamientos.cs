using System;

namespace ListasSarlaft.Classes
{
    public class clsDTOTratamientos
    {
        #region Variables
        private int _IdTratamiento;
        private string _Tratamiento;
        private string _Estado;
        private int _IdUsuario;
        private string _Usuario;
        private DateTime _FechaRegistro;
        #endregion Variables
        #region Get/Set
        public int intIdTratamiento
        {
            get { return _IdTratamiento; }
            set { _IdTratamiento = value; }
        }
        public string strTratamiento
        {
            get { return _Tratamiento; }
            set { _Tratamiento = value; }
        }
        public string strEstado
        {
            get { return _Estado; }
            set { _Estado = value; }
        }
        public int intIdUsuario
        {
            get { return _IdUsuario; }
            set { _IdUsuario = value; }
        }
        public string strUsuario
        {
            get { return _Usuario; }
            set { _Usuario = value; }
        }
        public DateTime dtFechaRegistro
        {
            get { return _FechaRegistro; }
            set { _FechaRegistro = value; }
        }
        #endregion
        #region Constructor
        public clsDTOTratamientos() { }
        #endregion Constructor
    }
}