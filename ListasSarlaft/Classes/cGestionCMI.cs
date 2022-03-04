using System;
using System.Data;

namespace ListasSarlaft.Classes
{
    public class cGestionCMI : cPropiedades
    {
        private cDataBase cDataBase = new cDataBase();
        private cError cError = new cError();

        public DataTable PlanEstrategico()
        {
            DataTable dtInformacion = new DataTable();
            try
            {
                cDataBase.conectar();
                dtInformacion = cDataBase.ejecutarConsulta("SELECT PE.IdPlan,PE.CodigoPlan,PE.Nombre,CONVERT(varchar,PE.FechaInicio,103) AS FechaInicio,CONVERT(varchar,PE.FechaFin,103) AS FechaFin,US.Usuario,CONVERT(varchar,PE.FechaRegistro,103) AS FechaRegistro FROM Gestion.PlanEstrategico PE, Listas.Usuarios US WHERE PE.IdUsuario=US.IdUsuario");
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

        public DataTable cmifechaspe(String IdPlan)
        {
            DataTable dtInformacion = new DataTable();
            try
            {
                cDataBase.conectar();
                dtInformacion = cDataBase.ejecutarConsulta("SELECT PE.IdPlan,CONVERT(VARCHAR(10),PE.FechaInicio,120) AS FechaInicio,CONVERT(VARCHAR(10),PE.FechaFin,120) AS FechaFin FROM Gestion.PlanEstrategico PE, Listas.Usuarios US  WHERE PE.IdPlan=" + IdPlan);
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

        public DataTable cmi_objetivos(String IdPlan, String IdDetalleTipo)
        {
            DataTable dtInformacion = new DataTable();
            try
            {
                cDataBase.conectar();
                dtInformacion = cDataBase.ejecutarConsulta("select obj.IdObjetivo,obj.CodigoObjetivo,obj.Descripcion,convert(varchar,obj.FechaInicio,103) as Inicio,convert(varchar,obj.FechaFin,103) as Fin from Gestion.ObjetivosEstrategicos obj where IdPlan = " + IdPlan + " and obj.IdDetalleTipo =" + IdDetalleTipo);
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

        public DataTable ObjEstrategico(string IdPlan)
        {
            DataTable dtInformacion = new DataTable();
            try
            {
                cDataBase.conectar();
                dtInformacion = cDataBase.ejecutarConsulta("select OBJ.IdObjetivo, OBJ.CodigoObjetivo, OBJ.Descripcion, PER.NombreDetalle, CONVERT(VARCHAR(10),OBJ.FechaInicio,103) as FechaInicio, CONVERT(VARCHAR(10),OBJ.FechaFin,103) as FechaFin, US.Usuario, CONVERT(VARCHAR(10),OBJ.FechaRegistro,103) as FechaRegistro from Gestion.ObjetivosEstrategicos OBJ, Gestion.DetalleTipos PER,Listas.Usuarios US where OBJ.IdDetalleTipo=PER.IdDetalleTipo and OBJ.IdUsuario=US.IdUsuario AND OBJ.IdPlan = " + IdPlan);
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
        public DataTable ObjEstrategicoByCodPlan(string CodPlan)
        {
            DataTable dtInformacion = new DataTable();
            try
            {
                //"select OBJ.IdObjetivo, OBJ.CodigoObjetivo, OBJ.Descripcion, PER.NombreDetalle, CONVERT(VARCHAR(10),OBJ.FechaInicio,103) as FechaInicio, CONVERT(VARCHAR(10),OBJ.FechaFin,103) as FechaFin, US.Usuario, CONVERT(VARCHAR(10),OBJ.FechaRegistro,103) as FechaRegistro from Gestion.ObjetivosEstrategicos OBJ, Gestion.DetalleTipos PER,Listas.Usuarios US where OBJ.IdDetalleTipo=PER.IdDetalleTipo and OBJ.IdUsuario=US.IdUsuario AND OBJ.IdPlan = " + IdPlan
                string query = string.Format("select OBJ.IdObjetivo, OBJ.CodigoObjetivo, OBJ.Descripcion, PER.NombreDetalle, " + "\n" +
"CONVERT(VARCHAR(10), OBJ.FechaInicio, 103) as FechaInicio, CONVERT(VARCHAR(10), OBJ.FechaFin, 103) as FechaFin, " + "\n" +
"US.Usuario, CONVERT(VARCHAR(10), OBJ.FechaRegistro, 103) as FechaRegistro " + "\n" +
"from Gestion.ObjetivosEstrategicos OBJ " + "\n" +
"inner join Gestion.DetalleTipos PER on OBJ.IdDetalleTipo = PER.IdDetalleTipo " + "\n" +
"inner join Listas.Usuarios US  on OBJ.IdUsuario = US.IdUsuario " + "\n" +
"inner join Gestion.PlanEstrategico PE on PE.IdPlan = OBJ.IdPlan " + "\n" +
"where PE.CodigoPlan = '{0}'", CodPlan);
                cDataBase.conectar();
                dtInformacion = cDataBase.ejecutarConsulta(query);
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

        public DataTable Estrategia(string IdObjetivo)
        {
            DataTable dtInformacion = new DataTable();
            try
            {
                cDataBase.conectar();
                dtInformacion = cDataBase.ejecutarConsulta("SELECT EST.IdEstrategia,EST.CodigoEstrategia,EST.Descripcion,US.Usuario,CONVERT(VARCHAR(10),EST.FechaRegistro,120) AS FechaRegistro from Gestion.Estrategias EST,Listas.Usuarios US WHERE EST.Idusuario = US.IdUsuario AND EST.IdObjetivo = " + IdObjetivo);
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

        public DataTable cmiResponsables(String IdPlan)
        {
            DataTable dtInformacion = new DataTable();
            try
            {
                cDataBase.conectar();
                dtInformacion = cDataBase.ejecutarConsulta("select d.Responsable,e.NombreResponsable from Gestion.PlanEstrategico a, Gestion.ObjetivosEstrategicos b, Gestion.Estrategias c, Gestion.PlanAccion d,Parametrizacion.DetalleJerarquiaOrg e where a.IdPlan=b.IdPlan and b.IdObjetivo=c.IdObjetivo and c.IdEstrategia=d.IdEstrategia and d.Responsable=e.idHijo and a.IdPlan = " + IdPlan + " group by d.Responsable,e.NombreResponsable");
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

        public DataTable cmiIndicadoresDetalle(String IdPlan)
        {
            DataTable dtInformacion = new DataTable();
            try
            {
                cDataBase.conectar();
                dtInformacion = cDataBase.ejecutarConsulta("select ge.IdIndicador,ge.Descripcion,ge.Nominador,ge.Denominador,de.NombreDetalle as Periodicidad,ge.Meta from Gestion.Indicadores ge,Gestion.PlanAccion pa, Gestion.Estrategias es, Gestion.ObjetivosEstrategicos ob, Gestion.PlanEstrategico pe,Gestion.DetalleTipos de where pe.IdPlan=ob.IdPlan and ob.IdObjetivo=es.IdObjetivo and es.IdEstrategia=pa.IdEstrategia and pa.IdPlanAccion=ge.IdPlanAccion and ge.Periodicidad=de.IdDetalleTipo and pe.IdPlan = " + IdPlan + " order by ge.IdIndicador");
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

        public DataTable cmi_Color(decimal ValorColor)
        {
            DataTable dtInformacion = new DataTable();
            try
            {
                cDataBase.conectar();
                dtInformacion = cDataBase.ejecutarConsulta("select c.Color from Gestion.ColorCMI c where c.ColorMinimo <= " + ValorColor + " and c.ColorMaximo >=" + ValorColor);
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

        public DataTable cmi_VerIndicadoresEstrategias(String IdEstrategia)
        {
            DataTable dtInformacion = new DataTable();
            try
            {
                cDataBase.conectar();
                dtInformacion = cDataBase.ejecutarConsulta("select count(b.IdIndicador) as CantidadIndicadores from Gestion.PlanAccion a, Gestion.Indicadores b,Gestion.Estrategias c where a.IdPlanAccion=b.IdPlanAccion and a.IdEstrategia=c.IdEstrategia and c.IdEstrategia = " + IdEstrategia);
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

        public DataTable cmi_vercolor()
        {
            DataTable dtInformacion = new DataTable();
            try
            {
                cDataBase.conectar();
                dtInformacion = cDataBase.ejecutarConsulta("select C.Color,C.ColorMinimo,C.ColorMaximo,Descripcion from Gestion.ColorCMI C order by C.IdColor");
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

        public DataTable VerPerspectivas()
        {
            DataTable dtInformacion = new DataTable();
            try
            {
                cDataBase.conectar();
                dtInformacion = cDataBase.ejecutarConsulta("select UPPER(NombreDetalle) as NombreDetalle from Gestion.DetalleTipos where IdTipo = 1 order by IdDetalleTipo");
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

        public DataTable cmi_parametrizacolor(String ColorMinimo, String ColorMaximo, String Descripcion, String Color)
        {
            DataTable dtInformacion = new DataTable();
            try
            {
                cDataBase.conectar();
                dtInformacion = cDataBase.ejecutarConsulta("UPDATE Gestion.ColorCMI SET ColorMinimo = " + ColorMinimo + ", ColorMaximo = " + ColorMaximo + ", Descripcion = '" + Descripcion + "' WHERE Color = '" + Color + "'");
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

        public DataTable cmiResponsablesObjetivos(String IdPlan, String Responsable)
        {
            DataTable dtInformacion = new DataTable();
            try
            {
                cDataBase.conectar();
                dtInformacion = cDataBase.ejecutarConsulta("select ob.IdObjetivo,ob.Descripcion from Gestion.PlanAccion pa,Gestion.ObjetivosEstrategicos ob,Gestion.Estrategias es,Gestion.PlanEstrategico pe where ob.IdObjetivo=es.IdObjetivo and es.IdEstrategia=pa.IdEstrategia and ob.IdPlan=pe.IdPlan and pe.IdPlan= " + IdPlan + " and pa.Responsable = " + Responsable + " group by ob.IdObjetivo,ob.Descripcion");
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

        public DataTable cmiResponsablesPlanesAccion(String IdObjetivo, String Responsable)
        {
            DataTable dtInformacion = new DataTable();
            try
            {
                cDataBase.conectar();
                dtInformacion = cDataBase.ejecutarConsulta("select pa.IdPlanAccion,pa.Descripcion,CONVERT(varchar,pa.FechaInicio,103) as Inicio,CONVERT(varchar,pa.FechaFin,103) as Fin,pa.Abierto_SN from Gestion.PlanAccion pa,Gestion.ObjetivosEstrategicos ob,Gestion.Estrategias es where ob.IdObjetivo=es.IdObjetivo and es.IdEstrategia=pa.IdEstrategia and ob.IdObjetivo= " + IdObjetivo + " and pa.Responsable = " + Responsable + " order by pa.IdPlanAccion");
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

        public DataTable cmi_VerIndicadoresPlaAccion(String IdPlanAccion)
        {
            DataTable dtInformacion = new DataTable();
            try
            {
                cDataBase.conectar();
                dtInformacion = cDataBase.ejecutarConsulta("select count(b.IdIndicador) as CantidadIndicadores from Gestion.PlanAccion a, Gestion.Indicadores b  where a.IdPlanAccion=b.IdPlanAccion and a.IdPlanAccion = " + IdPlanAccion);
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

        public DataTable cmi_PAIndicadoresGlobales(String IdPlan)
        {
            DataTable dtInformacion = new DataTable();
            try
            {
                cDataBase.conectar();
                dtInformacion = cDataBase.ejecutarConsulta("select pa.IdPlanAccion,pa.Descripcion as PlanAccion from Gestion.PlanEstrategico pe,Gestion.ObjetivosEstrategicos ob,Gestion.Estrategias es, Gestion.PlanAccion pa where pe.IdPlan=ob.IdPlan and ob.IdObjetivo=es.IdObjetivo and es.IdEstrategia=pa.IdEstrategia and pe.IdPlan= " + IdPlan + " order by pa.IdPlanAccion");
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

        public DataTable cmiIndicadoresGlobales(String IdPlanAccion)
        {
            DataTable dtInformacion = new DataTable();
            try
            {
                cDataBase.conectar();
                dtInformacion = cDataBase.ejecutarConsulta("select ind.IdIndicador, ind.Descripcion as Indicador,Meta from Gestion.PlanAccion pa, Gestion.Indicadores ind where pa.IdPlanAccion=ind.IdPlanAccion and pa.IdPlanAccion = " + IdPlanAccion + " order by ind.IdIndicador");
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

        public DataTable cmi_IndicadoreDetalle(String IdIndicador)
        {
            DataTable dtInformacion = new DataTable();
            try
            {
                cDataBase.conectar();
                dtInformacion = cDataBase.ejecutarConsulta("select ob.IdObjetivo,ob.Descripcion as Objetivo,de.NombreDetalle as Perspectiva,pa.IdPlanAccion,pa.Descripcion as PlanAccion,gi.Meta from Gestion.ObjetivosEstrategicos ob, Gestion.Estrategias es, Gestion.PlanAccion pa, Gestion.Indicadores gi,Gestion.DetalleTipos de where ob.IdObjetivo=es.IdObjetivo and es.IdEstrategia=pa.IdEstrategia and pa.IdPlanAccion=gi.IdPlanAccion and ob.IdDetalleTipo=de.IdDetalleTipo and gi.IdIndicador = " + IdIndicador);
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

        public DataTable cmi_cumplimientoIndicadorResultado(String IdIndicador)
        {
            DataTable dtInformacion = new DataTable();
            try
            {
                cDataBase.conectar();
                //dtInformacion = cDataBase.ejecutarConsulta("select IdIndicador, Dia, Mes, Ano, Meta, Resultado, Cumplimiento, CONVERT(varchar,dia)+'/'+CONVERT(varchar,mes)+'/'+CONVERT(varchar,ano) as Periodo from Gestion.IndicadorCumplimiento a where IdIndicador = " + IdIndicador + " order by Ano,Dia, Mes");
                dtInformacion = cDataBase.ejecutarConsulta("select distinct I.IdIndicador,g.Descripcion,I.Dia,convert(int,I.Mes) as Mes,I.Ano,h.Meta,I.Resultado,(I.Resultado*100)/g.Meta as Cumplimiento, CONVERT(varchar,I.Dia)+'/'+CONVERT(varchar,I.mes)+'/'+CONVERT(varchar,I.ano) as Periodo from Gestion.IndicadorResultado I,Gestion.Indicadores g,Gestion.MetaValor h where I.IdIndicador=g.IdIndicador and I.IdIndicador = h.IdIndicador and I.Dia = h.Dia and I.Mes = h.Mes and I.Ano = h.Ano and I.IdIndicador = " + IdIndicador + " order by Mes,I.Dia,I.Ano");
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

        public DataTable ConsultaVariable(String IdIndicador)
        {
            DataTable dtInformacion = new DataTable();
            try
            {
                cDataBase.conectar();
                dtInformacion = cDataBase.ejecutarConsulta("select a.IdVariableValor, b.IdIndicador, a.IdVariable, b.Nombre, a.Valor, CONVERT(varchar,a.Dia)+'/'+CONVERT(varchar,a.Mes)+'/'+CONVERT(varchar,a.Ano) as Periodo from Gestion.VariableValor a INNER JOIN Gestion.Variables b ON b.IdVariable = a.IdVariable where b.IdIndicador = " + IdIndicador + "");
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

        public string ConsultarMaxMes(String IdIndicador)
        {
            string strConsulta = string.Empty;
            string resultado = string.Empty;
            DataTable dtInformacion = new DataTable();
            cDataBase cDataBase = new cDataBase();
            try
            {
                cDataBase.conectar();
                dtInformacion = cDataBase.ejecutarConsulta("select max (a.Mes) from Gestion.VariableValor a INNER JOIN Gestion.Variables b ON b.IdVariable = a.IdVariable where b.IdIndicador = " + IdIndicador + "");
                //strConsulta = string.Format("select max (a.Mes) from Gestion.VariableValor a INNER JOIN Gestion.Variables b ON b.IdVariable = a.IdVariable where b.IdIndicador = " + IdIndicador + "");
                if (dtInformacion != null && dtInformacion.Rows.Count > 0)
                {
                    resultado = dtInformacion.Rows[0][0].ToString();
                }
                cDataBase.desconectar();
            }
            catch (Exception ex)
            {
                cDataBase.desconectar();
                cError.errorMessage(ex.Message + ", " + ex.StackTrace);
                throw new Exception(ex.Message);
            }
            return resultado;
        }

        public DataTable consultaNomDen(String IdIndicador)
        {
            DataTable dtInformacion = new DataTable();
            try
            {
                cDataBase.conectar();
                dtInformacion = cDataBase.ejecutarConsulta("select Nominador, Denominador from Gestion.Indicadores where IdIndicador = " + IdIndicador + "");
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

        public DataTable IndicadorFormula(String IdIndicador)
        {
            DataTable dtInformacion = new DataTable();
            try
            {
                cDataBase.conectar();
                dtInformacion = cDataBase.ejecutarConsulta("select a.IdIndicador,a.Nominador,a.Denominador,b.NombreDetalle as Periodicidad from Gestion.Indicadores a, Gestion.DetalleTipos b where a.Periodicidad=b.IdDetalleTipo and a.IdIndicador =" + IdIndicador);
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

        public DataTable cmi_PlanesAccionIndicador(String IdPlanAccion)
        {
            DataTable dtInformacion = new DataTable();
            try
            {
                cDataBase.conectar();
                dtInformacion = cDataBase.ejecutarConsulta("select a.IdIndicador,a.Descripcion,a.Meta,b.NombreDetalle as Periodicidad from Gestion.Indicadores a,Gestion.DetalleTipos b,Gestion.PlanAccion c where a.Periodicidad=b.IdDetalleTipo and a.IdPlanAccion = c.IdPlanAccion and c.IdPlanAccion = " + IdPlanAccion);
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

        public DataTable cmi_PlanesAccion(String IdEstrategia)
        {
            DataTable dtInformacion = new DataTable();
            try
            {
                cDataBase.conectar();
                dtInformacion = cDataBase.ejecutarConsulta("select PA.IdPlanAccion, PA.Descripcion,DJ.NombreResponsable AS Responsable, PA.Abierto_SN, CONVERT(VARCHAR(10),PA.FechaInicio,103) as FechaInicio,CONVERT(VARCHAR(10),PA.FechaFin,103) as FechaFin from Gestion.PlanAccion PA, Listas.Usuarios US, Parametrizacion.DetalleJerarquiaOrg DJ where PA.IdUsuario=US.IdUsuario and PA.Responsable=DJ.idHijo AND PA.IdEstrategia = " + IdEstrategia);
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

        public DataTable cmi_PerspectivaOjbr(string IdObjetivo)
        {
            DataTable dtInformacion = new DataTable();
            try
            {
                cDataBase.conectar();
                dtInformacion = cDataBase.ejecutarConsulta("select PER.NombreDetalle as Perspectiva from Gestion.ObjetivosEstrategicos OBJ, Gestion.DetalleTipos PER where OBJ.IdDetalleTipo=PER.IdDetalleTipo AND OBJ.IdObjetivo =" + IdObjetivo);
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

        public DataTable PorcentjeCumplimiento(String TipoObjeto, String IdObjeto, String Mes, String Ano)
        {
            DataTable dtInformacion = new DataTable();
            try
            {
                cDataBase.conectar();
                dtInformacion = cDataBase.ejecutarConsulta("select * from Gestion.Cumplimiento where TipoObjeto = " + TipoObjeto + " and IdObjeto = " + IdObjeto + " and Mes = " + Mes + " and Ano = " + Ano);
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

        public DataTable PorcentjeCumplimientoHoy(String TipoObjeto, String IdObjeto, String Mes, String Ano)
        {
            DataTable dtInformacion = new DataTable();
            try
            {
                cDataBase.conectar();
                dtInformacion = cDataBase.ejecutarConsulta("select * from Gestion.CumplimientoHoy where TipoObjeto = " + TipoObjeto + " and IdObjeto = " + IdObjeto + " and Mes = " + Mes + " and Ano = " + Ano);
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

        public DataTable PorcentjeCumplimientoConsolidado(String TipoObjeto, String IdObjeto)
        {
            DataTable dtInformacion = new DataTable();
            try
            {
                cDataBase.conectar();
                dtInformacion = cDataBase.ejecutarConsulta("select (SUM(Cumplimiento)) / (COUNT(IdObjeto)) as Consolidado from Gestion.Cumplimiento where TipoObjeto = " + TipoObjeto + " and IdObjeto = " + IdObjeto);
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

        public DataTable PorcentjeCumplimientoConsolidadoHoy(String TipoObjeto, String IdObjeto, String Mes, String Ano)
        {
            DataTable dtInformacion = new DataTable();
            try
            {
                cDataBase.conectar();
                dtInformacion = cDataBase.ejecutarConsulta("select (SUM(Cumplimiento)+ (select SUM(Cumplimiento) from Gestion.CumplimientoHoy where TipoObjeto = " + TipoObjeto + " and IdObjeto = " + IdObjeto + " and Mes = " + Mes + " and Ano = " + Ano + ")) / (COUNT(IdObjeto)+1) as ConsolidadoHoy from Gestion.Cumplimiento where TipoObjeto = " + TipoObjeto + " and IdObjeto = " + IdObjeto);
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

        public DataTable PorcentjeCumplimientoConsolidadoHoyNew(String TipoObjeto, String IdObjeto)
        {
            DataTable dtInformacion = new DataTable();
            try
            {
                cDataBase.conectar();
                dtInformacion = cDataBase.ejecutarConsulta("select (SUM(Cumplimiento)+ (select SUM(Cumplimiento) from Gestion.CumplimientoHoy where TipoObjeto = '" + TipoObjeto + "' and IdObjeto = '" + IdObjeto + "')) / (COUNT(IdObjeto)+1) as ConsolidadoHoy from Gestion.Cumplimiento where TipoObjeto = " + TipoObjeto + " and IdObjeto = " + IdObjeto);
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

        public DataTable cmi_Gestiones(String IdPlanAccion)
        {
            DataTable dtInformacion = new DataTable();
            try
            {
                cDataBase.conectar();
                dtInformacion = cDataBase.ejecutarConsulta("select IdPlanAccion, g.Descripcion,convert(varchar(10),g.FechaRegistro,103) as Fecha from Gestion.Gestion g where IdPlanAccion = " + IdPlanAccion);
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

        public DataTable cmi_VerIndicadoresObjetivos(String IdObjetivo)
        {
            DataTable dtInformacion = new DataTable();
            try
            {
                cDataBase.conectar();
                dtInformacion = cDataBase.ejecutarConsulta("select count(b.IdIndicador) as CantidadIndicadores from Gestion.PlanAccion a, Gestion.Indicadores b,Gestion.Estrategias c,Gestion.ObjetivosEstrategicos d where a.IdPlanAccion=b.IdPlanAccion and a.IdEstrategia=c.IdEstrategia and d.IdObjetivo=c.IdObjetivo and d.IdObjetivo = " + IdObjetivo);
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





    }
}