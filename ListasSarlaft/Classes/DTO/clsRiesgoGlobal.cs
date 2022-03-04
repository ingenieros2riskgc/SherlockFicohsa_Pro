namespace ListasSarlaft.Classes
{
    public class clsRiesgoGlobal
    {
        private int _Id;
        private string _NombreRiesgo;

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

        public string strNombreRiesgo
        {
            get
            {
                return _NombreRiesgo;
            }

            set
            {
                _NombreRiesgo = value;
            }
        }



        #region Constructors
        public clsRiesgoGlobal()
        {

        }

        public clsRiesgoGlobal(int intId, string strNombreRiesgo)
        {
            this.intId = intId;
            this.strNombreRiesgo = strNombreRiesgo;
        }

        //public clsEstadoPlan(int intId, string strNombreEstado)
        //{
        //    this.intId = intId;
        //    this.strNombreEstado = strNombreEstado;
        //}
        #endregion
    }
}