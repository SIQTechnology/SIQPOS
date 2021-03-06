﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Machine.Specifications;
using MemoKu.POS.Domain.Exceptions;
using MemoKu.POS.Mvc.Exceptions;
using MemoKu.POS.Mvc.Modes;

namespace MemoKu.Test.Modes.Scan
{
    class when_enter_key_press_for_expression_but_no_item : test_base_mode
    {
        static ScanMode scanMode;
        static Exception ex;
        Establish ctx = () =>
        {
            scanMode = new ScanMode(mainCtrl, mainView, modeCtrl, searchPartView);
        };

        Because of = () =>
        {
            ex = Catch.Exception(() => scanMode.OnKeyEnterPress("+10"));
        };

        It throw_exception_NoItemSelectedException = () =>
        {
            ex.GetType().ShouldEqual(typeof(NoItemSelectedException));
        };

        It exception_should_have_data_throw_false = () =>
        {
            ex.Data["ThrowToView"].ShouldEqual(false);
        };
    }
}
