using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace CuaHangTienLoi.Web.Models
{
    public class Core
    {
        public static string convertToUnsign(string str)
        {
            string pattern = @"([àáạảãâầấậẩẫăằắặẳẵ])|([èéẹẻẽêềếệểễ])|([ìíịỉĩ])|([òóọỏõôồốộổỗơờớợởỡ])|([ùúụủũưừứựửữ])|([ỳýỵỷỹ])|([đ])";
            Regex regex = new Regex(pattern, RegexOptions.IgnoreCase);
            string result = regex.Replace(str, delegate (Match match)
            {
                if (match.Groups[1].Value.Length > 0)
                    return "a";
                else if (match.Groups[2].Value.Length > 0)
                    return "e";
                else if (match.Groups[3].Value.Length > 0)
                    return "i";
                else if (match.Groups[4].Value.Length > 0)
                    return "o";
                else if (match.Groups[5].Value.Length > 0)
                    return "u";
                else if (match.Groups[6].Value.Length > 0)
                    return "y";
                else if (match.Groups[7].Value.Length > 0)
                    return "d";
                return "";
            });
            return result;
        }

    }


}