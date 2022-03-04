﻿using System;
using System.Data.OleDb;

namespace ListasSarlaft.Classes
{
    public class clsDALUpdParaEstadoPlanEva
    {
        #region Variables Globales
        private cDataBase cDataBase = new cDataBase();
        private cError cError = new cError();
        private OleDbParameter[] parameters;
        private OleDbParameter parameter;
        #endregion Variables Globales
        public bool mtdActualizarParaEstadoPlanEva(clsDTOParaEstadoPlanEvaluacion EstadoPlanEva, ref string strErrMsg)
        {
            string strConsulta = string.Empty, strTodosProcesos = string.Empty, strContrasenaEncriptada = string.Empty;
            bool booResult = true;

            try
            {
                #region Creacion Consulta
                parameters = new OleDbParameter[2];
                parameter = new OleDbParameter("@NombreEstadoPlanEvaluacion", OleDbType.VarChar);
                parameter.Value = EstadoPlanEva.strNombreEstadoPlanEvaluacion;
                parameters[0] = parameter;
                parameter = new OleDbParameter("@IdEstadoPlanEvaluacion", OleDbType.Numeric);
                parameter.Value = EstadoPlanEva.intIdEstadoPlanEvaluacion;
                parameters[1] = parameter;
                #endregion Creacion Consulta

                cDataBase.conectar();
                cDataBase.ejecutarSPParametros("Parametrizacion.spRIESGOSActualizarEstadoPlanEvaluacion", parameters);
                booResult = true;
            }
            catch (Exception ex)
            {
                booResult = false;
                cError.errorMessage(ex.Message + ", " + ex.StackTrace);
                strErrMsg = string.Format("Error al insertar el estado del plan de evaluacion. [{0}]", ex.Message);
            }
            finally
            {
                cDataBase.desconectar();
            }

            return booResult;
        }
    }
}