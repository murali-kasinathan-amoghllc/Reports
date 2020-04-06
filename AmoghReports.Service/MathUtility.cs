using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AmoghReports.Service
{
    public class MathUtility
    {
        public static double stringToDouble(string param)
        {
            if (string.IsNullOrEmpty(param))
            {
                return 0;
            }

            if (double.TryParse(param, out double val))
            {
                return val;
            }

            return 0;
        }


        public static int stringToInt(string param)
        {
            if (string.IsNullOrEmpty(param))
            {
                return 0;
            }

            if (int.TryParse(param, out int val))
            {
                return val;
            }

            return 0;
        }
    }
}