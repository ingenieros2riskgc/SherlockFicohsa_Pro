using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace ListasSarlaft.Classes
{
    public class cEvsEIncs : cPropiedades
    {

        private cDataBase cDataBase = new cDataBase();
        private cError cError = new cError();

        #region Guardar

        private string CrearEvsEIncs()
        {

            string insertedId = "";
            try
            {
                DataTable dtInformacion = new DataTable();
                cDataBase.conectar();
                dtInformacion = cDataBase.ejecutarConsulta("INSERT INTO [Riesgos].[EventosIncidentes] (CodigoEvsEIncs) OUTPUT Inserted.IdEvsEIncs VALUES ('EEx')");
                cDataBase.desconectar();

                insertedId = dtInformacion.Rows[0]["IdEvsEIncs"].ToString().Trim();

            }
            catch (Exception ex)
            {
                cDataBase.desconectar();
                cError.errorMessage(ex.Message + ", " + ex.StackTrace);
                throw new Exception(ex.Message);
            }
            return insertedId;
        }

        private string GenerarDataKeyValue(string key, string value)
        {
            string IsFecha = key.Substring(0, 5);
            string KeyValue = " [" + key + "] = '" + value + "',";            
            if (IsFecha.Equals("Fecha") && value.Equals(""))
            {
                KeyValue = " [" + key + "] = NULL ,";
            }

            return KeyValue;
        }

        private string ActualizarEvsEIncs(Dictionary<string, object> Variables, string IdEvsEIncs)
        {
            string Consulta = "";
            try
            {
                Consulta = "UPDATE [Riesgos].[EventosIncidentes] SET";

                foreach (var data in Variables)
                    Consulta += GenerarDataKeyValue(data.Key, data.Value.ToString());

                Consulta = Consulta.TrimEnd(',');

                Consulta += " WHERE IdEvsEIncs ='" + IdEvsEIncs + "'";

                cDataBase.conectar();
                cDataBase.ejecutarQuery(Consulta);
                cDataBase.desconectar();
            }
            catch (Exception ex)
            {
                cDataBase.desconectar();
                cError.errorMessage(ex.Message + ", " + ex.StackTrace);
                throw new Exception(Consulta);
            }

            return Consulta;
        }


        public string ModificarEvsEIncs(
                string idEvsEIncs,
                string DDLFuenteReporte,
                string DDLRiesgoGlobal,
                string DDLEstadoReporte,
                string DDLCodigoBanco,
                string TBFechaOcurrencia,
                string TBFechaDescubrimiento,
                string TBDescripcionEvento,
                string TBTituloEvento,
                string DDLCategoria,
                string DDLModalidad,
                string DDLFiltroLineaUno,
                string DDLLineaNegocioUno,
                string DDLFiltroLineaDos,
                string DDLLineaNegocioDos,
                string DDLTipoRiesgo,
                string DDLCausaRiesgoUno,
                string DDLCausaRiesgoDos,
                string DDLFactorRO,
                string DDLOrigen,
                string DDLProductoAfectado,
                string TBMontoBruto,
                string TBMontoExposicion,
                string DDLCuentasPerdida,
                string TBFRegistroPerdida,
                string TBRecuperacionSeguro,
                string TBRecuperaciones,
                string TBCuentaRecuperacion,
                string TBFRegistroContable,
                string TBValorFrecuencia,
                string DDLCriticidad,
                string DDLCriticidadSeveridadNota,
                string DDLCriticidadFrecuencia,
                string DDLCriticidadSeveridad,
                string DDLEstatus,
                string TBFCierre,
                string TBNotas,
                string TBJustificacion)
        {

            string consulta = "";
            try
            {
                var Variables = new Dictionary<string, object>();

                Variables.Add("IdFuenteReporte", DDLFuenteReporte);
                Variables.Add("IdRiesgoGlobal", DDLRiesgoGlobal);
                Variables.Add("IdEstadoReporte", DDLEstadoReporte);
                Variables.Add("IdCodigoBanco", DDLCodigoBanco);
                Variables.Add("FechaOcurrencia", TBFechaOcurrencia);
                Variables.Add("FechaDescubrimiento", TBFechaDescubrimiento);
                Variables.Add("DescripcionEvento", TBDescripcionEvento);
                Variables.Add("TituloEvento", TBTituloEvento);
                Variables.Add("IdCategoria", DDLCategoria);
                Variables.Add("IdModalidadOcurrencia", DDLModalidad);
                Variables.Add("IdFiltroLineaUno", DDLFiltroLineaUno);
                Variables.Add("IdFiltroDosLineaUno", DDLLineaNegocioUno);
                Variables.Add("IdFiltroLineaDos", DDLFiltroLineaDos);
                Variables.Add("IdFiltroDosLineaDos", DDLLineaNegocioDos);
                Variables.Add("IdTipoRiesgo", DDLTipoRiesgo);
                Variables.Add("IdCausaRiesgoN1", DDLCausaRiesgoUno);
                Variables.Add("IdCausaRiesgoN2", DDLCausaRiesgoDos);
                Variables.Add("IdFactorRO", DDLFactorRO);
                Variables.Add("IdOrigen", DDLOrigen);
                Variables.Add("IdProductoAfectado", DDLProductoAfectado);
                Variables.Add("MontoBruto", TBMontoBruto.Replace(',', '.'));
                Variables.Add("MontoExposicion", TBMontoExposicion.Replace(',', '.'));
                Variables.Add("NEventos", TBValorFrecuencia);
                Variables.Add("IdCuentasPerdida", DDLCuentasPerdida);
                Variables.Add("FechaRegistroPerdida", TBFRegistroPerdida);
                Variables.Add("RecuperacionSeguro", TBRecuperacionSeguro.Replace(',', '.'));
                Variables.Add("Recuperaciones", TBRecuperaciones.Replace(',', '.'));
                Variables.Add("CuentaRecuperacion", TBCuentaRecuperacion);
                Variables.Add("FechaRegistroContable", TBFRegistroContable);
                Variables.Add("IdCritFrecuenciaG", DDLCriticidad);
                Variables.Add("IdCritSeveridadG", DDLCriticidadSeveridadNota);
                Variables.Add("IdCritFrecuenciaE", DDLCriticidadFrecuencia);
                Variables.Add("IdCritSeveridadE", DDLCriticidadSeveridad);
                Variables.Add("IdEstatus", DDLEstatus);
                Variables.Add("FechaCierre", TBFCierre);
                Variables.Add("Notas", TBNotas);                                

                if (idEvsEIncs.Equals(""))
                {
                    Variables.Add("FechaRegistro", DateNow);
                    idEvsEIncs = CrearEvsEIncs();
                    Variables.Add("CodigoEvsEIncs", "EI" + idEvsEIncs);
                    Variables.Add("IdUsuarioRegistro", IdUsuario);
                }

                ActualizarEvsEIncs(Variables, idEvsEIncs);

                //Guardando Justificación
                if (!TBJustificacion.Equals(""))
                {
                    consulta = $"INSERT INTO Eventos.EvsEIncs_Justificacion VALUES ('{idEvsEIncs}', '{TBJustificacion}', '{DateNow}', '{IdUsuario}')";
                    cDataBase.conectar();
                    cDataBase.ejecutarConsulta(consulta);
                    cDataBase.desconectar();
                }
            }
            catch (Exception ex)
            {
                cDataBase.desconectar();
                cError.errorMessage(ex.Message + ", " + ex.StackTrace);
                throw new Exception(ex.Message + consulta);
            }

            return idEvsEIncs;
        }

        public void GuardarArchivo(string IdEvsEIncs, string strUrlArchivo, byte[] bPdfData)
        {
            string Consulta = "";
            try
            {
                Consulta = $"INSERT INTO Eventos.Archivos " +
                    $"([IdEvsEincs], [UrlArchivo], [ArchivoPDF], [IdUsuario], [FechaRegistro]) " +
                    $"VALUES ('{IdEvsEIncs}', '{strUrlArchivo}',  @PdfData, '{IdUsuario}', '{DateNow}')";

                cDataBase.mtdConectarSql();
                cDataBase.mtdEjecutarConsultaSQL(Consulta, bPdfData);
                cDataBase.mtdDesconectarSql();
            }
            catch (Exception ex)
            {
                cDataBase.mtdDesconectarSql();
                cError.errorMessage(ex.Message + ", " + ex.StackTrace);
                throw new Exception(ex.Message);
            }
        }


        public void GuardarJustificacionanezaplan(string IdEvsEIncs, string justificacion, string idusuario)
        {
            string Consulta = "";
            try
            {
                Consulta = $"INSERT INTO Eventos.EvsEIncs_Justificacion VALUES ('{IdEvsEIncs}', '{justificacion}', '{DateNow}', '{idusuario}')";

                cDataBase.conectar();
                cDataBase.ejecutarConsulta(Consulta);
                cDataBase.desconectar();
            }
            catch (Exception ex)
            {
                cDataBase.mtdDesconectarSql();
                cError.errorMessage(ex.Message + ", " + ex.StackTrace);
                throw new Exception(ex.Message);
            }
        }


        public void RelacionarPlanes(string idEvsEIncs, string IdPlan)
        {
            try
            {
                if (!idEvsEIncs.Equals(""))
                {
                    List<SqlParameter> parametros = new List<SqlParameter>()
                    {
                        new SqlParameter() { ParameterName = "@IdEvsEIncs", SqlDbType = SqlDbType.Int, Value = idEvsEIncs },
                        new SqlParameter() { ParameterName = "@IdPlan", SqlDbType = SqlDbType.Int, Value = IdPlan },
                        new SqlParameter() { ParameterName = "@IdUsuario", SqlDbType = SqlDbType.Int, Value = IdUsuario },
                        new SqlParameter() { ParameterName = "@DateNow", SqlDbType = SqlDbType.DateTime, Value = System.DateTime.Now }
                    };

                    cDataBase.EjecutarSPParametrosReturnDatatable("[Riesgos].[DesEnlazarPlanes]", parametros);
                }
                else
                {
                    throw new Exception("Evento no guardado");
                }
            }
            catch (Exception ex)
            {
                cDataBase.desconectar();
                cError.errorMessage(ex.Message + ", " + ex.StackTrace);
                throw new Exception(ex.Message + DateNow);
            }
        }
        public string RelacionarRiesgos(string idEvsEIncs, string IdRiesgo)
        {
            DataTable dtInformacion = new DataTable();
            try
            {
                if (!idEvsEIncs.Equals("0"))
                {
                    List<SqlParameter> parametros = new List<SqlParameter>()
                    {
                        new SqlParameter() { ParameterName = "@IdEvsEIncs", SqlDbType = SqlDbType.Int, Value = idEvsEIncs },
                        new SqlParameter() { ParameterName = "@IdRiesgo", SqlDbType = SqlDbType.Int, Value = IdRiesgo },
                    };

                    dtInformacion = cDataBase.EjecutarSPParametrosReturnDatatable("[Riesgos].[DesEnlazarRiesgo]", parametros);

                    if (dtInformacion.Rows.Count > 0)
                        return dtInformacion.Rows[0]["Resultado"].ToString().Trim();
                    else return "";
                }
                else
                {
                    throw new Exception("Riesgo no guardado");
                }
            }
            catch (Exception ex)
            {
                cDataBase.desconectar();
                cError.errorMessage(ex.Message + ", " + ex.StackTrace);
                throw new Exception(ex.Message);
            }
        }

        public void RelacionarProcesoOriginador(string idEvsEIncs, string IdProceso)
        {
            try
            {
                if (!idEvsEIncs.ToString().Equals("0"))
                {
                    List<SqlParameter> parametros = new List<SqlParameter>()
                    {
                        new SqlParameter() { ParameterName = "@IdEvsEIncs", SqlDbType = SqlDbType.Int, Value = idEvsEIncs },
                        new SqlParameter() { ParameterName = "@IdProceso", SqlDbType = SqlDbType.Int, Value = IdProceso },
                        new SqlParameter() { ParameterName = "@IdUsuario", SqlDbType = SqlDbType.Int, Value = IdUsuario },
                        new SqlParameter() { ParameterName = "@DateNow", SqlDbType = SqlDbType.DateTime, Value = System.DateTime.Now }
                    };

                    cDataBase.EjecutarSPParametrosReturnDatatable("[Riesgos].[DesEnlazarProcesoOriginador]", parametros);
                }
                else
                {
                    throw new Exception("Evento no guardado");
                }
            }
            catch (Exception ex)
            {
                cDataBase.desconectar();
                cError.errorMessage(ex.Message + ", " + ex.StackTrace);
                throw new Exception(ex.Message);
            }
        }

        public void RelacionarProcesoAfectado(string idEvsEIncs, string IdProcesoAfectado)
        {
            try
            {
                if (!idEvsEIncs.ToString().Equals("0"))
                {
                    List<SqlParameter> parametros = new List<SqlParameter>()
                    {
                        new SqlParameter() { ParameterName = "@IdEvsEIncs", SqlDbType = SqlDbType.Int, Value = idEvsEIncs },
                        new SqlParameter() { ParameterName = "@IdProceso", SqlDbType = SqlDbType.Int, Value = IdProcesoAfectado },
                    };

                    cDataBase.EjecutarSPParametrosReturnDatatable("[Riesgos].[DesEnlazarProcesoAfectado]", parametros);
                }
                else
                {
                    throw new Exception("Proceso afectado no guardado");
                }
            }
            catch (Exception ex)
            {
                cDataBase.desconectar();
                cError.errorMessage(ex.Message + ", " + ex.StackTrace);
                throw new Exception(ex.Message);
            }
        }
        #endregion

        #region Loads

        public DataTable LoadAnios()
        {
            DataTable dtInformacion = new DataTable();
            try
            {
                cDataBase.conectar();
                dtInformacion = cDataBase.ejecutarConsulta("SELECT IdAnio, Anio FROM [Eventos].[Anios] ORDER BY IdAnio");
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
        public DataTable LoadDDLCodigoBanco()
        {
            DataTable dtInformacion = new DataTable();
            try
            {
                cDataBase.conectar();
                dtInformacion = cDataBase.ejecutarConsulta("SELECT IdCodigoBanco, Codigo FROM [Eventos].[CodigoBanco] ORDER BY IdCodigoBanco");
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

        public DataTable LoadDDLCategoria()
        {
            DataTable dtInformacion = new DataTable();
            try
            {
                cDataBase.conectar();
                dtInformacion = cDataBase.ejecutarConsulta("SELECT IdCategoria, Categoria FROM [Eventos].[Categoria] ORDER BY IdCategoria");
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

        public DataTable LoadDDLModalidad()
        {
            DataTable dtInformacion = new DataTable();
            try
            {
                cDataBase.conectar();
                dtInformacion = cDataBase.ejecutarConsulta("SELECT IdModalidad, Modalidad FROM [Eventos].[Modalidad] ORDER BY IdModalidad");
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
        public DataTable LoadDDLFuenteReporte()
        {
            DataTable dtInformacion = new DataTable();
            try
            {
                cDataBase.conectar();
                dtInformacion = cDataBase.ejecutarConsulta("SELECT IdFuenteReporte, Fuente FROM [Eventos].[FuenteReporte] ORDER BY IdFuenteReporte");
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

        public DataTable LoadDDLRiesgoGlobal()
        {
            DataTable dtInformacin = new DataTable();
            try
            {
                cDataBase.conectar();
                dtInformacin = cDataBase.ejecutarConsulta("SELECT IdClasificacionRiesgo, NombreClasificacionRiesgo AS 'RiesgoGlobal' FROM [Parametrizacion].[ClasificacionRiesgo] ORDER BY IdClasificacionRiesgo");
                cDataBase.desconectar();
            }
            catch (Exception ex)
            {
                cDataBase.desconectar();
                cError.errorMessage(ex.Message + ", " + ex.StackTrace);
                throw new Exception(ex.Message);
            }
            return dtInformacin;
        }
        public DataTable LoadDDLEstadoReporte()
        {
            DataTable dtInformacion = new DataTable();
            try
            {
                cDataBase.conectar();
                dtInformacion = cDataBase.ejecutarConsulta("SELECT IdEstadoReporte, EstadoReporte FROM [Eventos].[EstadoReporte] ORDER BY IdEstadoReporte");
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
        public DataTable LoadDDLCuentasPerdida()
        {
            DataTable dtInformacion = new DataTable();
            try
            {
                cDataBase.conectar();
                dtInformacion = cDataBase.ejecutarConsulta("SELECT IdCuentas, CONCAT(Nombre,' - ', Numero) as 'Descripcion' FROM [Eventos].[CuentasPerdida] ORDER BY IdCuentas");
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

        public DataTable LoadDescripcionLineas()
        {
            DataTable dtInformacion = new DataTable();
            try
            {
                cDataBase.conectar();
                dtInformacion = cDataBase.ejecutarConsulta("SELECT IdDescLineaUno, Descripcion FROM [Eventos].[DescLineaUno] ORDER BY IdDescLineaUno");
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

        public DataTable LoadDDLEstatus()
        {
            DataTable dtInformacion = new DataTable();
            try
            {
                cDataBase.conectar();
                dtInformacion = cDataBase.ejecutarConsulta("SELECT IdEstadoEvsEIncs, Estado FROM [Eventos].[EstadoEvsEIncs] ORDER BY IdEstadoEvsEIncs");
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

        public DataTable LoadCriticidadRiesgoByRiesgo(string IdRiesgo, int bConsultarLimite = 0)
        {            
            DataTable dtInformacion = new DataTable();
            try
            {

                List<SqlParameter> parametros = new List<SqlParameter>()
                {
                    new SqlParameter() { ParameterName = "@IdRiesgo", SqlDbType = SqlDbType.Int, Value = IdRiesgo },
                    new SqlParameter() { ParameterName = "@bConsultar", SqlDbType = SqlDbType.Int, Value = bConsultarLimite }
                };

                dtInformacion = cDataBase.EjecutarSPParametrosReturnDatatable("[Riesgos].[CriticidadesLimite]", parametros);

            }
            catch (Exception ex)
            {
                cDataBase.desconectar();
                cError.errorMessage(ex.Message + ", " + ex.StackTrace);
                throw new Exception(ex.Message);
            }
            return dtInformacion;
        }
        public DataTable LoadCriticidadRiesgoByEvento(string IdEvsEIncs)
        {
            DataTable dtInformacion = new DataTable();
            try
            {
                string Consulta = "SELECT TOP 1 ProbabilidadResidual, ImpactoResidual FROM [Riesgos].[vwDetalle] WHERE IdRiesgo = (SELECT IdRiesgo FROM Riesgos.EventosIncidentes rei WHERE rei.IdEvsEIncs = " + IdEvsEIncs + ") ";
                cDataBase.conectar();
                dtInformacion = cDataBase.ejecutarConsulta(Consulta);
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
        public DataTable LoadDDLTipoRiesgo()
        {
            DataTable dtInformacion = new DataTable();
            try
            {
                cDataBase.conectar();
                dtInformacion = cDataBase.ejecutarConsulta("SELECT IdTipoRiesgo, TipoRiesgo FROM [Eventos].[TipoRiesgo] ORDER BY IdTipoRiesgo");
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
        public DataTable LoadDDLProductoAfectado()
        {
            DataTable dtInformacion = new DataTable();
            try
            {
                cDataBase.conectar();
                dtInformacion = cDataBase.ejecutarConsulta("SELECT IdProductoAfectado, Producto FROM [Eventos].[ProductoAfectado] ORDER BY Producto");
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

        public DataTable loadDDLActivo(string IdTipoActivo)
        {
            DataTable dtInformacion = new DataTable();
            try
            {
                cDataBase.conectar();
                string consulta = "SELECT IdActivoAfectado, Activo FROM [Eventos].[ActivoAfectado] WHERE IdTipoActivo = " + IdTipoActivo + " ORDER BY IdActivoAfectado";
                dtInformacion = cDataBase.ejecutarConsulta(consulta);
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

        public DataTable LoadDDLDimValoracion()
        {
            DataTable dtInformacion = new DataTable();
            try
            {
                cDataBase.conectar();
                dtInformacion = cDataBase.ejecutarConsulta("SELECT IdDimValoracion, Dimensiones FROM [Eventos].[DimValoracion] ORDER BY IdDimValoracion");
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
        public DataTable LoadDDLRiesgo()
        {
            DataTable dtInformacion = new DataTable();
            try
            {
                cDataBase.conectar();
                dtInformacion = cDataBase.ejecutarConsulta("SELECT Codigo, IdRiesgo FROM [Riesgos].[Riesgo] ORDER BY IdRiesgo");
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

        public DataTable LoadDescripcionLineas(string IdLineaUno)
        {
            DataTable dtInformacion = new DataTable();
            try
            {
                cDataBase.conectar();
                string consulta = "SELECT IdDescLineaDos, Descripcion FROM [Eventos].[DescLineaDos] WHERE IdDescLineaUno = " + IdLineaUno + "  ORDER BY IdDescLineaDos";
                dtInformacion = cDataBase.ejecutarConsulta(consulta);
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

        public DataTable LoadDDLTipoActivo()
        {
            DataTable dtInformacion = new DataTable();
            try
            {
                cDataBase.conectar();
                string consulta = "SELECT IdTipoActivo, Tipo FROM [Eventos].[TipoActivo]  ORDER BY IdTipoActivo";
                dtInformacion = cDataBase.ejecutarConsulta(consulta);
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

        public DataTable LoadDDLFactorRO(string IdDesCausaNDos = "")
        {
            string consulta = "SELECT IdDesFactorRO, Descripcion FROM [Eventos].[DesFactorRO] ";
            DataTable dtInformacion = new DataTable();
            try
            {
                cDataBase.conectar();

                if (IdDesCausaNDos != "") consulta += "WHERE (SELECT IdDesFactorRO FROM [Eventos].[DesCausaNDos] WHERE IdDesCausaNDos = " + IdDesCausaNDos + ") = IdDesFactorRO";
                consulta += " ORDER BY IdDesFactorRO ";
                dtInformacion = cDataBase.ejecutarConsulta(consulta);
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

        public DataTable LoadDDLOrigen(string IdDesFactorRO)
        {
            DataTable dtInformacion = new DataTable();
            try
            {
                cDataBase.conectar();
                string consulta = "SELECT O.IdOrigen, O.Origen FROM Eventos.FactorRO_Origen AS FO INNER JOIN Eventos.Origen AS O ON FO.IdOrigen = O.IdOrigen WHERE FO.IdFactorRO = " + IdDesFactorRO;
                dtInformacion = cDataBase.ejecutarConsulta(consulta);
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
        public DataTable LoadDDLCausaRiesgoUno(string IdTipoRiesgo)
        {
            DataTable dtInformacion = new DataTable();
            string consulta = "";
            try
            {
                cDataBase.conectar();
                consulta = "SELECT IdDesCausaNUno, Descripcion FROM [Eventos].[DesCausaNUno] WHERE IdTipoRiesgo = " + IdTipoRiesgo + " ORDER BY IdDesCausaNUno";
                dtInformacion = cDataBase.ejecutarConsulta(consulta);
                cDataBase.desconectar();
            }
            catch (Exception ex)
            {
                cDataBase.desconectar();
                cError.errorMessage(ex.Message + ", " + ex.StackTrace);
                throw new Exception(consulta);
            }
            return dtInformacion;
        }

        public DataTable LoadDDLCausaRiesgoDos(string IdCausaRiesgoUno)
        {
            DataTable dtInformacion = new DataTable();
            try
            {
                cDataBase.conectar();
                string consulta = "SELECT IdDesCausaNDos, Descripcion FROM [Eventos].[DesCausaNDos] WHERE IdDesCausaNUno = " + IdCausaRiesgoUno + "  ORDER BY IdDesCausaNDos";
                dtInformacion = cDataBase.ejecutarConsulta(consulta);
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

        public DataTable LoadDDLProcesoOriginador()
        {
            DataTable dtInformacion = new DataTable();
            try
            {
                cDataBase.conectar();
                string consulta = "SELECT IdProceso, Nombre FROM [Procesos].[Proceso] ORDER BY IdProceso";
                dtInformacion = cDataBase.ejecutarConsulta(consulta);
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

        public DataTable LoadDDLProcesoAfectado()
        {
            DataTable dtInformacion = new DataTable();
            try
            {
                cDataBase.conectar();
                string consulta = "SELECT * FROM Procesos.vwDetalle";
                dtInformacion = cDataBase.ejecutarConsulta(consulta);
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

        public DataTable LoadDDLsDescFrecuencia()
        {
            DataTable dtInformacion = new DataTable();
            try
            {
                cDataBase.conectar();
                string consulta = "SELECT IdDescFrecuencia, DescripcionFicohsa FROM [Eventos].[DescFrecuencia] ORDER BY IdDescFrecuencia";
                dtInformacion = cDataBase.ejecutarConsulta(consulta);
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

        public DataTable LoadDDLBCadenaValor()
        {
            DataTable dtInformacion = new DataTable();
            try
            {
                cDataBase.conectar();
                string consulta = "SELECT IdCadenaValor, NombreCadenaValor FROM Procesos.CadenaValor ORDER BY IdCadenaValor";
                dtInformacion = cDataBase.ejecutarConsulta(consulta);
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
        public DataTable LoadDDLBMacroproceso()
        {
            DataTable dtInformacion = new DataTable();
            try
            {
                cDataBase.conectar();
                string consulta = "SELECT IdMacroproceso, Nombre FROM Procesos.Macroproceso ORDER BY IdMacroproceso";
                dtInformacion = cDataBase.ejecutarConsulta(consulta);
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
        public DataTable LoadDDLBMacroproceso(string IdCadenaValor)
        {
            DataTable dtInformacion = new DataTable();
            try
            {
                cDataBase.conectar();
                string consulta = "SELECT IdMacroproceso, Nombre FROM Procesos.Macroproceso WHERE IdCadenaValor = " + IdCadenaValor + " ORDER BY IdMacroproceso";
                dtInformacion = cDataBase.ejecutarConsulta(consulta);
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

        public DataTable LoadDDLBProceso(string IdMacroproceso)
        {
            DataTable dtInformacion = new DataTable();
            try
            {
                cDataBase.conectar();
                string consulta = "SELECT IdProceso, Nombre FROM Procesos.Proceso WHERE IdMacroProceso = " + IdMacroproceso + " ORDER BY IdProceso";
                dtInformacion = cDataBase.ejecutarConsulta(consulta);
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

        public DataTable LoadDDLBSubproceso(string IdProceso)
        {
            DataTable dtInformacion = new DataTable();
            try
            {
                cDataBase.conectar();
                string consulta = "SELECT IdSubproceso, Nombre FROM Procesos.Subproceso WHERE IdProceso = " + IdProceso + " ORDER BY IdSubproceso";
                dtInformacion = cDataBase.ejecutarConsulta(consulta);
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

        public DataTable LoadDDLBActividad(string IdSubproceso)
        {
            DataTable dtInformacion = new DataTable();
            try
            {
                cDataBase.conectar();
                string consulta = "SELECT IdActividad, Nombre FROM Procesos.Actividad WHERE IdSubproceso = " + IdSubproceso + " ORDER BY IdActividad";
                dtInformacion = cDataBase.ejecutarConsulta(consulta);
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

        public DataTable LoadDDLsDescSeveridad()
        {
            DataTable dtInformacion = new DataTable();
            try
            {
                cDataBase.conectar();
                string consulta = "SELECT IdDescSeveridad, DescripcionFicohsa FROM [Eventos].[DescSeveridad] ORDER BY IdDescSeveridad";
                dtInformacion = cDataBase.ejecutarConsulta(consulta);
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

        public DataTable LoadMedicionRiesgo(string Frecuencia, string Severidad)
        {
            DataTable dtInformacion = new DataTable();
            string consulta = "";
            try
            {
                cDataBase.conectar();
                consulta = $"SELECT TOP 1 Resultado FROM Eventos.MatrizMedRiesgo emm INNER JOIN Eventos.DescFrecuencia edf ON edf.IdDescFrecuencia = emm.IdDescFrecuencia INNER JOIN Eventos.DescSeveridad eds ON emm.IdDescSeveridad = eds.IdDescSeveridad WHERE edf.DescripcionFicohsa = '{Frecuencia.Trim()}' AND eds.DescripcionFicohsa = '{Severidad.Trim()}'";
                dtInformacion = cDataBase.ejecutarConsulta(consulta);
                cDataBase.desconectar();
            }
            catch (Exception ex)
            {
                cDataBase.desconectar();
                cError.errorMessage(ex.Message + ", " + ex.StackTrace);
                throw new Exception(consulta);
            }
            return dtInformacion;
        }

        public DataTable LoadMedicionRiesgo2(string Probabilidad, string Impacto)
        {
            DataTable dtInformacion = new DataTable();
            string consulta = "";
            try
            {
                cDataBase.conectar();
                consulta = $"SELECT ISNULL(NombreRiesgoInherente, '') as NombreRiesgoInherente, Color FROM Parametrizacion.RiesgoInherente WHERE ( IdProbabilidad = (SELECT IdProbabilidad FROM Parametrizacion.Probabilidad where NombreProbabilidad = '{Probabilidad.Trim()}') AND IdImpacto = (SELECT IdImpacto FROM Parametrizacion.Impacto where NombreImpacto = '{Impacto.Trim()}'))";
                dtInformacion = cDataBase.ejecutarConsulta(consulta);
                cDataBase.desconectar();
            }
            catch (Exception ex)
            {
                cDataBase.desconectar();
                cError.errorMessage(ex.Message + ", " + ex.StackTrace);
                throw new Exception(consulta);
            }
            return dtInformacion;
        }

        public DataTable LoadInfoEvsEIncs(string CodigoEvsEIncs, string DescripcionEvento, string FechaRegistro)
        {
            DataTable dtInformacion = new DataTable();
            string consulta = "";

            try
            {
                consulta = "SELECT IdEvsEIncs, CodigoEvsEIncs, FechaRegistro, DescripcionEvento FROM [Riesgos].[EventosIncidentes] WHERE 1 = 1 ";

                if (!CodigoEvsEIncs.Equals(""))
                    consulta += " AND CodigoEvsEIncs ='" + CodigoEvsEIncs + "'";

                if (!FechaRegistro.Equals(""))
                    consulta += " AND datediff(day, FechaRegistro, CAST(N'" + FechaRegistro + "' AS DATE)) = 0  ";

                if (!DescripcionEvento.Equals(""))
                    consulta += " AND DescripcionEvento LIKE '%" + DescripcionEvento + "%'";

                #region consulta
                cDataBase.conectar();
                dtInformacion = cDataBase.ejecutarConsulta(consulta);
                #endregion Consulta

                cDataBase.desconectar();
                return dtInformacion;
            }
            catch (Exception ex)
            {
                cDataBase.desconectar();
                cError.errorMessage(ex.Message + ", " + ex.StackTrace);
                throw new Exception(consulta);
            }
        }


        public DataTable LoadInfoPlanes(string idEvsEIncs, string CodigoPlan = "", string NombrePlan = "")
        {

            DataTable dtInformacion = new DataTable();
            string consulta = "";
            try
            {

                if (idEvsEIncs.ToString().Equals("0") || idEvsEIncs.ToString().Equals(""))
                {
                    consulta = "SELECT *, '' AS Relacion FROM Riesgos.planes ";
                }
                else
                {
                    consulta = $"SELECT rp.*, CASE WHEN " +
                        $"(SELECT rpe.IdPlanes_EvsEIncs FROM Riesgos.Planes_EvsEIncs rpe WHERE rpe.IdPlanes = rp.Id AND rpe.IdEvsEIncs = {idEvsEIncs} ) " +
                        $"IS NOT NULL THEN 'Asociado' ELSE '' END AS 'Relacion' FROM Riesgos.planes rp ";
                }

                string concatenar = "";
                if (CodigoPlan != "0" && CodigoPlan != "")
                {
                    concatenar = " WHERE ";
                    consulta += $" {concatenar} CodigoPlan = '{CodigoPlan}' ";
                }


                if (!NombrePlan.Equals(""))
                {
                    concatenar = concatenar.Equals(" WHERE ") ? "OR" : "WHERE";
                    consulta += $" {concatenar} NombrePlan LIKE '%{NombrePlan}%' ";
                }

                consulta += " ORDER BY Relacion DESC ";

                cDataBase.conectar();
                dtInformacion = cDataBase.ejecutarConsulta(consulta);

                cDataBase.desconectar();
                return dtInformacion;
            }
            catch (Exception ex)
            {
                cDataBase.desconectar();
                cError.errorMessage(ex.Message + ", " + ex.StackTrace);
                throw new Exception(consulta);
            }
        }

        public DataTable LoadInfoRiesgos(string idEvsEIncs, string idRiesgo, string Codigo = "", string Nombre = "", string CadenaValor = "", string Macroproceso = "", string Proceso = "", string Subproceso = "", string Actividad = "")
        {

            DataTable dtInformacion = new DataTable();
            string consulta = "";
            string concat = "";

            try
            {
                if (idEvsEIncs.ToString().Equals("0") || idEvsEIncs.ToString().Equals(""))
                    consulta = "SELECT *, '' AS Relacion FROM Riesgos.vwDetalle WHERE 1 = 1 ";

                else
                    consulta = $"SELECT *, CASE WHEN (SELECT TOP 1 rei.IdEvsEIncs FROM Riesgos.EventosIncidentes rei WHERE rei.IdEvsEIncs = {idEvsEIncs} AND rei.IdRiesgo = rr.IdRiesgo) IS NOT NULL THEN 'Asociado' ELSE '' END AS Relacion FROM Riesgos.vwDetalle rr WHERE 1 = 1 ";


                if (!Codigo.Equals(""))
                    consulta += $" AND Codigo LIKE '%{Codigo}%' ";

                if (!Nombre.Equals(""))
                    consulta += $" AND Nombre LIKE '%{Nombre}%' ";

                if (CadenaValor != "0")
                    consulta += $" AND IdCadenaValor = {CadenaValor} ";

                if (Macroproceso != "0")
                    consulta += $" AND IdMacroproceso = {Macroproceso} ";

                if (Proceso != "0")
                    consulta += $" AND IdProceso = {Proceso} ";

                if (Subproceso != "0")
                    consulta += $" AND IdSubProceso = {Subproceso} ";

                if (Actividad != "0")
                    consulta += $" AND IdActividad = {Actividad} ";

                consulta += " ORDER BY Relacion DESC, rr.IdRiesgo ASC ";

                cDataBase.conectar();
                dtInformacion = cDataBase.ejecutarConsulta(consulta);

                cDataBase.desconectar();
                return dtInformacion;
            }
            catch (Exception ex)
            {
                cDataBase.desconectar();
                cError.errorMessage(ex.Message + ", " + ex.StackTrace);
                throw new Exception(consulta);
            }
        }

        public DataTable LoadInfoProcesoO(string idEvsEIncs, string IdMacroProceso = "", string Nombre = "")
        {

            DataTable dtInformacion = new DataTable();
            string consulta = "";
            try
            {

                if (idEvsEIncs.ToString().Equals("0") || idEvsEIncs.ToString().Equals(""))
                {
                    consulta = "SELECT *, '' AS Relacion FROM Procesos.vwDetalle WHERE 1 = 1 ";
                }
                else
                {
                    consulta = $"SELECT pp.*, CASE WHEN " +
                        $"(SELECT eep.IdEvsEIncs_ProcesoOriginador FROM Eventos.EvsEIncs_ProcesoOriginador eep " +
                        $" WHERE eep.IdProcesoOriginador = pp.IdProceso AND eep.IdEventoIncidente = {idEvsEIncs} ) IS NOT NULL THEN 'Asociado' ELSE '' END AS 'Relacion' " +
                        $" FROM Procesos.vwDetalle pp WHERE 1 = 1 ";
                }

                if (IdMacroProceso != "0")
                    consulta += $" AND IdMacroProceso = '{IdMacroProceso}' ";

                if (!Nombre.Equals(""))
                    consulta += $" AND Nombre LIKE '%{Nombre}%' ";

                consulta += " ORDER BY Relacion DESC, pp.IdProceso ASC ";

                cDataBase.conectar();
                dtInformacion = cDataBase.ejecutarConsulta(consulta);

                cDataBase.desconectar();
                return dtInformacion;
            }
            catch (Exception ex)
            {
                cDataBase.desconectar();
                cError.errorMessage(ex.Message + ", " + ex.StackTrace);
                throw new Exception(consulta);
            }
        }
        public DataTable LoadInfoProcesoA(string idEvsEIncs, string IdMacroProceso = "", string Nombre = "")
        {

            DataTable dtInformacion = new DataTable();
            string consulta = "";

            try
            {

                if (idEvsEIncs.ToString().Equals("0") || idEvsEIncs.ToString().Equals(""))
                    consulta = "SELECT *, '' AS Relacion FROM Procesos.vwDetalle WHERE 1 = 1 ";

                else
                    consulta = $"SELECT *, CASE WHEN (SELECT TOP 1 rei.IdEvsEIncs FROM Riesgos.EventosIncidentes rei WHERE rei.IdEvsEIncs = {idEvsEIncs} AND rei.IdProcesoAfectado = pp.IdProceso) IS NOT NULL THEN 'Asociado' ELSE '' END AS Relacion FROM Procesos.vwDetalle pp WHERE 1 = 1 ";

                if (IdMacroProceso != "0")
                    consulta += $" AND IdMacroProceso = {IdMacroProceso} ";

                if (!Nombre.Equals(""))
                    consulta += $" AND Nombre LIKE '%{Nombre}%' ";

                consulta += " ORDER BY Relacion DESC, pp.IdProceso ASC ";

                cDataBase.conectar();
                dtInformacion = cDataBase.ejecutarConsulta(consulta);

                cDataBase.desconectar();
                return dtInformacion;
            }
            catch (Exception ex)
            {
                cDataBase.desconectar();
                cError.errorMessage(ex.Message + ", " + ex.StackTrace);
                throw new Exception(consulta);
            }
        }

        public DataTable LoadInfoArchivos(string idEvsEIncs)
        {
            string consulta = "";
            DataTable dtInformacion = new DataTable();

            try
            {
                if (!idEvsEIncs.ToString().Equals(""))
                {
                    consulta = $"SELECT ea.IdArchivo, ea.UrlArchivo, ea.FechaRegistro, CONCAT(lu.Nombres , ' ' , lu.Apellidos) as 'Usuario' FROM Eventos.Archivos ea INNER JOIN Listas.Usuarios lu ON  ea.IdUsuario = lu.IdUsuario WHERE ea.IdEvsEIncs = {idEvsEIncs} ORDER BY FechaRegistro DESC";

                    cDataBase.conectar();
                    dtInformacion = cDataBase.ejecutarConsulta(consulta);
                    cDataBase.desconectar();
                }
            }
            catch (Exception ex)
            {
                cDataBase.desconectar();
                cError.errorMessage(ex.Message + ", " + ex.StackTrace);
                throw new Exception(ex.Message + ", " + consulta);
            }

            return dtInformacion;
        }

        public DataTable LoadInfoJustificacion(string idEvsEIncs)
        {
            string consulta = "";
            DataTable dtInformacion = new DataTable();

            try
            {
                if (!idEvsEIncs.ToString().Equals(""))
                {
                    consulta = $"SELECT eej.*, CONCAT(lu.Nombres , ' ' , lu.Apellidos) as 'Usuario' FROM Eventos.EvsEIncs_Justificacion eej INNER JOIN Listas.Usuarios lu ON  eej.IdUsuario = lu.IdUsuario WHERE eej.IdEvsEIncs = {idEvsEIncs} ORDER BY FechaRegistro DESC";

                    cDataBase.conectar();
                    dtInformacion = cDataBase.ejecutarConsulta(consulta);
                    cDataBase.desconectar();
                }
            }
            catch (Exception ex)
            {
                cDataBase.desconectar();
                cError.errorMessage(ex.Message + ", " + ex.StackTrace);
                throw new Exception(ex.Message + ", " + consulta);
            }

            return dtInformacion;
        }
        public DataTable LoadDataEvsEInc(string idEvsEIncs)
        {
            DataTable dtInformacion = new DataTable();

            try
            {
                string consulta = "SELECT * FROM [Riesgos].[EventosIncidentes] WHERE IdEvsEIncs ='" + idEvsEIncs + "'";

                #region consulta
                cDataBase.conectar();
                dtInformacion = cDataBase.ejecutarConsulta(consulta);
                #endregion Consulta

                cDataBase.desconectar();
                return dtInformacion;
            }
            catch (Exception ex)
            {
                cDataBase.desconectar();
                cError.errorMessage(ex.Message + ", " + ex.StackTrace);
                throw new Exception(ex.Message);
            }
        }
        #endregion

        #region Consultar

        public string ConsultarCriticidadSv(string MontoExpoInvolucrado)
        {
            DataTable dtInformacion = new DataTable();
            try
            {
                cDataBase.conectar();
                string Consulta = $"SELECT IdDescSeveridad FROM Eventos.MtGblSeveridad WHERE Minimo <= {MontoExpoInvolucrado} AND Maximo >={MontoExpoInvolucrado}";
                dtInformacion = cDataBase.ejecutarConsulta(Consulta);
                cDataBase.desconectar();

            }
            catch (Exception ex)
            {
                cDataBase.desconectar();
                cError.errorMessage(ex.Message + ", " + ex.StackTrace);
                throw new Exception(ex.Message);
            }
            return dtInformacion.Rows[0]["IdDescSeveridad"].ToString().Trim();
        }

        public string ConsultarCriticidadFq(string ValorFrecuencia)
        {
            DataTable dtInformacion = new DataTable();

            List<SqlParameter> parametros = new List<SqlParameter>()
                {
                    new SqlParameter() { ParameterName = "@ValorFrecuencia", SqlDbType = SqlDbType.Int, Value = ValorFrecuencia }
                };

            dtInformacion = cDataBase.EjecutarSPParametrosReturnDatatable("[Eventos].[ConsultarCriticidadFq]", parametros);

            return dtInformacion.Rows[0]["IdDescFrecuencia"].ToString().Trim();

        }
        public string ConsultarDescFrecuencia(string IdTipoRiesgo, string ValorFrecuencia)
        {
            DataTable dtInformacion = new DataTable();

            List<SqlParameter> parametros = new List<SqlParameter>()
                {
                    new SqlParameter() { ParameterName = "@IdTipoRiesgo", SqlDbType = SqlDbType.Int, Value = IdTipoRiesgo },
                    new SqlParameter() { ParameterName = "@ValorFrecuencia", SqlDbType = SqlDbType.Int, Value = ValorFrecuencia }
                };

            dtInformacion = cDataBase.EjecutarSPParametrosReturnDatatable("[Eventos].[ConsultarDescFrecuencia]", parametros);

            return dtInformacion.Rows[0]["IdDescFrecuencia"].ToString().Trim();
        }

        public string ConsultarDescSeveridad(string IdTipoRiesgo, string MontoExpoInvolucrado)
        {
            DataTable dtInformacion = new DataTable();
            try
            {
                cDataBase.conectar();
                string Consulta = $"SELECT  IdDescSeveridad FROM Eventos.MtEspSeveridad mef " +
                    $"WHERE mef.IdTipoRiesgo = {IdTipoRiesgo} AND(Minimo <= '{MontoExpoInvolucrado}' AND Maximo >= '{MontoExpoInvolucrado}')";

                dtInformacion = cDataBase.ejecutarConsulta(Consulta);
                cDataBase.desconectar();

            }
            catch (Exception ex)
            {
                cDataBase.desconectar();
                cError.errorMessage(ex.Message + ", " + ex.StackTrace);
                throw new Exception(ex.Message);
            }
            return dtInformacion.Rows[0]["IdDescSeveridad"].ToString().Trim();
        }

        public bool ConsultarRelacionIdTabla(string IdTabla, string CodigoEvsEIncs)
        {
            string Conteo = "0";

            try
            {
                DataTable dtInformacion = new DataTable();
                cDataBase.conectar();
                dtInformacion = cDataBase.ejecutarConsulta("SELECT COUNT(IdEvsEIncs) AS Conteo FROM [Riesgos].[EventosIncidentes] WHERE CodigoEvsEIncs = '" + CodigoEvsEIncs + "' AND " + IdTabla + " != 0");
                cDataBase.desconectar();

                Conteo = dtInformacion.Rows[0]["Conteo"].ToString().Trim();

            }
            catch (Exception ex)
            {
                cDataBase.desconectar();
                cError.errorMessage(ex.Message + ", " + ex.StackTrace);
                throw new Exception(ex.Message);
            }
            return (Conteo.Equals("1"));
        }

        public byte[] ConsultarDataPDF(string IdArchivo)
        {
            byte[] bInfo = null;
            string strConsulta = "";
            DataTable dtInformacion = new DataTable();

            try
            {
                strConsulta = $"SELECT [UrlArchivo], [ArchivoPDF] FROM [Eventos].[Archivos] WHERE [IdArchivo] = N'{IdArchivo}'";

                cDataBase.mtdConectarSql();
                bInfo = cDataBase.mtdEjecutarConsultaSqlPdf(strConsulta);
                cDataBase.mtdDesconectarSql();
            }
            catch (Exception ex)
            {
                cDataBase.mtdDesconectarSql();
                cError.errorMessage(ex.Message + ", " + ex.StackTrace);
                throw new Exception(ex.Message);
            }

            return bInfo;
        }

        #endregion
    }
}
