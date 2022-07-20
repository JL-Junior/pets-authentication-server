using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        public static String EncodeBase64(this String txt){
            if(String.IsNullOrEmpty(txt)) throw new ArgumentNullException("txt");
            return Convert.ToBase64String(Encoding.UTF8.GetBytes(txt));
        }

        public static String DecodeBase64(this String txt){
            if(String.IsNullOrEmpty(txt)) throw new ArgumentNullException("txt");
            return Encoding.UTF8.GetString(Convert.FromBase64String(txt));
        }
    }
}