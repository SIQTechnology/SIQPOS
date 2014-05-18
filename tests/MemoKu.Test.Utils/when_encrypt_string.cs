using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Machine.Specifications;
using MemoKu.POS.Utils;

namespace MemoKu.Test.Utils
{
    [Subject("Encrtyption")]
    public class when_encrypt_string
    {
        static string text = "123";
        It should_be_encrypted = () =>
        {
            var result = text.EncryptToString();
            result.ShouldNotEqual("");
        };
    }
}
