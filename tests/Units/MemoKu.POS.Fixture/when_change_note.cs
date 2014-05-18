using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Machine.Specifications;

namespace MemoKu.POS.Fixture
{
    public class when_change_note : Contexts.behave_like_shopping_cart_created
    {
        Because of = () =>
        {
            _sc.ChangeNote("Test 1 2 3");
        };

        It note_should_be_changed = () =>
        {
            _sc.Note.ShouldEqual("Test 1 2 3");
        };
    }
}
