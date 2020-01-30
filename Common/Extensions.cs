using System;
using System.Collections.Generic;
using System.Data.Entity.Design.PluralizationServices;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public static class Extensions
    {
        public static string Pluralize(this string str, int n)
        {
            if (n != 1)
                return PluralizationService.CreateService(new CultureInfo("en-US"))
                .Pluralize(str);
            return str;
        }
    }
}
