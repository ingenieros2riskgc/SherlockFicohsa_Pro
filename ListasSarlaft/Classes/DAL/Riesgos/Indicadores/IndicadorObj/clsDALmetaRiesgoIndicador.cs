using System;
using System.Data;

namespace ListasSarlaft.Classes
{
    public class clsDALmetaRiesgoIndicador
    {
        public bool mtdInsertarMetaRiesgoIndicador(clsDTOmetasRiesgoIndicador objMeta, ref string strErrMsg)
        {
            #region Vars
            bool booResult = false;
            string strConsulta = string.Empty;
            string strConsulta1 = string.Empty;
            cDataBase cDatabase = new cDataBase();
            DataTable dtCaracOut = new DataTable();
            int idFrecuencia = 0;
            #endregion Vars

            try
            {
                strConsulta1 = string.Format("select IdFrecuenciaMedicion from Riesgos.RiesgosIndicadores where IdRiesgoIndicador = {0}",
                objMeta.intIdRiesgoIndicador);

                cDatabase.conectar();
                dtCaracOut = cDatabase.ejecutarConsulta(strConsulta1);
                idFrecuencia = Convert.ToInt32(dtCaracOut.Rows[0]["IdFrecuenciaMedicion"].ToString());

                strConsulta = string.Format("INSERT INTO [Riesgos].[RiesgosIndicadoresMetas] ([IdRiesgoIndicador],[Meta],[UsuarioCreacion],[FechaCreacion],[IdDetalleFrecuenciaMedicion]" +
                    ",[ValorOtraFrecuencia],[Año],[mes])" +
                    "VALUES({0},{1},{2},GETDATE(),{4},'{5}','{6}','{7}') ", objMeta.intIdRiesgoIndicador, objMeta.dblMeta, objMeta.intUsuarioCreacion,
                    objMeta.dtFechaCreacion, objMeta.intIdDetalleFrecuencia, objMeta.strValorOtraFrecuencia, objMeta.strAño, objMeta.strMes
                    );

                //cDatabase.conectar();
                cDatabase.ejecutarQuery(strConsulta);
                booResult = true;

                if (idFrecuencia == 2)
                {
                    DataTable dtCaracOut1 = new DataTable();
                    int idMax = 0;
                    string strconsulta3 = string.Empty;
                    strconsulta3 = string.Format("SELECT max([IdMeta]) LastId FROM [Riesgos].[RiesgosIndicadoresMetas]");
                    
                    dtCaracOut1 = cDatabase.ejecutarConsulta(strconsulta3);
                    idMax = Convert.ToInt32(dtCaracOut1.Rows[0]["LastId"].ToString());


                    DateTime mesprueba = Convert.ToDateTime(objMeta.strValorOtraFrecuencia);
                    string mes1 = mesprueba.ToString("MMMM", new System.Globalization.CultureInfo("es-ES"));
                    int year = mesprueba.Year;
                    string strconsulta2 = string.Empty;

                    strconsulta2 = string.Format("UPDATE [Riesgos].[RiesgosIndicadoresMetas] SET Año = {0} , mes = '{1}' WHERE " +
                        "idMeta = {2} ", year, mes1, idMax);
                    cDatabase.ejecutarQuery(strconsulta2);
                }
            }
            catch (Exception ex)
            {
                strErrMsg = string.Format("Error al crear la meta del indicador. [{0}]", ex.Message);
                booResult = false;
            }
            finally
            {
                cDatabase.desconectar();
            }

            return booResult;
        }
        public bool mtdConsultarMetaRiesgoIndicador(ref DataTable dtCaracOut, ref string strErrMsg, int IdRiesgoIndicador)
        {
            #region Vars
            bool booResult = false;
            string strConsulta = string.Empty;
            cDataBase cDataBase = new cDataBase();
            #endregion Vars

            try
            {
                strConsulta = string.Format("SELECT [IdMeta],[IdRiesgoIndicador],[Meta],[UsuarioCreacion],[FechaCreacion],[IdDetalleFrecuenciaMedicion],RRIDF.Descripcion," +
                    "[ValorOtraFrecuencia],[Año],[mes]"
                    + " FROM [Riesgos].[RiesgosIndicadoresMetas] as RRIM"
                    + " left JOIN [Riesgos].[RiesgosIndicadoresDetalleFrecuencia] as RRIDF on RRIDF.IdDetalleFecruencia = RRIM.IdDetalleFrecuenciaMedicion"
                    + " where RRIM.IdRiesgoindicador = {0}", IdRiesgoIndicador
                    );

                cDataBase.conectar();
                dtCaracOut = cDataBase.ejecutarConsulta(strConsulta);
                booResult = true;
            }
            catch (Exception ex)
            {
                strErrMsg = string.Format("Error al consultar las metas del indicador. [{0}]", ex.Message);
                booResult = false;
            }
            finally
            {
                cDataBase.desconectar();
            }

            return booResult;
        }
        public bool mtdConsultarMetaRiesgoIndicadorxMeta(ref DataTable dtCaracOut, ref string strErrMsg, int IdRiesgoIndicador, int IdMeta)
        {
            #region Vars
            bool booResult = false;
            string strConsulta = string.Empty;
            cDataBase cDataBase = new cDataBase();
            #endregion Vars

            try
            {
                strConsulta = string.Format("SELECT [IdMeta],[IdRiesgoIndicador],[Meta],[UsuarioCreacion],[FechaCreacion],[IdDetalleFrecuenciaMedicion],RRIDF.Descripcion," +
                    "[ValorOtraFrecuencia],[Año],[mes]"
                    + " FROM [Riesgos].[RiesgosIndicadoresMetas] as RRIM"
                    + " left JOIN [Riesgos].[RiesgosIndicadoresDetalleFrecuencia] as RRIDF on RRIDF.IdDetalleFecruencia = RRIM.IdDetalleFrecuenciaMedicion"
                    + " where RRIM.IdRiesgoindicador = {0} and IdMeta = {1}", IdRiesgoIndicador, IdMeta
                    );

                cDataBase.conectar();
                dtCaracOut = cDataBase.ejecutarConsulta(strConsulta);
                booResult = true;
            }
            catch (Exception ex)
            {
                strErrMsg = string.Format("Error al consultar las metas del indicador. [{0}]", ex.Message);
                booResult = false;
            }
            finally
            {
                cDataBase.desconectar();
            }
            
            return booResult;
        }
        public bool mtdActualizarMetaRiesgoIndicador(clsDTOmetasRiesgoIndicador objMeta, ref string strErrMsg)
        {
            #region Vars
            bool booResult = false;
            string strConsulta = string.Empty;
            string strConsulta1 = string.Empty;
            cDataBase cDatabase = new cDataBase();
            DataTable dtCaracOut = new DataTable();
            int idFrecuencia = 0;

            #endregion Vars

            
            strConsulta1 = string.Format("select IdFrecuenciaMedicion from Riesgos.RiesgosIndicadores where IdRiesgoIndicador = {0}",
                objMeta.intIdRiesgoIndicador);

            cDatabase.conectar();
            dtCaracOut = cDatabase.ejecutarConsulta(strConsulta1);
            idFrecuencia = Convert.ToInt32(dtCaracOut.Rows[0]["IdFrecuenciaMedicion"].ToString());


            try
            {

                strConsulta = string.Format("UPDATE [Riesgos].[RiesgosIndicadoresMetas] SET [Meta] = {0} ,[IdDetalleFrecuenciaMedicion] = {1}" +
                    ",[ValorOtraFrecuencia] = '{2}', [Año] = '{4}', [mes] = '{5}' WHERE IdMeta = {3} ", objMeta.dblMeta, objMeta.intIdDetalleFrecuencia, 
                    objMeta.strValorOtraFrecuencia, objMeta.intIdMeta,
                    objMeta.strAño, objMeta.strMes
                    );

                //cDatabase.conectar();
                cDatabase.ejecutarQuery(strConsulta);
                booResult = true;
                if (idFrecuencia == 2)
                {
                    DateTime mesprueba = Convert.ToDateTime(objMeta.strValorOtraFrecuencia);
                    string mes1 = mesprueba.ToString("MMMM", new System.Globalization.CultureInfo("es-ES"));
                    int year = mesprueba.Year;
                    string strconsulta2 = string.Empty;

                    strconsulta2 = string.Format("UPDATE [Riesgos].[RiesgosIndicadoresMetas] SET Año = {0} , mes = '{1}' WHERE " +
                        "idMeta = {2} ", year, mes1, objMeta.intIdMeta);
                    cDatabase.ejecutarQuery(strconsulta2);
                }
            }
            catch (Exception ex)
            {
                strErrMsg = string.Format("Error al actualizar la meta del indicador. [{0}]", ex.Message);
                booResult = false;
            }
            finally
            {
                cDatabase.desconectar();
            }   
            return booResult;
        }

        public bool logCambioMeta(int idmeta,string NombreUsuario,string Justificaion,ref string strErrMsg)
        {
            bool booResult = false;
            string strConsulta = string.Empty;           
            cDataBase cDatabase = new cDataBase();
            try
            {      
                cDatabase.conectar();    

                strConsulta = string.Format("Insert into [Riesgos].[RiesgosModificacionMetasLog] (IdMeta,NombreUsuario,JustificacionCambio,FechaModificacion) values ({0},'{1}','{2}',getdate())",idmeta,NombreUsuario,Justificaion);

                //cDatabase.conectar();
                cDatabase.ejecutarQuery(strConsulta);
                booResult = true;
            }
            catch (Exception ex)
            {
                strErrMsg = string.Format("Error al crear la meta del indicador. [{0}]", ex.Message);
                booResult = false;
            }
            finally
            {
                cDatabase.desconectar();
            }
            return booResult;
          }


        public DataTable CambiosMetaLogs(string idmeta, ref string strErrMsg)
        {
            string strConsulta = string.Empty;
            cDataBase cDataBase = new cDataBase();
            DataTable dtLogCambios = new DataTable();
            try
            {
                cDataBase.conectar();
                dtLogCambios = cDataBase.ejecutarConsulta("select Id,NombreUsuario, JustificacionCambio, FechaModificacion from [Riesgos].[RiesgosModificacionMetasLog] where IdMeta="+idmeta);
                cDataBase.desconectar();
            }
            catch (Exception ex)
            {
                cDataBase.desconectar();
                strErrMsg = string.Format("Error al consultar el ultimo id registrado. [{0}]", ex.Message);
                throw new Exception(ex.Message);
            }
            return dtLogCambios;
        }



            public bool mtdEliminaMeta(string IdMeta, ref string strErrMsg)
             {
            #region Vars
            bool booResult = false;
            string strConsulta = string.Empty;
            cDataBase cDatabase = new cDataBase();
            #endregion Vars

            try
            {
                strConsulta = string.Format("DELETE FROM [Riesgos].[RiesgosIndicadoresMetas]" +
                    " WHERE IdMeta = {0}", IdMeta
                    );

                cDatabase.conectar();
                cDatabase.ejecutarQuery(strConsulta);
                booResult = true;
            }
            catch (Exception ex)
            {
                strErrMsg = string.Format("Error al eliminar la meta del indicador. [{0}]", ex.Message);
                booResult = false;
            }
            finally
            {
                cDatabase.desconectar();
            }

            return booResult;
        }
        public int mtdGetLastId(ref string strErrMsg)
        {
            #region Vars
            string strConsulta = string.Empty;
            cDataBase cDataBase = new cDataBase();
            DataTable dtCaracOut = new DataTable();
            int LastId = 0;
            #endregion Vars

            try
            {
                strConsulta = string.Format("SELECT max([IdMeta]) LastId FROM [Riesgos].[RiesgosIndicadoresMetas]");

                cDataBase.conectar();
                dtCaracOut = cDataBase.ejecutarConsulta(strConsulta);
                LastId = Convert.ToInt32(dtCaracOut.Rows[0]["LastId"].ToString());
            }
            catch (Exception ex)
            {
                strErrMsg = string.Format("Error al consultar el ultimo id registrado. [{0}]", ex.Message);
            }
            finally
            {
                cDataBase.desconectar();
            }

            return LastId;
        }
    }
}