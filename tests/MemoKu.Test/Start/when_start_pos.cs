using System;
using Machine.Specifications;
using MemoKu.POS.Mvc.Controller;
using MemoKu.POS.Mvc.Exceptions;
using MemoKu.POS.Mvc.Interface;
using MemoKu.Test.context;

namespace MemoKu.Test
{
    [Subject("Start POS")]
    public class when_start_pos : TestBase
    {
        static IMainController mainCtrl;
        static Exception ex;
        Establish ctx = () =>
        {
            IMainView mainView = new Moq.Mock<IMainView>().Object;
            ISearchPartView searchPartView = new Moq.Mock<ISearchPartView>().Object;
            mainCtrl = new MainController(mainView, searchPartView);
        };

        Because of = () =>
        {
            ex = Catch.Exception(() => { mainCtrl.Start(); });
        };

        It should_have_not_error = () =>
        {
            ex.ShouldBeNull();
        };
    }
}
