namespace ListasSarlaft.Classes
{
    public class clsVerCaracterizacionSalidas
    {
        private string _DescripcionSalida;
        private string _Cliente;
        public string strDescripcionSalida
        {
            get { return _DescripcionSalida; }
            set { _DescripcionSalida = value; }
        }
        public string strCliente
        {
            get { return _Cliente; }
            set { _Cliente = value; }
        }
        #region Constructors
        public clsVerCaracterizacionSalidas()
        {
        }

        public clsVerCaracterizacionSalidas(
            string strDescripcionSalida, string strCliente)
        {

            this.strDescripcionSalida = strDescripcionSalida;
            this.strCliente = strCliente;

        }
        #endregion
    }
}