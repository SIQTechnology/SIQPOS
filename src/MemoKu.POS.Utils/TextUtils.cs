using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoKu.POS.Utils
{
    public static class TextUtils
    {
        public static bool IsCalculateExpression(this string expression)
        {
            return expression.StartsWith("*");
        }

        public static string GetExpressionValue(this string expression)
        {
            return expression.Substring(1);
        }
    }
}
