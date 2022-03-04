using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace ListasSarlaft.Classes.DAL.Dashboard
{
    public class clsDALDashboard
    {
        public DataTable mtdGetGraficoIndicadorvsObjetivo()
        {
            DataTable dtInfo = new DataTable();
            cDataBase cDataBase = new cDataBase();
            // Se pasa la condicion a la consulta del procedimiento almacenado
            List<SqlParameter> parametros = new List<SqlParameter>()
                        {
                            new SqlParameter() { ParameterName = "@SentenciaWhere", SqlDbType = SqlDbType.VarChar, Value =  "" }
                        };
            dtInfo = cDataBase.EjecutarSPParametrosReturnDatatableSinParametros("[Gestion].[SP_GraficoIndicadorvsObjetivoDashboard]");
            return dtInfo;
        }
        public DataTable mtdGetGraficoObjetivovsPerspectiva()
        {
            DataTable dtInfo = new DataTable();
            cDataBase cDataBase = new cDataBase();
            // Se pasa la condicion a la consulta del procedimiento almacenado
            List<SqlParameter> parametros = new List<SqlParameter>()
                        {
                            new SqlParameter() { ParameterName = "@SentenciaWhere", SqlDbType = SqlDbType.VarChar, Value =  "" }
                        };
            dtInfo = cDataBase.EjecutarSPParametrosReturnDatatableSinParametros("[Gestion].[SP_ObjetivoXPerspectiva_Dashboard]");
            return dtInfo;
        }
        public DataTable LoadInfoReporteRiesgosvsObjetivos()
        {
            #region Variables
            cDataBase cDataBase = new cDataBase();
            DataTable dtInformacion = new DataTable();
            cError cError = new cError();
            string strFrom = string.Empty, strFechaIni = string.Empty, strFechaFin = string.Empty, strFechaFinal = string.Empty, strConsulta = string.Empty;
            #endregion Variables
            try
            {
                strConsulta = "SELECT a.CodigoObjetivo,a.ObjetivoEstrategico," + "\n" +
                "(select count(1) FROM[Gestion].[vwGestionRiesgovsObjetivos] as b" + "\n" +
                "where b.CodigoObjetivo = a.CodigoObjetivo and b.RiesgoResidual = 'Bajo') Bajo" + "\n" +
                ",(select count(1) FROM[Gestion].[vwGestionRiesgovsObjetivos] as b" + "\n" +
                "where b.CodigoObjetivo = a.CodigoObjetivo and b.RiesgoResidual = 'Moderado') Moderado" + "\n" +
                ",(select count(1) FROM[Gestion].[vwGestionRiesgovsObjetivos] as b" + "\n" +
                "where b.CodigoObjetivo = a.CodigoObjetivo and b.RiesgoResidual = 'Alto') Alto" + "\n" +
                ",(select count(1) FROM[Gestion].[vwGestionRiesgovsObjetivos] as b" + "\n" +
                "where b.CodigoObjetivo = a.CodigoObjetivo and b.RiesgoResidual = 'Extremo') Extremo" + "\n" +
                " FROM [Gestion].[vwGestionRiesgovsObjetivosGrafica] as a";
                cDataBase.conectar();
                dtInformacion = cDataBase.ejecutarConsulta(strConsulta);
                cDataBase.desconectar();
            }
            catch (Exception ex)
            {
                cDataBase.desconectar();
                cError.errorMessage(ex.Message + ", " + ex.StackTrace);
                throw new Exception(ex.Message);
            }
            return dtInformacion;
        }
        public DataTable LoadInfoReporteNumerosRos()
        {
            #region Variables
            cDataBase cDataBase = new cDataBase();
            DataTable dtInformacion = new DataTable();
            cError cError = new cError();
            string strFrom = string.Empty, strFechaIni = string.Empty, strFechaFin = string.Empty, strFechaFinal = string.Empty, strConsulta = string.Empty;
            #endregion Variables
            try
            {
                int year = DateTime.Now.Year;
                strConsulta = string.Format("SELECT [mes],[año],sum([cantidad]) FROM [AML].[GraficaNumeroRos] " + "\n" +
                    "where IdTipoRegistro = 2 and año = {0} group by mes,año", year);
                cDataBase.conectar();
                dtInformacion = cDataBase.ejecutarConsulta(strConsulta);
                cDataBase.desconectar();
            }
            catch (Exception ex)
            {
                cDataBase.desconectar();
                cError.errorMessage(ex.Message + ", " + ex.StackTrace);
                throw new Exception(ex.Message);
            }
            return dtInformacion;
        }
        public DataTable LoadInfoReporteEstadosRoi()
        {
            #region Variables
            cDataBase cDataBase = new cDataBase();
            DataTable dtInformacion = new DataTable();
            cError cError = new cError();
            string strFrom = string.Empty, strFechaIni = string.Empty, strFechaFin = string.Empty, strFechaFinal = string.Empty, strConsulta = string.Empty;
            #endregion Variables
            try
            {
                int year = DateTime.Now.Year;
                strConsulta = string.Format("SELECT [NombreEstado],SUM([cantidad]) FROM [AML].[GraficaEstadoRoi] " + "\n" +
                    "where IdTipoRegistro = 1 and [año] = {0} group by [NombreEstado] ", year);
                cDataBase.conectar();
                dtInformacion = cDataBase.ejecutarConsulta(strConsulta);
                cDataBase.desconectar();
            }
            catch (Exception ex)
            {
                cDataBase.desconectar();
                cError.errorMessage(ex.Message + ", " + ex.StackTrace);
                throw new Exception(ex.Message);
            }
            return dtInformacion;
        }
        public DataTable LoadInfoRiesgosCadenaValor()
        {
            #region Variables
            cDataBase cDataBase = new cDataBase();
            DataTable dtInformacion = new DataTable();
            cError cError = new cError();
            string strFrom = string.Empty, strFechaIni = string.Empty, strFechaFin = string.Empty, strFechaFinal = string.Empty, strConsulta = string.Empty;
            #endregion Variables
            try
            {
                int year = DateTime.Now.Year;
                strConsulta = string.Format("SELECT COUNT(Riesgos.Riesgo.IdRiesgo) AS NumeroRegistros,Riesgos.Riesgo.IdCadenaValor," + "\n" +
                "Riesgos.Riesgo.IdProbabilidadResidual, Riesgos.Riesgo.IdImpactoResidual " + "\n" +
                "FROM	Riesgos.Riesgo WHERE (Riesgos.Riesgo.Anulado = 0) " + "\n" +//AND (Riesgos.Riesgo.IdClasificacionRiesgo = 2)
                "and YEAR(Riesgos.Riesgo.FechaRegistro) = {0} " + "\n" +
                "GROUP BY Riesgos.Riesgo.IdCadenaValor,Riesgos.Riesgo.IdProbabilidadResidual, Riesgos.Riesgo.IdImpactoResidual " + "\n" +
                "order by IdCadenaValor,IdProbabilidadResidual, IdImpactoResidual", year);
                cDataBase.conectar();
                dtInformacion = cDataBase.ejecutarConsulta(strConsulta);
                cDataBase.desconectar();
            }
            catch (Exception ex)
            {
                cDataBase.desconectar();
                cError.errorMessage(ex.Message + ", " + ex.StackTrace);
                throw new Exception(ex.Message);
            }
            return dtInformacion;
        }
        public string mtdGetNombreCadenaValor(int idCadenaValor)
        {
            #region Variables
            cDataBase cDataBase = new cDataBase();
            DataTable dtInformacion = new DataTable();
            cError cError = new cError();

            string strFrom = string.Empty, NombreCadenaValor = string.Empty, strFechaFin = string.Empty, strFechaFinal = string.Empty, strConsulta = string.Empty;
            #endregion Variables
            try
            {

                strConsulta = string.Format("SELECT [NombreCadenaValor] FROM [Procesos].[CadenaValor] where IdCadenaValor = {0}", idCadenaValor);
                cDataBase.conectar();
                dtInformacion = cDataBase.ejecutarConsulta(strConsulta);
                cDataBase.desconectar();
                if (dtInformacion != null)
                {
                    if (dtInformacion.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dtInformacion.Rows)
                        {
                            NombreCadenaValor = dr["NombreCadenaValor"].ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                cDataBase.desconectar();
                cError.errorMessage(ex.Message + ", " + ex.StackTrace);
                throw new Exception(ex.Message);
            }
            return NombreCadenaValor;
        }
    }
}