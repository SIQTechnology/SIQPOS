using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Machine.Specifications;
using MemoKu.POS.Mvc.Modes;

namespace MemoKu.Test.Modes.Scan.context
{
    class behave_like_item_added : test_base_mode
    {
        protected static ScanMode scanMode;
        Establish ctx = () =>
        {
            scanMode = new ScanMode(mainCtrl, mainView, modeCtrl, searchPartView);
            scanMode.OnKeyEnterPress("001");
        };
    }
}
