namespace clsDTO
{
    public class clsDTORegistroComentarios
    {
        private string strIdComentario;
        private string urlArchivo;
        private string descripcion;
        private string strFechaRegistroEvidencia;

        public string StrIdComentario
        {
            get { return strIdComentario; }
            set { strIdComentario = value; }
        }
        public string URLArchivo
        {
            get { return urlArchivo; }
            set { urlArchivo = value; }
        }
        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }
        public string StrFechaRegistroEvidencia
        {
            get { return strFechaRegistroEvidencia; }
            set { strFechaRegistroEvidencia = value; }
        }

        public clsDTORegistroComentarios(string strIdComentario, string urlArchivo, string descripcion, string strFechaRegistroEvidencia)
        {
            this.StrIdComentario = strIdComentario;
            this.URLArchivo = urlArchivo;
            this.Descripcion = descripcion;
            this.StrFechaRegistroEvidencia = strFechaRegistroEvidencia;
        }

        public clsDTORegistroComentarios()
        {
        }
    }
}
