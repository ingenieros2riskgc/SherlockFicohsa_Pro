using System;
using System.Data.OleDb;

namespace ListasSarlaft.Classes
{
    public class clsDALInsParaRiesgoAsociadoOperativo
    {
        #region Variables Globales
        private cDataBase cDataBase = new cDataBase();
        private cError cError = new cError();
        private OleDbParameter[] parameters;
        private OleDbParameter parameter;
        #endregion Variables Globales
        public bool mtdInsertarParaRiesgoAsociadoOperativo(clsDTOParaRiesgoAsociadoOperativo RiesgoAsociadoOp, ref string strErrMsg)
        {
            string strConsulta = string.Empty, strTodosProcesos = string.Empty, strContrasenaEncriptada = string.Empty;
            bool booResult = true;

            try
            {
                #region Creacion Consulta
                parameters = new OleDbParameter[1];
                parameter = new OleDbParameter("@NombreRiesgoAsociadoOperativo", OleDbType.VarChar);
                parameter.Value = RiesgoAsociadoOp.strNombreRiesgoAsociadoOperativo;
                parameters[0] = parameter;
                #endregion Creacion Consulta

                cDataBase.conectar();
                cDataBase.ejecutarSPParametros("Parametrizacion.spRIESGOSInsertaRiesgoAsociadoOperativo", parameters);
                booResult = true;
            }
            catch (Exception ex)
            {
                booResult = false;
                cError.errorMessage(ex.Message + ", " + ex.StackTrace);
                strErrMsg = string.Format("Error al insertar los riesgos asociados. [{0}]", ex.Message);
            }
            finally
            {
                cDataBase.desconectar();
            }

            return booResult;
        }
    }
}