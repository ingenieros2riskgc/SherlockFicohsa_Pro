namespace ListasSarlaft.Classes
{
    public class clsDTOIntegrantes
    {

        private int idUsuarioSoporte;
        private string nombreUsuarioSoporte;

        public int IdUsuarioSoporte
        {
            get { return idUsuarioSoporte; }
            set { idUsuarioSoporte = value; }
        }
        public string NombreUsuarioSoporte
        {
            get { return nombreUsuarioSoporte; }
            set { nombreUsuarioSoporte = value; }
        }

        public clsDTOIntegrantes() { }

    }
}