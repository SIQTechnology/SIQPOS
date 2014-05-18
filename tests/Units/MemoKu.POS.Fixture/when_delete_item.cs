using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Machine.Specifications;
using MemoKu.POS.Domain.Aggregate;
using MemoKu.POS.Fixture.Contexts;

namespace MemoKu.POS.Fixture
{
    [Subject(typeof(ShoppingCart))]
    class when_delete_item : behave_like_item_added
    {
        Because of = () =>
        {
            _sc.DeleteItem(itemId, "Apin Wu");
        };

        It item_should_be_deleted = () =>
        {
            _sc.Items.FirstOrDefault(i => i.Id.Equals(itemId)).ShouldBeNull();
        };

        It net_total_should_equals_3000 = () =>
        {
            _sc.Summary.NetAmount.ShouldEqual(3000);
        };

        It items_removed_should_be_added = () =>
        {
            _sc.ItemsRemoved.Count.ShouldEqual(1);
        };

        It item_removed_should_remove_by_Apin_Wu = () =>
        {
            _sc.ItemsRemoved.FirstOrDefault().RemoveBy.ShouldEqual("Apin Wu");
        };
    }
}
