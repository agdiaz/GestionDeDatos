using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace FrbaBus.Helpers
{
    public static class FechaHelper
    {
        public static DateTime Ahora()
        {
            var sNow = ConfigurationManager.AppSettings["DateTimeNow"];
            return DateTime.ParseExact(sNow, "yyyyMMdd HHmmss", System.Globalization.CultureInfo.CurrentCulture);
        }
    }
}
