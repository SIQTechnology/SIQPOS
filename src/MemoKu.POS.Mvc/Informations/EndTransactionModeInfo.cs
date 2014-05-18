using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MemoKu.POS.Mvc.Interface;

namespace MemoKu.POS.Mvc.Informations
{
    public class EndTransactionModeInfo : IModeInformation
    {
        string Name = "End Transaction Mode";
        string menu1 = "";
        string menu2 = "";
        string menu3 = "";
        string menu4 = "";
        string menu5 = "";
        string menu6 = "";
        string menu7 = "";
        string menu8 = "";
        string menu9 = "";
        string menu10 = "";
        string menu11 = "";
        string menu12 = "";
        string menu13 = "";
        string menu14 = "";
        string menu15 = "Enter - Transaksi Baru";
        string menu16 = "ESC - Back to Scan Mode";

        public string Menu1 { get { return menu1; } }

        public string Menu2 { get { return menu2; } }

        public string Menu3 { get { return menu3; } }

        public string Menu4 { get { return menu4; } }

        public string Menu5 { get { return menu5; } }

        public string Menu6 { get { return menu6; } }

        public string Menu7 { get { return menu7; } }

        public string Menu8 { get { return menu8; } }

        public string Menu9 { get { return menu9; } }

        public string Menu10 { get { return menu10; } }

        public string Menu11 { get { return menu11; } }

        public string Menu12 { get { return menu12; } }

        public string Menu13 { get { return menu13; } }

        public string Menu14 { get { return menu14; } }

        public string Menu15 { get { return menu15; } }

        public string Menu16 { get { return menu16; } }

        public string ModeName { get { return Name; } }
    }
}
