namespace ListasSarlaft.Classes
{
    public class clsEstadoPlan
    {
        private int _Id;
        private string _NombreEstado;

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

        public string strNombreEstado
        {
            get
            {
                return _NombreEstado;
            }

            set
            {
                _NombreEstado = value;
            }
        }



        #region Constructors
        public clsEstadoPlan()
        {

        }

        public clsEstadoPlan(int intId, string strNombreEstado)
        {
            this.intId = intId;
            this.strNombreEstado = strNombreEstado;
        }

        //public clsEstadoPlan(int intId, string strNombreEstado)
        //{
        //    this.intId = intId;
        //    this.strNombreEstado = strNombreEstado;
        //}
        #endregion
    }
}