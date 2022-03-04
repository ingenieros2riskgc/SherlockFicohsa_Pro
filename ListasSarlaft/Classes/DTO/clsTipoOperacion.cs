﻿using System;

namespace ListasSarlaft.Classes
{
    public class clsTipoOperacion
    {
        private int _Id;
        private string _Nombre;
        private int _IdUsuario;
        private DateTime _FechaRegistro;

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

        #region
        public clsTipoOperacion()
        {

        }

        public clsTipoOperacion(int intId, string strNombre, int intIdUsuario, DateTime dtFechaRegistro)
        {
            this.intId = intId;
            this.strNombre = strNombre;
            this.intIdUsuario = intIdUsuario;
            this.dtFechaRegistro = dtFechaRegistro;
        }
        #endregion
    }
}