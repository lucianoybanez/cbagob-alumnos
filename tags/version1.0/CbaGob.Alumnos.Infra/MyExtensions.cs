using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CbaGob.Alumnos.Infra
{
    public static class MyExtensions
    {
        public static string ToPersonal(this DateTime? date)
        {
            if (date==null)
            {
                return "";
            }
            return String.Format("{0:dd/MM/yyyy}", date);
        }
    }
}
