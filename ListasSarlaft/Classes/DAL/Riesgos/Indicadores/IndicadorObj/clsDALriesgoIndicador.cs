using System;
using System.Data;
using System.Text.RegularExpressions;

namespace ListasSarlaft.Classes
{
    public class clsDALriesgoIndicador
    {
        public bool mtdInsertarRiesgoIndicador(clsDTOriesgosIndicadores objIndicador, ref string strErrMsg)
        {
            #region Vars
            bool booResult = false;
            string strConsulta = string.Empty;
            cDataBase cDatabase = new cDataBase();
            #endregion Vars

            try
            {
                strConsulta = string.Format("INSERT INTO [Riesgos].[RiesgosIndicadores] ([NombreIndicador],[ObjetivoIndicador],[IdResponsableMedicion],[IdFrecuenciaMedicion],[UsuarioCreacion],[FechaCreacion],[Activo])" +
                    "VALUES('{0}','{1}',{2},{3},{4},GETDATE(),1) ", objIndicador.strNombreIndicador, objIndicador.strObjetivoIndicador, objIndicador.intIdResponsableMedicion, objIndicador.intIdFrecuenciaMedicion, objIndicador.intUsuarioCreacion
                    );

                cDatabase.conectar();
                cDatabase.ejecutarQuery(strConsulta);
                booResult = true;
            }
            catch (Exception ex)
            {
                strErrMsg = string.Format("Error al crear el indicador del riesgo. [{0}]", ex.Message);
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
                strConsulta = string.Format("SELECT max([IdRiesgoIndicador]) as LastId FROM [Riesgos].[RiesgosIndicadores]");

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
        public bool mtdActualizaProcesoIndicador(clsDTOriesgosIndicadores objIndicador, ref string strErrMsg)
        {
            #region Vars
            bool booResult = false;
            string strConsulta = string.Empty;
            cDataBase cDatabase = new cDataBase();
            #endregion Vars

            try
            {
                strConsulta = string.Format("UPDATE [Riesgos].[RiesgosIndicadores] SET [IdProcesoIndicador] = {0} WHERE IdRiesgoIndicador = {1}"
                    , objIndicador.intIProcesoIndicador, objIndicador.intIdRiesgoIndicador
                    );

                cDatabase.conectar();
                cDatabase.ejecutarQuery(strConsulta);
                booResult = true;
            }
            catch (Exception ex)
            {
                strErrMsg = string.Format("Error al crear el indicador del riesgo. [{0}]", ex.Message);
                booResult = false;
            }
            finally
            {
                cDatabase.desconectar();
            }

            return booResult;
        }
        public bool mtdConsultarRiesgosIndicadores(ref DataTable dtCaracOut, ref string strErrMsg)
        {
            #region Vars
            bool booResult = false;
            string strConsulta = string.Empty;
            cDataBase cDataBase = new cDataBase();
            #endregion Vars

            try
            {
                strConsulta = string.Format("SELECT [IdRiesgoIndicador],[NombreIndicador],[ObjetivoIndicador],[IdProcesoIndicador]"
                    + ",[IdProceso],[NombreProceso],[IdResponsableMedicion],[NombreHijo],[IdFrecuenciaMedicion],[FrecuenciaMedicion],[IdRiesgoAsociado],"
                    + "[Codigo],[Nombre],[IdFormula],[Nominador],[Denominador],[IdMeta],[Meta],[IdEsquemaSeguimiento],[ValorMinimo]"
                    + ",[ValorMaximo],[DescripcionSeguimiento],[Usuario],[FechaCreacion],[Activo],porcentaje"
                    + " FROM [Riesgos].[vwRiesgosIndicadoresCreate]"
                    );

                cDataBase.conectar();
                dtCaracOut = cDataBase.ejecutarConsulta(strConsulta);
                booResult = true;
            }
            catch (Exception ex)
            {
                strErrMsg = string.Format("Error al consultar los indicadores de riesgos. [{0}]", ex.Message);
                booResult = false;
            }
            finally
            {
                cDataBase.desconectar();
            }

            return booResult;
        }
        public bool mtdConsultarRiesgosIndicadores(ref DataTable dtCaracOut, ref string strErrMsg, string CodRiesgo, int IdProceso, int Responsable, int IdFactorRiesgo)
        {
            #region Vars
            bool booResult = false;
            string strConsulta = string.Empty;
            cDataBase cDataBase = new cDataBase();
            string condicion = string.Empty;
            #endregion Vars

            try
            {
                if (!string.IsNullOrEmpty(CodRiesgo))
                {

                    string texto = CodRiesgo;
                    Match m = Regex.Match(texto, "(\\d+)");
                    string num = string.Empty;

                    if (m.Success)
                    {
                        num = m.Value;
                    }

                    

                    //string aux = CodRiesgo.Replace("R", string.Empty);
                    // aux = aux.Replace("r", string.Empty);
                    //CodRiesgo.Replace("R", string.Empty);
                    //CodRiesgo.Replace("r", string.Empty);


                    condicion = string.Format(" and ( b.IdRiesgoAsociado = {0})", num);

                    //condicion = string.Format(" and ( Codigo = '{0}')", CodRiesgo);

                }
                if (IdProceso != 0)
                {
                    if (string.IsNullOrEmpty(condicion))
                    {
                        condicion = string.Format(" and ( a.IdProceso = {0})", IdProceso);
                    }
                    else
                    {
                        condicion += string.Format(" AND (a.IdProceso = {0})", IdProceso);
                    }
                }
                if (Responsable != 0)
                {
                    if (string.IsNullOrEmpty(condicion))
                    {
                        condicion = string.Format(" and (a.IdResponsableMedicion = {0})", Responsable);
                    }
                    else
                    {
                        condicion += string.Format(" AND (a.IdResponsableMedicion = {0})", Responsable);
                    }
                }
                if (IdFactorRiesgo != 0)
                {
                    if (string.IsNullOrEmpty(condicion))
                    {
                        condicion = string.Format(" and (a.IdClasificacionRiesgo = {0})", IdFactorRiesgo);
                    }
                    else
                    {
                        condicion += string.Format(" AND (a.IdClasificacionRiesgo = {0})", IdFactorRiesgo);
                    }
                }
                //strConsulta = string.Format("SELECT [IdRiesgoIndicador],[NombreIndicador],[ObjetivoIndicador],[IdProcesoIndicador]"
                //    + ",[IdProceso],[NombreProceso],[IdResponsableMedicion],[NombreHijo],[IdFrecuenciaMedicion],[FrecuenciaMedicion],[Descripcion],[IdRiesgoAsociado],"
                //    + "[Codigo],[Nombre],[IdFormula],[Nominador],[Denominador],[IdMeta],[Meta],[IdEsquemaSeguimiento],[ValorMinimo]"
                //    + ",[ValorMaximo],[DescripcionSeguimiento],[Usuario],[FechaCreacion],[Activo],[IdClasificacionRiesgo], Año, mes, porcentaje"
                //    + " FROM [Riesgos].[vwRiesgosIndicadores] where Activo = 1 {0}", condicion
                //    );

                


                strConsulta = string.Format("SELECT a.[IdRiesgoIndicador],a.[NombreIndicador],a.[ObjetivoIndicador],a.[IdProcesoIndicador],a.[IdProceso],a.[NombreProceso],a.[IdResponsableMedicion],a.[NombreHijo],a.[IdFrecuenciaMedicion],a.[FrecuenciaMedicion],a.[Descripcion],a.[IdRiesgoAsociado],a.[Codigo],a.[Nombre],a.[IdFormula],a.[Nominador],a.[Denominador],a.[IdMeta],a.[Meta],a.[IdEsquemaSeguimiento],a.[ValorMinimo],a.[ValorMaximo],a.[DescripcionSeguimiento],a.[Usuario],a.[FechaCreacion],a.[Activo],a.[IdClasificacionRiesgo], a.Año,a.mes, a.porcentaje, c.[ValorOtraFrecuencia],d.[Codigo] as CodRiesgo"
+ " FROM[Riesgos].[vwRiesgosIndicadores] as a"
+ " left join[Riesgos].[RiesgosIndicadoresAsociados] as b on(a.IdRiesgoIndicador = b.IdIndicador)"
+ "left join [Riesgos].[Riesgo]as d on(b.IdRiesgoAsociado=d.IdRiesgo)"
+ " inner join[Riesgos].[RiesgosIndicadoresMetas] as c on a.IdMeta = c.IdMeta where a.Activo = 1 {0} ", condicion
                    );

                //strConsulta = string.Format("SELECT a.[IdRiesgoIndicador],a.[NombreIndicador],a.[ObjetivoIndicador],a.[IdProcesoIndicador]"
                //    + ",a.[IdProceso],a.[NombreProceso],a.[IdResponsableMedicion],a.[NombreHijo],a.[IdFrecuenciaMedicion],a.[FrecuenciaMedicion],a.[Descripcion],a.[IdRiesgoAsociado],"
                //    + "a.[Codigo],a.[Nombre],a.[IdFormula],a.[Nominador],a.[Denominador],a.[IdMeta],a.[Meta],a.[IdEsquemaSeguimiento],a.[ValorMinimo]"
                //    + ",a.[ValorMaximo],a.[DescripcionSeguimiento],a.[Usuario],a.[FechaCreacion],a.[Activo],a.[IdClasificacionRiesgo], a.Año,a.mes, a.porcentaje"
                //    + " FROM [Riesgos].[vwRiesgosIndicadores] as a inner join [Riesgos].[RiesgosIndicadoresAsociados] as b on(a.IdRiesgoIndicador=b.IdIndicador) where Activo = 1 {0}  ", condicion
                //    );

                cDataBase.conectar();
                dtCaracOut = cDataBase.ejecutarConsulta(strConsulta);
                booResult = true;
            }
            catch (Exception ex)
            {
                strErrMsg = string.Format("Error al consultar los indicadores de riesgos. [{0}]", ex.Message);
                booResult = false;
            }
            finally
            {
                cDataBase.desconectar();
            }

            return booResult;
        }

        public bool mtdConsultarRiesgosIndicadores(ref DataTable dtCaracOut, ref string strErrMsg, string CodRiesgo)
        {
            #region Vars
            bool booResult = false;
            string strConsulta = string.Empty;
            cDataBase cDataBase = new cDataBase();
            #endregion Vars

            try
            {
                strConsulta = $"SELECT * FROM Riesgos.vwRiesgosIndicadoresAsociados WHERE Codigo = '{CodRiesgo}'";

                cDataBase.conectar();
                dtCaracOut = cDataBase.ejecutarConsulta(strConsulta);
                booResult = true;
            }
            catch (Exception ex)
            {
                strErrMsg = string.Format("Error al consultar los indicadores de riesgos. [{0}]", ex.Message);
                booResult = false;
            }
            finally
            {
                cDataBase.desconectar();
            }

            return booResult;
        }
        public bool mtdActualizaRiesgoIndicador(clsDTOriesgosIndicadores objIndicador, ref string strErrMsg)
        {
            #region Vars
            bool booResult = false;
            string strConsulta = string.Empty;
            cDataBase cDatabase = new cDataBase();
            #endregion Vars

            try
            {
                strConsulta = string.Format("UPDATE [Riesgos].[RiesgosIndicadores] SET [NombreIndicador] ='{0}',[ObjetivoIndicador] ='{1}'"
                    + ",[IdResponsableMedicion] ={2},[IdFrecuenciaMedicion] ={3}"
                    + " WHERE IdRiesgoIndicador = {4}"
                    , objIndicador.strNombreIndicador, objIndicador.strObjetivoIndicador, objIndicador.intIdResponsableMedicion, objIndicador.intIdFrecuenciaMedicion,
                    objIndicador.intIdRiesgoIndicador
                    );

                cDatabase.conectar();
                cDatabase.ejecutarQuery(strConsulta);
                booResult = true;
            }
            catch (Exception ex)
            {
                strErrMsg = string.Format("Error al crear el indicador del riesgo. [{0}]", ex.Message);
                booResult = false;
            }
            finally
            {
                cDatabase.desconectar();
            }

            return booResult;
        }
        public bool mtdAsociarRiesgoIndicador(clsDTOriesgosIndicadores objIndicador, ref string strErrMsg)
        {
            #region Vars
            bool booResult = false;
            string strConsulta = string.Empty;
            cDataBase cDatabase = new cDataBase();
            #endregion Vars

            try
            {
                //strConsulta = string.Format("UPDATE [Riesgos].[RiesgosIndicadores] SET [IdRiesgoAsociado] = {0} WHERE IdRiesgoIndicador = {1}"
                //    , objIndicador.intIdRiesgoAsociado, objIndicador.intIdRiesgoIndicador
                //    );

                strConsulta = string.Format("INSERT INTO [Riesgos].[RiesgosIndicadoresAsociados] (IdIndicador, IdRiesgoAsociado " +
                    ") VALUES ({0}, {1})"
                    , objIndicador.intIdRiesgoIndicador, objIndicador.intIdRiesgoAsociado);

                cDatabase.conectar();
                cDatabase.ejecutarQuery(strConsulta);
                booResult = true;
            }
            catch (Exception ex)
            {
                strErrMsg = string.Format("Error al asociar el riesgo al indicador. [{0}]", ex.Message);
                booResult = false;
            }
            finally
            {
                cDatabase.desconectar();
            }

            return booResult;
        }
        public bool mtdConsultarRiesgosAsociado(ref DataTable dtCaracOut, ref string strErrMsg, int IdRiesgoIndicador)
        {
            #region Vars
            bool booResult = false;
            string strConsulta = string.Empty;
            cDataBase cDataBase = new cDataBase();
            #endregion Vars

            try
            {
                strConsulta = string.Format("SELECT RRI.IdIndicador as IdRiesgoIndicador,RRI.IdRiesgoAsociado, RR.Codigo, " +
                    "RR.Nombre FROM [Riesgos].[RiesgosIndicadoresAsociados] as " +
                    "RRI INNER JOIN [Riesgos].Riesgo as RR on RR.IdRiesgo = RRI.IdRiesgoAsociado"
                    + " WHERE RRI.IdIndicador = {0}"
                    , IdRiesgoIndicador
                    );

                cDataBase.conectar();
                dtCaracOut = cDataBase.ejecutarConsulta(strConsulta);
                booResult = true;
            }
            catch (Exception ex)
            {
                strErrMsg = string.Format("Error al consultar los indicadores de riesgos. [{0}]", ex.Message);
                booResult = false;
            }
            finally
            {
                cDataBase.desconectar();
            }

            return booResult;
        }
        public bool mtdDesasociarRiesgoIndicador(clsDTOriesgosIndicadores objIndicador, ref string strErrMsg)
        {
            #region Vars
            bool booResult = false;
            string strConsulta = string.Empty;
            cDataBase cDatabase = new cDataBase();
            #endregion Vars

            try
            {
                //strConsulta = string.Format("UPDATE [Riesgos].[RiesgosIndicadores] SET [IdRiesgoAsociado] = NULL WHERE IdRiesgoIndicador = {0}"
                //    , objIndicador.intIdRiesgoIndicador
                //    );

                strConsulta = string.Format("DELETE FROM [Riesgos].[RiesgosIndicadoresAsociados] WHERE IdRiesgoAsociado = {0}"
                    , objIndicador.intIdRiesgoAsociado
                    );

                cDatabase.conectar();
                cDatabase.ejecutarQuery(strConsulta);
                booResult = true;
            }
            catch (Exception ex)
            {
                strErrMsg = string.Format("Error al desasociar el riesgo al indicador. [{0}]", ex.Message);
                booResult = false;
            }
            finally
            {
                cDatabase.desconectar();
            }

            return booResult;
        }
        public bool mtdActualizaEstadoRiesgoIndicador(clsDTOriesgosIndicadores objIndicador, ref string strErrMsg)
        {
            #region Vars
            bool booResult = false;
            string strConsulta = string.Empty;
            cDataBase cDatabase = new cDataBase();
            #endregion Vars

            try
            {
                strConsulta = string.Format("UPDATE [Riesgos].[RiesgosIndicadores] SET [Activo] ='{0}'"
                    + " WHERE IdRiesgoIndicador = {1}"
                    , objIndicador.booActivo, objIndicador.intIdRiesgoIndicador
                    );

                cDatabase.conectar();
                cDatabase.ejecutarQuery(strConsulta);
                booResult = true;
            }
            catch (Exception ex)
            {
                strErrMsg = string.Format("Error al crear el indicador del riesgo. [{0}]", ex.Message);
                booResult = false;
            }
            finally
            {
                cDatabase.desconectar();
            }

            return booResult;
        }
        public bool mtdActualizaMetaRiesgoIndicador(clsDTOriesgosIndicadores objIndicador, ref string strErrMsg)
        {
            #region Vars
            bool booResult = false;
            string strConsulta = string.Empty;
            cDataBase cDatabase = new cDataBase();
            #endregion Vars

            try
            {
                strConsulta = string.Format("UPDATE [Riesgos].[RiesgosIndicadores] SET [IdMeta] ='{0}'"
                    + " WHERE IdRiesgoIndicador = {1}"
                    , objIndicador.intIdMeta, objIndicador.intIdRiesgoIndicador
                    );

                cDatabase.conectar();
                cDatabase.ejecutarQuery(strConsulta);
                booResult = true;
            }
            catch (Exception ex)
            {
                strErrMsg = string.Format("Error al crear la meta del riesgo. [{0}]", ex.Message);
                booResult = false;
            }
            finally
            {
                cDatabase.desconectar();
            }

            return booResult;
        }
        public bool mtdActualizaFormulaRiesgoIndicador(clsDTOriesgosIndicadores objIndicador, ref string strErrMsg)
        {
            #region Vars
            bool booResult = false;
            string strConsulta = string.Empty;
            cDataBase cDatabase = new cDataBase();
            #endregion Vars

            try
            {
                strConsulta = string.Format("UPDATE [Riesgos].[RiesgosIndicadores] SET [IdFormula] ='{0}'"
                    + " WHERE IdRiesgoIndicador = {1}"
                    , objIndicador.intIdFormula, objIndicador.intIdRiesgoIndicador
                    );

                cDatabase.conectar();
                cDatabase.ejecutarQuery(strConsulta);
                booResult = true;
            }
            catch (Exception ex)
            {
                strErrMsg = string.Format("Error al crear la formula del riesgo. [{0}]", ex.Message);
                booResult = false;
            }
            finally
            {
                cDatabase.desconectar();
            }

            return booResult;
        }
        public bool mtdActualizaSeguimientoRiesgoIndicador(clsDTOriesgosIndicadores objIndicador, ref string strErrMsg)
        {
            #region Vars
            bool booResult = false;
            string strConsulta = string.Empty;
            cDataBase cDatabase = new cDataBase();
            #endregion Vars

            try
            {
                strConsulta = string.Format("UPDATE [Riesgos].[RiesgosIndicadores] SET [IdEsquemaSeguimiento] ='{0}'"
                    + " WHERE IdRiesgoIndicador = {1}"
                    , objIndicador.intIdEsquemaSeguimiento, objIndicador.intIdRiesgoIndicador
                    );

                cDatabase.conectar();
                cDatabase.ejecutarQuery(strConsulta);
                booResult = true;
            }
            catch (Exception ex)
            {
                strErrMsg = string.Format("Error al crear el seguimiento del riesgo. [{0}]", ex.Message);
                booResult = false;
            }
            finally
            {
                cDatabase.desconectar();
            }

            return booResult;
        }
        public bool mtdConsultarRiesgosIndicadoresGestion(ref DataTable dtCaracOut, ref string strErrMsg, int IdUsuario, string Responsable)
        {
            #region Vars
            bool booResult = false;
            string strConsulta = string.Empty;
            cDataBase cDataBase = new cDataBase();
            string TipoArea = string.Empty;
            #endregion Vars

            try
            {
                strConsulta = string.Format("SELECT PJO.TipoArea FROM Parametrizacion.JerarquiaOrganizacional AS PJO"
                    + " INNER JOIN Listas.Usuarios AS Luser on Luser.IdJerarquia = PJO.idHijo"
                    + " WHERE Luser.IdUsuario = {0}", IdUsuario);
                cDataBase.conectar();
                dtCaracOut = cDataBase.ejecutarConsulta(strConsulta);
                cDataBase.desconectar();
                TipoArea = dtCaracOut.Rows[0]["TipoArea"].ToString().Trim();
                if (TipoArea == "R")
                {
                    if (Responsable != "")
                    {
                        strConsulta = string.Format("SELECT [IdRiesgoIndicador],[NombreIndicador],[ObjetivoIndicador],[IdProcesoIndicador]"
                            + ",[IdProceso],[NombreProceso],[IdResponsableMedicion],[NombreHijo],[IdFrecuenciaMedicion],[FrecuenciaMedicion],[IdRiesgoAsociado],"
                            + "[Codigo],[Nombre],[IdFormula],[Nominador],[Denominador],[IdMeta],[Meta],[IdEsquemaSeguimiento],[ValorMinimo]"
                            + ",[ValorMaximo],[DescripcionSeguimiento],[Usuario],[FechaCreacion],[Activo],[IdUsuario]"
                            + " FROM [Riesgos].[vwRiesgosIndicadoresCreate] where Activo = 1 and IdResponsableMedicion = {0}", Responsable
                            );
                    }
                    else
                    {
                        strConsulta = string.Format("SELECT [IdRiesgoIndicador],[NombreIndicador],[ObjetivoIndicador],[IdProcesoIndicador]"
                            + ",[IdProceso],[NombreProceso],[IdResponsableMedicion],[NombreHijo],[IdFrecuenciaMedicion],[FrecuenciaMedicion],[IdRiesgoAsociado],"
                            + "[Codigo],[Nombre],[IdFormula],[Nominador],[Denominador],[IdMeta],[Meta],[IdEsquemaSeguimiento],[ValorMinimo]"
                            + ",[ValorMaximo],[DescripcionSeguimiento],[Usuario],[FechaCreacion],[Activo],[IdUsuario]"
                            + " FROM [Riesgos].[vwRiesgosIndicadoresCreate] where Activo = 1");
                    }
                }
                else
                {
                    if (Responsable != "")
                    {
                        strConsulta = string.Format("SELECT [IdRiesgoIndicador],[NombreIndicador],[ObjetivoIndicador],[IdProcesoIndicador]"
                                                + ",[IdProceso],[NombreProceso],[IdResponsableMedicion],[NombreHijo],[IdFrecuenciaMedicion],[FrecuenciaMedicion],[IdRiesgoAsociado],"
                                                + "[Codigo],[Nombre],[IdFormula],[Nominador],[Denominador],[IdMeta],[Meta],[IdEsquemaSeguimiento],[ValorMinimo]"
                                                + ",[ValorMaximo],[DescripcionSeguimiento],[Usuario],[FechaCreacion],[Activo],[IdUsuario]"
                                                + " FROM [Riesgos].[vwRiesgosIndicadoresCreate] " +
                                                //"where IdUsuario = {0} and Activo = 1", IdUsuario
                                                "where Activo = 1 and IdResponsableMedicion = {0}", Responsable
                                                );
                    }
                    else
                    {
                        strConsulta = string.Format("SELECT [IdRiesgoIndicador],[NombreIndicador],[ObjetivoIndicador],[IdProcesoIndicador]"
                                                + ",[IdProceso],[NombreProceso],[IdResponsableMedicion],[NombreHijo],[IdFrecuenciaMedicion],[FrecuenciaMedicion],[IdRiesgoAsociado],"
                                                + "[Codigo],[Nombre],[IdFormula],[Nominador],[Denominador],[IdMeta],[Meta],[IdEsquemaSeguimiento],[ValorMinimo]"
                                                + ",[ValorMaximo],[DescripcionSeguimiento],[Usuario],[FechaCreacion],[Activo],[IdUsuario]"
                                                + " FROM [Riesgos].[vwRiesgosIndicadoresCreate] " +
                                                //"where IdUsuario = {0} and Activo = 1", IdUsuario
                                                "where Activo = 1", IdUsuario
                                                );
                    }
                }
                cDataBase.conectar();
                dtCaracOut = cDataBase.ejecutarConsulta(strConsulta);
                booResult = true;
            }
            catch (Exception ex)
            {
                strErrMsg = string.Format("Error al consultar los indicadores de riesgos. [{0}]", ex.Message);
                booResult = false;
            }
            finally
            {
                cDataBase.desconectar();
            }

            return booResult;
        }
    }
}