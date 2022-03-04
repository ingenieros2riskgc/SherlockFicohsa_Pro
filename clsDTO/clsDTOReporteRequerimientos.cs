﻿namespace clsDTO
{
    public class clsDTOReporteRequerimientos
    {
        private string IdGESREQ;
        private string empresa;
        private string usuario;
        private string numeroREQ;
        private string fechaCreacionGESREQ;
        private string tipoFalla;
        private string grupoAsignado;
        private string encargado;
        private string estado;
        private string criticidad;
        private string fechaVencimientoGESREQ;

        public string idGESREQ
        {
            get { return IdGESREQ; }
            set { IdGESREQ = value; }
        }
        public string Empresa
        {
            get { return empresa; }
            set { empresa = value; }
        }
        public string Usuario
        {
            get { return usuario; }
            set { usuario = value; }
        }
        public string NumeroREQ
        {
            get { return numeroREQ; }
            set { numeroREQ = value; }
        }
        public string FechaCreacionGESREQ
        {
            get { return fechaCreacionGESREQ; }
            set { fechaCreacionGESREQ = value; }
        }
        public string TipoFalla
        {
            get { return tipoFalla; }
            set { tipoFalla = value; }
        }
        public string GrupoAsignado
        {
            get { return grupoAsignado; }
            set { grupoAsignado = value; }
        }
        public string Encargado
        {
            get { return encargado; }
            set { encargado = value; }
        }
        public string Estado
        {
            get { return estado; }
            set { estado = value; }
        }
        public string Criticidad
        {
            get { return criticidad; }
            set { criticidad = value; }
        }
        public string FechaVencimientoGESREQ
        {
            get { return fechaVencimientoGESREQ; }
            set { fechaVencimientoGESREQ = value; }
        }

        public clsDTOReporteRequerimientos()
        {
        }

        public clsDTOReporteRequerimientos(string IdGESREQ, string empresa, string usuario, string numeroREQ, string fechaCreacionGESREQ,
            string tipoFalla, string grupoAsignado, string encargado, string estado, string criticidad, string fechaVencimientoGESREQ)
        {
            this.idGESREQ = IdGESREQ;
            this.Empresa = empresa;
            this.Usuario = usuario;
            this.NumeroREQ = numeroREQ;
            this.FechaCreacionGESREQ = fechaCreacionGESREQ;
            this.TipoFalla = tipoFalla;
            this.GrupoAsignado = grupoAsignado;
            this.Encargado = encargado;
            this.Estado = estado;
            this.Criticidad = criticidad;
            this.FechaVencimientoGESREQ = fechaVencimientoGESREQ;
        }
    }
}
