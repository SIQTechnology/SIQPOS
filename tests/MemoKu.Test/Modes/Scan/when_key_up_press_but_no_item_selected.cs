using System;
using Machine.Specifications;
using MemoKu.POS.Domain.Exceptions;
using MemoKu.POS.Mvc.Modes;

namespace MemoKu.Test.Modes.Scan
{
    class when_key_up_press_but_no_item_selected : test_base_mode
    {
        static ScanMode scanMode;
        static Exception ex;
        Establish ctx = () =>
        {
            scanMode = new ScanMode(mainCtrl, mainView, modeCtrl, searchPartView);
        };

        Because of = () =>
        {
            ex = Catch.Exception(() => scanMode.OnKeyUpPress());
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
