using ListasSarlaft.Classes.Utilerias;
using System;
using System.Collections.Generic;
using System.Data;
namespace ListasSarlaft.Classes
{
    public class clsBLLriesgosIndicadores
    {
        /// <summary>
        /// Metodo para insertar el indicador del riesgo
        /// </summary>
        /// <param name="strErrMsg">Mensaje de error</param>
        /// <returns>Retorna si el proceso fue exitoso o no</returns>
        public bool mtdInsertarRiesgoIndicador(clsDTOriesgosIndicadores indicador, ref string strErrMsg)
        {
            bool booResult = false;
            clsDALriesgoIndicador cDALindicador = new clsDALriesgoIndicador();

            booResult = cDALindicador.mtdInsertarRiesgoIndicador(indicador, ref strErrMsg);

            return booResult;
        }
        /// <summary>
        /// Metodo para tomar el valor del ultimo id registrado
        /// </summary>
        /// <param name="strErrMsg">Mensaje de error</param>
        /// <returns>Retorna si el proceso fue exitoso o no</returns>
        public int mtdGetLastId(ref string strErrMsg)
        {
            int LastId = 0;
            clsDALriesgoIndicador cDALindicador = new clsDALriesgoIndicador();

            LastId = cDALindicador.mtdGetLastId(ref strErrMsg);

            return LastId;
        }
        /// <summary>
        /// Metodo para actualizar el Proceso al Indicador
        /// </summary>
        /// <param name="strErrMsg">Mensaje de error</param>
        /// <returns>Retorna si el proceso fue exitoso o no</returns>
        public bool mtdActualizaProcesoIndicador(clsDTOriesgosIndicadores indicador, ref string strErrMsg)
        {
            bool booResult = false;
            clsDALriesgoIndicador cDALindicador = new clsDALriesgoIndicador();

            booResult = cDALindicador.mtdActualizaProcesoIndicador(indicador, ref strErrMsg);

            return booResult;
        }
        /// <summary>
        /// Realiza la consulta los registros de los Indicadores
        /// </summary>
        /// <param name="strErrMsg">Mensaje de error</param>
        /// <returns>Retorna si el proceso fue exitoso o no</returns>
        public List<clsDTOriesgosIndicadores> mtdConsultarRiesgosIndicadores(bool booEstado, ref string strErrMsg)
        {
            #region Vars
            bool booResult = false;
            DataTable dtInfo = new DataTable();
            List<clsDTOriesgosIndicadores> lstRiesgoIndicador = new List<clsDTOriesgosIndicadores>();
            clsDALriesgoIndicador cDtRiesgoInd = new clsDALriesgoIndicador();
            clsDTOriesgosIndicadores objRiesgoIndicador = new clsDTOriesgosIndicadores();
            clsDTOdetalleFormulaRiesgoIndicador objDetalleFormula = new clsDTOdetalleFormulaRiesgoIndicador();
            List<clsDTOdetalleFormulaRiesgoIndicador> lstDetalle = new List<clsDTOdetalleFormulaRiesgoIndicador>();
            List<clsDTOseguimientoRiesgoIndicador> lstSeguimiento = new List<clsDTOseguimientoRiesgoIndicador>();
            clsBLLformulaRiesgoIndicador cFormula = new clsBLLformulaRiesgoIndicador();
            clsBLLvariableRiesgoIndicador cVariable = new clsBLLvariableRiesgoIndicador();
            clsBLLseguimientoRiesgoIndicador cSeguimiento = new clsBLLseguimientoRiesgoIndicador();
            ProcessClass proceso = new ProcessClass();

            List<clsDTOmetasRiesgoIndicador> lstMetas = new List<clsDTOmetasRiesgoIndicador>();
            clsBLLmetaRiesgoIndicador cMetas = new clsBLLmetaRiesgoIndicador();
            bool booResutl = false;
            #endregion Vars

            booResutl = cDtRiesgoInd.mtdConsultarRiesgosIndicadores(ref dtInfo, ref strErrMsg);

            if (dtInfo != null)
            {
                if (dtInfo.Rows.Count > 0)
                {
                    foreach (DataRow dr in dtInfo.Rows)
                    {
                        double resultFormula = 0;
                        string color = string.Empty;
                        string Descripcion = string.Empty;
                        objRiesgoIndicador = new clsDTOriesgosIndicadores();
                        objRiesgoIndicador.intIdRiesgoIndicador = Convert.ToInt32(dr["IdRiesgoIndicador"].ToString().Trim());
                        objRiesgoIndicador.strNombreIndicador = dr["NombreIndicador"].ToString().Trim();
                        objRiesgoIndicador.strObjetivoIndicador = dr["ObjetivoIndicador"].ToString().Trim();
                        objRiesgoIndicador.intIProcesoIndicador = Convert.ToInt32(dr["IdProcesoIndicador"].ToString().Trim());
                        objRiesgoIndicador.intIdProceso = Convert.ToInt32(dr["IdProceso"].ToString().Trim());
                        objRiesgoIndicador.strNombreProceso = dr["NombreProceso"].ToString().Trim();
                        objRiesgoIndicador.intIdResponsableMedicion = Convert.ToInt32(dr["IdResponsableMedicion"].ToString().Trim());
                        objRiesgoIndicador.strResponsableMedicion = dr["NombreHijo"].ToString().Trim();
                        objRiesgoIndicador.intIdFrecuenciaMedicion = Convert.ToInt32(dr["IdFrecuenciaMedicion"].ToString().Trim());
                        objRiesgoIndicador.strFrecuenciaMedicion = dr["FrecuenciaMedicion"].ToString().Trim();
                        objRiesgoIndicador.intIdRiesgoAsociado = Convert.ToInt32(dr["IdRiesgoAsociado"].ToString().Trim());
                        objRiesgoIndicador.strCodRiesgo = dr["Codigo"].ToString().Trim();
                        objRiesgoIndicador.strNombreRiesgo = dr["Nombre"].ToString().Trim();
                        objRiesgoIndicador.intIdFormula = Convert.ToInt32(dr["IdFormula"].ToString().Trim());
                        if (Convert.ToBoolean(dr["porcentaje"].ToString().Trim()) == true)
                            objRiesgoIndicador.booPorcentaje = 1;
                        else
                            objRiesgoIndicador.booPorcentaje = 0;
                        objRiesgoIndicador.intIdMeta = Convert.ToInt32(dr["IdMeta"].ToString().Trim());
                        lstDetalle = cFormula.mtdConsultarDetalleFormula(booResult, ref strErrMsg, Convert.ToInt32(dr["IdFormula"].ToString().Trim()));
                        lstMetas = cMetas.mtdConsultarMetaRiesgoIndicadorxMeta(booResult, ref strErrMsg, Convert.ToInt32(dr["IdRiesgoIndicador"].ToString().Trim()), Convert.ToInt32(dr["IdMeta"].ToString().Trim()));
                        if (lstMetas != null)
                        {
                            foreach (clsDTOmetasRiesgoIndicador objMetas in lstMetas)
                            {
                                booResutl = proceso.mtdValidateMeta(ref resultFormula, objMetas.strValorOtraFrecuencia,
                                    objMetas.intIdDetalleFrecuencia, objMetas.strAño, objMetas.strMes, lstDetalle,
                                    Convert.ToInt32(dr["IdRiesgoIndicador"].ToString().Trim()), objRiesgoIndicador.booPorcentaje);
                            }
                        }

                        objRiesgoIndicador.dblResultado = resultFormula;
                        lstSeguimiento = cSeguimiento.mtdConsultarSeguimientoIndicador(booResult, ref strErrMsg, Convert.ToInt32(dr["IdRiesgoIndicador"].ToString().Trim()));
                        if (lstSeguimiento != null)
                            Descripcion = proceso.mtdValidaSeguimiento(resultFormula, lstSeguimiento, ref color);
                        objRiesgoIndicador.strDescripcionSeguimiento = Descripcion;
                        objRiesgoIndicador.strColor = color;
                        objRiesgoIndicador.strNominador = dr["Nominador"].ToString().Trim();
                        objRiesgoIndicador.strDenominador = dr["Denominador"].ToString().Trim();

                        objRiesgoIndicador.dblMeta = Convert.ToDouble(dr["Meta"].ToString().Trim());
                        objRiesgoIndicador.intIdEsquemaSeguimiento = Convert.ToInt32(dr["IdEsquemaSeguimiento"].ToString().Trim());
                        objRiesgoIndicador.strUsuario = dr["Usuario"].ToString().Trim();
                        objRiesgoIndicador.dtFechaCreacion = Convert.ToDateTime(dr["FechaCreacion"].ToString().Trim());
                        objRiesgoIndicador.booActivo = Convert.ToInt32(dr["Activo"].ToString().Trim());
                        lstRiesgoIndicador.Add(objRiesgoIndicador);
                    }
                }
                else
                {
                    lstRiesgoIndicador = null;
                    strErrMsg = "No hay registros de Indicadores de Riesgos.";
                }
            }
            else
                objRiesgoIndicador = null;

            return lstRiesgoIndicador;
        }
        /// <summary>
        /// Realiza la consulta los registros de los Indicadores
        /// </summary>
        /// <param name="strErrMsg">Mensaje de error</param>
        /// <returns>Retorna si el proceso fue exitoso o no</returns>
        public List<clsDTOriesgosIndicadores> mtdConsultarRiesgosIndicadores(bool booEstado, ref string strErrMsg, string CodRiesgo, int IdProceso, int Responsable, int IdFactorRiesgo)
        {
            #region Vars
            bool booResult = false;
            DataTable dtInfo = new DataTable();
            List<clsDTOriesgosIndicadores> lstRiesgoIndicador = new List<clsDTOriesgosIndicadores>();
            clsDALriesgoIndicador cDtRiesgoInd = new clsDALriesgoIndicador();
            clsDTOriesgosIndicadores objRiesgoIndicador = new clsDTOriesgosIndicadores();
            clsDTOdetalleFormulaRiesgoIndicador objDetalleFormula = new clsDTOdetalleFormulaRiesgoIndicador();
            List<clsDTOdetalleFormulaRiesgoIndicador> lstDetalle = new List<clsDTOdetalleFormulaRiesgoIndicador>();
            List<clsDTOseguimientoRiesgoIndicador> lstSeguimiento = new List<clsDTOseguimientoRiesgoIndicador>();
            clsBLLformulaRiesgoIndicador cFormula = new clsBLLformulaRiesgoIndicador();
            clsBLLvariableRiesgoIndicador cVariable = new clsBLLvariableRiesgoIndicador();
            clsBLLseguimientoRiesgoIndicador cSeguimiento = new clsBLLseguimientoRiesgoIndicador();
            ProcessClass proceso = new ProcessClass();

            List<clsDTOmetasRiesgoIndicador> lstMetas = new List<clsDTOmetasRiesgoIndicador>();
            clsBLLmetaRiesgoIndicador cMetas = new clsBLLmetaRiesgoIndicador();
            bool booResutl = false;
            #endregion Vars

            booResutl = cDtRiesgoInd.mtdConsultarRiesgosIndicadores(ref dtInfo, ref strErrMsg, CodRiesgo, IdProceso, Responsable, IdFactorRiesgo);

            if (dtInfo != null)
            {
                if (dtInfo.Rows.Count > 0)
                {
                    foreach (DataRow dr in dtInfo.Rows)
                    {
                        double resultFormula = 0;
                        string color = string.Empty;
                        string Descripcion = string.Empty;
                        objRiesgoIndicador = new clsDTOriesgosIndicadores();
                        objRiesgoIndicador.intIdRiesgoIndicador = Convert.ToInt32(dr["IdRiesgoIndicador"].ToString().Trim());
                        objRiesgoIndicador.strNombreIndicador = dr["NombreIndicador"].ToString().Trim();
                        objRiesgoIndicador.strObjetivoIndicador = dr["ObjetivoIndicador"].ToString().Trim();
                        objRiesgoIndicador.intIProcesoIndicador = Convert.ToInt32(dr["IdProcesoIndicador"].ToString().Trim());
                        objRiesgoIndicador.intIdProceso = Convert.ToInt32(dr["IdProceso"].ToString().Trim());
                        objRiesgoIndicador.strNombreProceso = dr["NombreProceso"].ToString().Trim();
                        objRiesgoIndicador.intIdResponsableMedicion = Convert.ToInt32(dr["IdResponsableMedicion"].ToString().Trim());
                        objRiesgoIndicador.strResponsableMedicion = dr["NombreHijo"].ToString().Trim();
                        objRiesgoIndicador.intIdFrecuenciaMedicion = Convert.ToInt32(dr["IdFrecuenciaMedicion"].ToString().Trim());
                        if (string.IsNullOrEmpty(dr["Descripcion"].ToString()))
                        {
                            objRiesgoIndicador.strDescripcionFrecuencia = dr["ValorOtraFrecuencia"].ToString().Trim();
                        }
                        else {

                            objRiesgoIndicador.strDescripcionFrecuencia = dr["Descripcion"].ToString().Trim();
                        }
                        objRiesgoIndicador.strFrecuenciaMedicion = dr["FrecuenciaMedicion"].ToString().Trim();
                        //objRiesgoIndicador.strDescripcionFrecuencia = dr["Descripcion"].ToString().Trim();
                        objRiesgoIndicador.intIdRiesgoAsociado = Convert.ToInt32(dr["IdRiesgoAsociado"].ToString().Trim());
                        objRiesgoIndicador.strCodRiesgo = dr["Codigo"].ToString().Trim();
                        objRiesgoIndicador.strNombreRiesgo = dr["CodRiesgo"].ToString().Trim();
                        objRiesgoIndicador.intIdFormula = Convert.ToInt32(dr["IdFormula"].ToString().Trim());
                        objRiesgoIndicador.booPorcentaje = (Convert.ToBoolean(dr["porcentaje"].ToString().Trim()) == true) ? 1 : 0;
                        objRiesgoIndicador.intIdMeta = Convert.ToInt32(dr["IdMeta"].ToString().Trim());
                        calcularDblResultado(ref resultFormula, ref strErrMsg, dr, objRiesgoIndicador.intIdFrecuenciaMedicion, objRiesgoIndicador.booPorcentaje);
                        objRiesgoIndicador.dblResultado = resultFormula;

                        objRiesgoIndicador.strDescripcionSeguimiento = calcularDescripcion(booResutl, ref strErrMsg, dr, ref color, resultFormula);
                        objRiesgoIndicador.strColor = color;
                        objRiesgoIndicador.strNominador = dr["Nominador"].ToString().Trim();
                        objRiesgoIndicador.strDenominador = dr["Denominador"].ToString().Trim();
                        objRiesgoIndicador.dblMeta = Convert.ToDouble(dr["Meta"].ToString().Trim());
                        objRiesgoIndicador.intIdEsquemaSeguimiento = Convert.ToInt32(dr["IdEsquemaSeguimiento"].ToString().Trim());
                        objRiesgoIndicador.strUsuario = dr["Usuario"].ToString().Trim();
                        objRiesgoIndicador.dtFechaCreacion = Convert.ToDateTime(dr["FechaCreacion"].ToString().Trim());
                        objRiesgoIndicador.booActivo = Convert.ToInt32(dr["Activo"].ToString().Trim());
                        objRiesgoIndicador.strAño = dr["Año"].ToString().Trim();
                        objRiesgoIndicador.strMes = dr["Mes"].ToString().Trim();
                        lstRiesgoIndicador.Add(objRiesgoIndicador);
                    }
                }
                else
                {
                    lstRiesgoIndicador = null;
                    strErrMsg = "No hay registros de Indicadores de Riesgos.";
                }
            }
            else
                objRiesgoIndicador = null;

            return lstRiesgoIndicador;
        }

        /// <summary>
        /// Realiza la consulta los registros de los Indicadores
        /// </summary>
        /// <param name="strErrMsg">Mensaje de error</param>
        /// <returns>Retorna si el proceso fue exitoso o no</returns>
        public List<clsDTOriesgosIndicadores> mtdConsultarRiesgosIndicadores(bool booEstado, ref string strErrMsg, string CodRiesgo)
        {
            #region Vars
            bool booResult = false;
            DataTable dtInfo = new DataTable();
            List<clsDTOriesgosIndicadores> lstRiesgoIndicador = new List<clsDTOriesgosIndicadores>();
            clsDALriesgoIndicador cDtRiesgoInd = new clsDALriesgoIndicador();
            clsDTOriesgosIndicadores objRiesgoIndicador;

            bool booResutl = false;
            #endregion Vars

            booResutl = cDtRiesgoInd.mtdConsultarRiesgosIndicadores(ref dtInfo, ref strErrMsg, CodRiesgo,0,0,0);

            if (dtInfo != null)
            {
                if (dtInfo.Rows.Count > 0)
                {
                    foreach (DataRow dr in dtInfo.Rows)
                    {
                        double resultFormula = 0;
                        string color = string.Empty;
                        string Descripcion = string.Empty;
                        objRiesgoIndicador = new clsDTOriesgosIndicadores();
                        objRiesgoIndicador.intIdRiesgoIndicador = Convert.ToInt32(dr["IdRiesgoIndicador"].ToString().Trim());
                        objRiesgoIndicador.strNombreIndicador = dr["NombreIndicador"].ToString().Trim();
                        objRiesgoIndicador.strObjetivoIndicador = dr["ObjetivoIndicador"].ToString().Trim();
                        objRiesgoIndicador.strFrecuenciaMedicion = dr["FrecuenciaMedicion"].ToString().Trim();

                        calcularDblResultado(ref resultFormula, ref strErrMsg, dr,2, (Convert.ToBoolean(dr["porcentaje"].ToString().Trim()) == true) ? 1 : 0);
                        objRiesgoIndicador.dblResultado = resultFormula;

                        objRiesgoIndicador.strDescripcionSeguimiento = calcularDescripcion(booResutl, ref strErrMsg, dr, ref color, resultFormula);

                        lstRiesgoIndicador.Add(objRiesgoIndicador);
                    }
                }
                else
                {
                    lstRiesgoIndicador = null;
                    strErrMsg = "No hay registros de Indicadores de Riesgos.";
                }
            }
            else
                objRiesgoIndicador = null;

            return lstRiesgoIndicador;
        }

        private void calcularDblResultado(ref double resultFormula, ref string strErrMsg, DataRow dr,int idFrecuencia, int percentage)
        {
            bool booResult = false;
            List<clsDTOdetalleFormulaRiesgoIndicador> lstDetalle = new List<clsDTOdetalleFormulaRiesgoIndicador>();
            clsBLLformulaRiesgoIndicador cFormula = new clsBLLformulaRiesgoIndicador();
            List<clsDTOmetasRiesgoIndicador> lstMetas = new List<clsDTOmetasRiesgoIndicador>();
            clsBLLmetaRiesgoIndicador cMetas = new clsBLLmetaRiesgoIndicador();
            clsDTOriesgosIndicadores objRiesgoIndicador = new clsDTOriesgosIndicadores();
            ProcessClass proceso = new ProcessClass();

            lstDetalle = cFormula.mtdConsultarDetalleFormula(booResult, ref strErrMsg, Convert.ToInt32(dr["IdFormula"].ToString().Trim()));
            lstMetas = cMetas.mtdConsultarMetaRiesgoIndicadorxMeta(booResult, ref strErrMsg, Convert.ToInt32(dr["IdRiesgoIndicador"].ToString().Trim()), Convert.ToInt32(dr["IdMeta"].ToString().Trim()));
            if (lstMetas != null)
            {
                foreach (clsDTOmetasRiesgoIndicador objMetas in lstMetas)
                {
                    if (idFrecuencia == 2)
                    {
                        objMetas.strAño = string.Empty;
                        objMetas.strMes= string.Empty;
                    }
                    booResult = proceso.mtdValidateMeta(ref resultFormula, objMetas.strValorOtraFrecuencia, objMetas.intIdDetalleFrecuencia,
                        objMetas.strAño, objMetas.strMes, lstDetalle, Convert.ToInt32(dr["IdRiesgoIndicador"].ToString().Trim()), percentage);
                }
            }
        }

        private string calcularDescripcion(bool booResult, ref string strErrMsg, DataRow dr, ref string color, double resultFormula)
        {
            List<clsDTOseguimientoRiesgoIndicador> lstSeguimiento = new List<clsDTOseguimientoRiesgoIndicador>();
            clsBLLseguimientoRiesgoIndicador cSeguimiento = new clsBLLseguimientoRiesgoIndicador();
            ProcessClass proceso = new ProcessClass();

            lstSeguimiento = cSeguimiento.mtdConsultarSeguimientoIndicador(booResult, ref strErrMsg, Convert.ToInt32(dr["IdRiesgoIndicador"].ToString().Trim()));
            if (lstSeguimiento != null)
                return proceso.mtdValidaSeguimiento(resultFormula, lstSeguimiento, ref color);
            return "";
        }

        /// <summary>
        /// Metodo para actualizar el indicador del riesgo
        /// </summary>
        /// <param name="strErrMsg">Mensaje de error</param>
        /// <returns>Retorna si el proceso fue exitoso o no</returns>
        public bool mtdActualizarRiesgoIndicador(clsDTOriesgosIndicadores indicador, ref string strErrMsg)
        {
            bool booResult = false;
            clsDALriesgoIndicador cDALindicador = new clsDALriesgoIndicador();

            booResult = cDALindicador.mtdActualizaRiesgoIndicador(indicador, ref strErrMsg);

            return booResult;
        }
        /// <summary>
        /// Metodo para asociar el Riesgo al Indicador
        /// </summary>
        /// <param name="strErrMsg">Mensaje de error</param>
        /// <returns>Retorna si el proceso fue exitoso o no</returns>
        public bool mtdAsociarRiesgoIndicador(clsDTOriesgosIndicadores indicador, ref string strErrMsg)
        {
            bool booResult = false;
            clsDALriesgoIndicador cDALindicador = new clsDALriesgoIndicador();

            booResult = cDALindicador.mtdAsociarRiesgoIndicador(indicador, ref strErrMsg);

            return booResult;
        }
        /// <summary>
        /// Realiza la consulta los registros de los Indicadores
        /// </summary>
        /// <param name="strErrMsg">Mensaje de error</param>
        /// <returns>Retorna si el proceso fue exitoso o no</returns>
        public List<clsDTOriesgosIndicadores> mtdConsultarRiesgosAsociado(bool booEstado, ref string strErrMsg, int IdRiesgoIndicador)
        {
            #region Vars
            DataTable dtInfo = new DataTable();
            List<clsDTOriesgosIndicadores> lstRiesgoIndicador = new List<clsDTOriesgosIndicadores>();
            clsDALriesgoIndicador cDtRiesgoInd = new clsDALriesgoIndicador();
            clsDTOriesgosIndicadores objRiesgoIndicador = new clsDTOriesgosIndicadores();
            bool booResutl = false;
            #endregion Vars

            booResutl = cDtRiesgoInd.mtdConsultarRiesgosAsociado(ref dtInfo, ref strErrMsg, IdRiesgoIndicador);

            if (dtInfo != null)
            {
                if (dtInfo.Rows.Count > 0)
                {
                    foreach (DataRow dr in dtInfo.Rows)
                    {
                        objRiesgoIndicador = new clsDTOriesgosIndicadores();
                        objRiesgoIndicador.intIdRiesgoIndicador = Convert.ToInt32(dr["IdRiesgoIndicador"].ToString().Trim());
                        objRiesgoIndicador.intIdRiesgoAsociado = Convert.ToInt32(dr["IdRiesgoAsociado"].ToString().Trim());
                        objRiesgoIndicador.strCodRiesgo = dr["Codigo"].ToString().Trim();
                        objRiesgoIndicador.strNombreRiesgo = dr["Nombre"].ToString().Trim();
                        lstRiesgoIndicador.Add(objRiesgoIndicador);
                    }
                }
                else
                {
                    lstRiesgoIndicador = null;
                    strErrMsg = "No hay registros de Indicadores de Riesgos.";
                }
            }
            else
                objRiesgoIndicador = null;

            return lstRiesgoIndicador;
        }
        /// <summary>
        /// Metodo para desasociar el Riesgo al Indicador
        /// </summary>
        /// <param name="strErrMsg">Mensaje de error</param>
        /// <returns>Retorna si el proceso fue exitoso o no</returns>
        public bool mtdDesasociarRiesgoIndicador(clsDTOriesgosIndicadores indicador, ref string strErrMsg)
        {
            bool booResult = false;
            clsDALriesgoIndicador cDALindicador = new clsDALriesgoIndicador();

            booResult = cDALindicador.mtdDesasociarRiesgoIndicador(indicador, ref strErrMsg);

            return booResult;
        }
        /// <summary>
        /// Metodo para actualizar el Estado al Indicador
        /// </summary>
        /// <param name="strErrMsg">Mensaje de error</param>
        /// <returns>Retorna si el proceso fue exitoso o no</returns>
        public bool mtdActualizaEstadoRiesgoIndicador(clsDTOriesgosIndicadores indicador, ref string strErrMsg)
        {
            bool booResult = false;
            clsDALriesgoIndicador cDALindicador = new clsDALriesgoIndicador();

            booResult = cDALindicador.mtdActualizaEstadoRiesgoIndicador(indicador, ref strErrMsg);

            return booResult;
        }
        /// <summary>
        /// Metodo para asociar la meta al Indicador
        /// </summary>
        /// <param name="strErrMsg">Mensaje de error</param>
        /// <returns>Retorna si el proceso fue exitoso o no</returns>
        public bool mtdActualizaMetaRiesgoIndicador(clsDTOriesgosIndicadores indicador, ref string strErrMsg)
        {
            bool booResult = false;
            clsDALriesgoIndicador cDALindicador = new clsDALriesgoIndicador();

            booResult = cDALindicador.mtdActualizaMetaRiesgoIndicador(indicador, ref strErrMsg);

            return booResult;
        }
        /// <summary>
        /// Metodo para asociar la formula al Indicador
        /// </summary>
        /// <param name="strErrMsg">Mensaje de error</param>
        /// <returns>Retorna si el proceso fue exitoso o no</returns>
        public bool mtdActualizaFormulaRiesgoIndicador(clsDTOriesgosIndicadores indicador, ref string strErrMsg)
        {
            bool booResult = false;
            clsDALriesgoIndicador cDALindicador = new clsDALriesgoIndicador();

            booResult = cDALindicador.mtdActualizaFormulaRiesgoIndicador(indicador, ref strErrMsg);

            return booResult;
        }
        /// <summary>
        /// Metodo para asociar el seguimiento al Indicador
        /// </summary>
        /// <param name="strErrMsg">Mensaje de error</param>
        /// <returns>Retorna si el proceso fue exitoso o no</returns>
        public bool mtdActualizaSeguimientoRiesgoIndicador(clsDTOriesgosIndicadores indicador, ref string strErrMsg)
        {
            bool booResult = false;
            clsDALriesgoIndicador cDALindicador = new clsDALriesgoIndicador();

            booResult = cDALindicador.mtdActualizaSeguimientoRiesgoIndicador(indicador, ref strErrMsg);

            return booResult;
        }
        /// <summary>
        /// Realiza la consulta los registros de los Indicadores
        /// </summary>
        /// <param name="strErrMsg">Mensaje de error</param>
        /// <returns>Retorna si el proceso fue exitoso o no</returns>
        public List<clsDTOriesgosIndicadores> mtdConsultarRiesgosIndicadoresGestion(bool booEstado, ref string strErrMsg, int IdUsuario, string Responsable)
        {
            #region Vars
            bool booResult = false;
            DataTable dtInfo = new DataTable();
            List<clsDTOriesgosIndicadores> lstRiesgoIndicador = new List<clsDTOriesgosIndicadores>();
            clsDALriesgoIndicador cDtRiesgoInd = new clsDALriesgoIndicador();
            clsDTOriesgosIndicadores objRiesgoIndicador = new clsDTOriesgosIndicadores();
            clsDTOdetalleFormulaRiesgoIndicador objDetalleFormula = new clsDTOdetalleFormulaRiesgoIndicador();
            List<clsDTOdetalleFormulaRiesgoIndicador> lstDetalle = new List<clsDTOdetalleFormulaRiesgoIndicador>();
            clsBLLformulaRiesgoIndicador cFormula = new clsBLLformulaRiesgoIndicador();
            clsBLLvariableRiesgoIndicador cVariable = new clsBLLvariableRiesgoIndicador();
            bool booResutl = false;
            #endregion Vars

            booResutl = cDtRiesgoInd.mtdConsultarRiesgosIndicadoresGestion(ref dtInfo, ref strErrMsg, IdUsuario, Responsable);

            if (dtInfo != null)
            {
                if (dtInfo.Rows.Count > 0)
                {
                    foreach (DataRow dr in dtInfo.Rows)
                    {
                        objRiesgoIndicador = new clsDTOriesgosIndicadores();
                        objRiesgoIndicador.intIdRiesgoIndicador = Convert.ToInt32(dr["IdRiesgoIndicador"].ToString().Trim());
                        objRiesgoIndicador.strNombreIndicador = dr["NombreIndicador"].ToString().Trim();
                        objRiesgoIndicador.strObjetivoIndicador = dr["ObjetivoIndicador"].ToString().Trim();
                        objRiesgoIndicador.intIProcesoIndicador = Convert.ToInt32(dr["IdProcesoIndicador"].ToString().Trim());
                        objRiesgoIndicador.intIdProceso = Convert.ToInt32(dr["IdProceso"].ToString().Trim());
                        objRiesgoIndicador.strNombreProceso = dr["NombreProceso"].ToString().Trim();
                        objRiesgoIndicador.intIdResponsableMedicion = Convert.ToInt32(dr["IdResponsableMedicion"].ToString().Trim());
                        objRiesgoIndicador.strResponsableMedicion = dr["NombreHijo"].ToString().Trim();
                        objRiesgoIndicador.intIdFrecuenciaMedicion = Convert.ToInt32(dr["IdFrecuenciaMedicion"].ToString().Trim());
                        objRiesgoIndicador.strFrecuenciaMedicion = dr["FrecuenciaMedicion"].ToString().Trim();
                        objRiesgoIndicador.intIdRiesgoAsociado = Convert.ToInt32(dr["IdRiesgoAsociado"].ToString().Trim());
                        objRiesgoIndicador.strCodRiesgo = dr["Codigo"].ToString().Trim();
                        objRiesgoIndicador.strNombreRiesgo = dr["Nombre"].ToString().Trim();
                        objRiesgoIndicador.intIdFormula = Convert.ToInt32(dr["IdFormula"].ToString().Trim());
                        objRiesgoIndicador.strNominador = dr["Nominador"].ToString().Trim();
                        objRiesgoIndicador.strDenominador = dr["Denominador"].ToString().Trim();
                        objRiesgoIndicador.intIdMeta = Convert.ToInt32(dr["IdMeta"].ToString().Trim());
                        objRiesgoIndicador.dblMeta = Convert.ToDouble(dr["Meta"].ToString().Trim());
                        objRiesgoIndicador.intIdEsquemaSeguimiento = Convert.ToInt32(dr["IdEsquemaSeguimiento"].ToString().Trim());
                        objRiesgoIndicador.strUsuario = dr["Usuario"].ToString().Trim();
                        objRiesgoIndicador.dtFechaCreacion = Convert.ToDateTime(dr["FechaCreacion"].ToString().Trim());
                        objRiesgoIndicador.booActivo = Convert.ToInt32(dr["Activo"].ToString().Trim());
                        lstRiesgoIndicador.Add(objRiesgoIndicador);
                    }
                }
                else
                {
                    lstRiesgoIndicador = null;
                    strErrMsg = "No hay registros de Indicadores de Riesgos.";
                }
            }
            else
                objRiesgoIndicador = null;

            return lstRiesgoIndicador;
        }
    }
}