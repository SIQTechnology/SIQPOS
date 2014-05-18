using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoKu.POS.Domain.ValueObjects
{
    public class Currency
    {
        public string Code { get; private set; }
        public string Name { get; private set; }
        public int Rounding { get; private set; }

        private Currency() { }

        public Currency(string code, string name, int rounding)
        {
            this.Code = code;
            this.Name = name;
            this.Rounding = rounding;
        }
    }
}
