using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Machine.Specifications;
using MemoKu.POS.Mvc;
using MemoKu.POS.Mvc.Exceptions;
using MemoKu.POS.Mvc.Modes;
using MemoKu.Test.Modes.Scan.context;

namespace MemoKu.Test.Modes.Scan
{
    class when_key_f2_pressed : behave_like_item_added
    {
        Because of = () =>
        {
            scanMode.OnKeyF2Press();
        };

        It current_mode_is_select_item_mode = () =>
        {
            modeCtrl.CurrentMode.GetType().ShouldEqual(typeof(SelectItemMode));
        };
    }
}
