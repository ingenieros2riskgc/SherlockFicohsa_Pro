﻿using System;
using System.Data;

namespace ListasSarlaft.Classes
{
    public class clsDALselParaProbabilidad
    {
        public bool mtdDownLoadFile(ref DataTable dtCaracOut, ref string strErrMsg)
        {
            #region Vars
            string strConsulta = string.Empty;
            cDataBase cDatabase = new cDataBase();
            bool boolResult = false;
            #endregion Vars
            try
            {

                strConsulta = string.Format("SELECT [archivo]" +
                " FROM [Parametrizacion].[Archivos]" +
                " where Modulo = 'Frecuencia'");

                cDatabase.conectar();
                dtCaracOut = cDatabase.ejecutarConsulta(strConsulta);
                boolResult = true;
            }
            catch (Exception ex)
            {
                strErrMsg = string.Format("Error al consultar de la imagen de la frecuencia. [{0}]", ex.Message);
            }
            finally
            {
                cDatabase.desconectar();
            }

            return boolResult;
        }
    }
}