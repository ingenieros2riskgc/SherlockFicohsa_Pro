using System;
using System.Data;

namespace ListasSarlaft.Classes
{
    public class clsDALseguimientoRiesgoIndicador
    {
        public bool mtdInsertarSeguimientoRiesgoIndicador(clsDTOseguimientoRiesgoIndicador objSeguimiento, ref string strErrMsg)
        {
            #region Vars
            bool booResult = false;
            string valMin, valMax;
            string strConsulta = string.Empty;
            cDataBase cDatabase = new cDataBase();
            #endregion Vars
            

            try
            {
                valMin = objSeguimiento.dblValorMinimo.ToString();
                valMax = objSeguimiento.dblValorMaximo.ToString();

                if (objSeguimiento.dblValorMinimo.ToString().Contains(","))
                {
                    valMin = valMin.Replace(",",".");
                }                

                if (objSeguimiento.dblValorMaximo.ToString().Contains(","))
                {
                    valMax = valMax.Replace(",", ".");
                }

                strConsulta = string.Format("INSERT INTO [Riesgos].[RiesgosIndicadoresSeguimiento] ([IdRiesgoIndicador],[ValorMinimo],[ValorMaximo]"
                + ",[DescripcionSeguimiento],[UsuarioCreacion],[FechaCreacion],[Color])" +
                    "VALUES({0},{1},{2},'{3}',{4},GETDATE(),'{6}') ", objSeguimiento.intIdRiesgoIndicador, valMin, valMax,
                    objSeguimiento.strDescripcionSeguimiento, objSeguimiento.intUsuarioCreacion, objSeguimiento.dtFechaCreacion, objSeguimiento.strColor
                    );

                cDatabase.conectar();
                cDatabase.ejecutarQuery(strConsulta);
                booResult = true;
            }
            catch (Exception ex)
            {
                strErrMsg = string.Format("Error al crear el seguimiento del indicador. [{0}]", ex.Message);
                booResult = false;
            }
            finally
            {
                cDatabase.desconectar();
            }

            return booResult;
        }
        public bool mtdConsultarSeguimientoIndicador(ref DataTable dtCaracOut, ref string strErrMsg, int IdRiesgoIndicador)
        {
            #region Vars
            bool booResult = false;
            string strConsulta = string.Empty;
            cDataBase cDataBase = new cDataBase();
            #endregion Vars

            try
            {
                strConsulta = string.Format("SELECT [IdEsquemaSeguimiento],[IdRiesgoIndicador],[ValorMinimo],[ValorMaximo],[DescripcionSeguimiento],[UsuarioCreacion],[FechaCreacion],[Color]"
                    + " FROM [Riesgos].[RiesgosIndicadoresSeguimiento]"
                    + " where IdRiesgoIndicador = {0}", IdRiesgoIndicador
                    );

                cDataBase.conectar();
                dtCaracOut = cDataBase.ejecutarConsulta(strConsulta);
                booResult = true;
            }
            catch (Exception ex)
            {
                strErrMsg = string.Format("Error al consultar los seguimientos del indicador. [{0}]", ex.Message);
                booResult = false;
            }
            finally
            {
                cDataBase.desconectar();
            }

            return booResult;
        }
        public bool mtdActualizaSeguimientoRiesgoIndicador(clsDTOseguimientoRiesgoIndicador objSeguimiento, ref string strErrMsg)
        {
            #region Vars
            bool booResult = false;
            string strConsulta = string.Empty;
            cDataBase cDatabase = new cDataBase();
            #endregion Vars

            try
            {
                strConsulta = string.Format("UPDATE [Riesgos].[RiesgosIndicadoresSeguimiento] SET [ValorMinimo] ={0}"
                + ",[ValorMaximo] ={1},[DescripcionSeguimiento] ='{2}', [Color] = '{4}'"
                + " WHERE IdEsquemaSeguimiento = {3}", objSeguimiento.dblValorMinimo, objSeguimiento.dblValorMaximo
                , objSeguimiento.strDescripcionSeguimiento, objSeguimiento.intIdEsquemaSeguimiento, objSeguimiento.strColor
                    );

                cDatabase.conectar();
                cDatabase.ejecutarQuery(strConsulta);
                booResult = true;
            }
            catch (Exception ex)
            {
                strErrMsg = string.Format("Error al actualizar el seguimiento del indicador. [{0}]", ex.Message);
                booResult = false;
            }
            finally
            {
                cDatabase.desconectar();
            }

            return booResult;
        }
        public bool mtdDeleteSeguimientoRiesgoIndicador(clsDTOseguimientoRiesgoIndicador objSeguimiento, ref string strErrMsg)
        {
            #region Vars
            bool booResult = false;
            string strConsulta = string.Empty;
            cDataBase cDatabase = new cDataBase();
            #endregion Vars

            try
            {
                strConsulta = string.Format("DELETE FROM [Riesgos].[RiesgosIndicadoresSeguimiento] where IdEsquemaSeguimiento ={0}"
                    , objSeguimiento.intIdEsquemaSeguimiento
                    );

                cDatabase.conectar();
                cDatabase.ejecutarQuery(strConsulta);
                booResult = true;
            }
            catch (Exception ex)
            {
                strErrMsg = string.Format("Error al actualizar el seguimiento del indicador. [{0}]", ex.Message);
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
                strConsulta = string.Format("SELECT max([IdEsquemaSeguimiento]) LastId FROM [Riesgos].[RiesgosIndicadoresSeguimiento]");

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