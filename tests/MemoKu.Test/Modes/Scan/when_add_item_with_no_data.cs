using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Machine.Specifications;
using MemoKu.POS.Domain.Exceptions;
using MemoKu.POS.Mvc.Controller;
using MemoKu.POS.Mvc.Exceptions;
using MemoKu.POS.Mvc.Interface;
using MemoKu.POS.Mvc.Modes;
using MemoKu.Test.context;

namespace MemoKu.Test
{
    [Subject("Add Item")]
    public class when_add_item_with_no_data : test_base_mode_with_no_data
    {
        static ScanMode scanMode;
        static Exception ex;
        Establish ctx = () =>
        {
            scanMode = new ScanMode(mainCtrl, mainView, modeCtrl, searchPartView);
        };

        Because of = () =>
        {
            ex = Catch.Exception(() =>
            {
                scanMode.OnKeyEnterPress("001");
            });
        };

        It should_throw_exception_with_type_ProductNotFoundException = () =>
        {
            ex.GetType().ShouldEqual(typeof(ProductNotFoundException));
        };
    }
}
