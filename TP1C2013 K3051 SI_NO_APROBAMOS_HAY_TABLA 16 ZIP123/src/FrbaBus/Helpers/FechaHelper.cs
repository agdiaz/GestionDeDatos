using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using FrbaBus.Common.Entidades.Estadisticas;

namespace FrbaBus.Helpers
{
    public static class FechaHelper
    {
        public static DateTime Ahora()
        {
            var sNow = ConfigurationManager.AppSettings["DateTimeNow"];
            return DateTime.ParseExact(sNow, "yyyyMMdd HHmmss", System.Globalization.CultureInfo.CurrentCulture);
        }
        public static DateTime FechaNulla()
        {
            return DateTime.MinValue.AddMilliseconds(1);
        }
        public static IList<Semestre> ListarSemestres()
        {
            IList<Semestre> semestres = new List<Semestre>();
            
            DateTime fechaActual = Ahora();

            for (int i = 0; i < 4; i++)
            {
                DateTime inicioS1 = fechaActual.AddYears(-i).AddMonths(-fechaActual.Month + 1).AddDays(-fechaActual.Day + 1);
                DateTime finS1 = inicioS1.AddMonths(6).AddDays(-1);
                semestres.Add(new Semestre() { Inicio = inicioS1, Fin = finS1 });

                DateTime inicioS2 = fechaActual.AddYears(-i).AddMonths(-fechaActual.Month + 7).AddDays(-fechaActual.Day + 1);
                DateTime finS2 = inicioS2.AddMonths(6).AddDays(-1);
                semestres.Add(new Semestre() { Inicio = inicioS2, Fin = finS2 });
            }

            return semestres;
        }
    }
}
