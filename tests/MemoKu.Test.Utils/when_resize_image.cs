using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Machine.Specifications;
using MemoKu.POS.Utils;

namespace MemoKu.Test.Utils
{
    [Subject("Resize Logo")]
    class when_resize_image
    {
        static Image img;
        static Image imgAfterResize;
        static int widthBeforeResize;
        static int heightBeforeResize;
        Establish context = () =>
        {
            img = Image.FromFile(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"images\default-logo-organization.png"));
            widthBeforeResize = img.Width;
            heightBeforeResize = img.Height;
        };

        Because of = () =>
        {
            imgAfterResize = img.ResizeToImage(133, 96);
        };

        It before_width_should_be_less_than_after = () =>
        {
            imgAfterResize.Width.ShouldBeLessThanOrEqualTo(widthBeforeResize);
        };

        It before_height_should_be_less_than_after = () =>
        {
            imgAfterResize.Height.ShouldBeLessThanOrEqualTo(heightBeforeResize);
        };
    }
}
