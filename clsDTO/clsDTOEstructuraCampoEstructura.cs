namespace clsDTO
{
    public class clsDTOEstructuraCampoEstructura : clsDTOVariable
    {
        #region Properties
        private string strIdUsuario;
        private string strIdEstructCampo;
        private string strNombreCampo;
        private string strLongitud;
        private bool booEsParametrico;
        private string strNombreTipoDato;
        private string strIdTipoDato;
        private string strPosicion;
        private bool booEstado;
        private bool booNumerico;
        public string StrIdUsuario
        {
            get { return strIdUsuario; }
            set { strIdUsuario = value; }
        }
        public string StrIdEstructCampo
        {
            get { return strIdEstructCampo; }
            set { strIdEstructCampo = value; }
        }

        public string StrNombreCampo
        {
            get { return strNombreCampo; }
            set { strNombreCampo = value; }
        }

        public string StrLongitud
        {
            get { return strLongitud; }
            set { strLongitud = value; }
        }

        public bool BooEsParametrico
        {
            get { return booEsParametrico; }
            set { booEsParametrico = value; }
        }
        public bool BoolEstado
        {
            get { return booEstado; }
            set { booEstado = value; }
        }
        public bool BoolNumerico
        {
            get { return booNumerico; }
            set { booNumerico = value; }
        }

        public string StrIdTipoDato
        {
            get { return strIdTipoDato; }
            set { strIdTipoDato = value; }
        }

        public string StrNombreTipoDato
        {
            get { return strNombreTipoDato; }
            set { strNombreTipoDato = value; }
        }

        public string StrPosicion
        {
            get { return strPosicion; }
            set { strPosicion = value; }
        }

        public int Estado { get; set; }
        #endregion Properties

        public clsDTOEstructuraCampoEstructura() { }

        public clsDTOEstructuraCampoEstructura(string strIdUsuario, string strIdEstructCampo, string strNombreCampo, string strIdTipoDato, string strLongitud,
            bool booEsParametrico, string strIdVariable, string strNombreVariable, string strNombreTipoDato, string strPosicion, /*int estado,*/ bool booEstado, bool booNumeric)
        {
            this.StrIdUsuario = strIdUsuario;
            this.StrIdVariable = strIdVariable;
            this.StrNombreVariable = strNombreVariable;
            this.StrIdEstructCampo = strIdEstructCampo;
            this.StrNombreCampo = strNombreCampo;
            this.StrLongitud = strLongitud;
            this.BooEsParametrico = booEsParametrico;
            this.StrIdTipoDato = strIdTipoDato;
            this.StrNombreTipoDato = strNombreTipoDato;
            this.StrPosicion = strPosicion;
            this.BoolEstado = booEstado;
            this.BoolNumerico = booNumeric;
            //Estado = estado;
        }

        public string mtdConsultarPosicion()
        {
            return this.strPosicion;
        }
    }
}
