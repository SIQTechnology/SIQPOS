using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Machine.Specifications;
using MemoKu.POS.Mvc.Controller;
using MemoKu.POS.Mvc.Interface;
using MemoKu.Test.context;

namespace MemoKu.Test
{
    public class test_base_mode : TestBase
    {
        protected static IMainController mainCtrl;
        protected static IMainView mainView;
        protected static ISearchPartView searchPartView;
        protected static IModeController modeCtrl;
        Establish ctx = () =>
        {
            mainView = new Moq.Mock<IMainView>().Object;
            searchPartView = new Moq.Mock<ISearchPartView>().Object;
            mainCtrl = new MainController(mainView, searchPartView);
            modeCtrl = new ModeController(mainCtrl, mainView, searchPartView);
        };
    }
}
