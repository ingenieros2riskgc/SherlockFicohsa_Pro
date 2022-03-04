using System.Text.RegularExpressions;

namespace ListasSarlaft.Classes
{
    public class clsUtilidades
    {
        /// <summary>
        /// Metodo que permite evaluar si una cadena es un numero.
        /// </summary>
        /// <param name="strNumero"></param>
        /// <returns></returns>
        public static bool mtdEsNumero(string strNumero)
        {
            bool booResult = false;
            Regex regex = new Regex(@"^[0-9]+$");

            if (regex.IsMatch(strNumero))
                booResult = true;

            return booResult;
        }

        public static string mtdQuitarComasAPuntos(string strValor)
        {
            return strValor.Replace(',', '.');
        }
    }
}