using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MemoKu.POS.Domain.Exceptions
{
    public class NoItemSelectedException : Exception
    {
        public NoItemSelectedException()
            : base("No Item Selected")
        {
            base.Data.Add("ThrowToView", false);
        }
    }
}
