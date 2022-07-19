using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pets.Megastore.Auth.Api
{
    public static class StringExtensions
    {
        public static String ToSnakeCase(this String txt){
            if(String.IsNullOrEmpty(txt)) return txt;
            return String.Concat(txt.Select(
                (x,i) => i > 0 && char.IsUpper(x) 
                ? "_" + x.ToString() 
                : x.ToString())).ToLower();
        }
    }
}