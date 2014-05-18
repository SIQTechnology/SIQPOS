using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MemoKu.POS.Mvc.Sessions;
using StructureMap;

namespace MemoKu.POS.Mvc
{
    public class Context
    {
        public static SessionHolder Session
        {
            get
            {
                return ObjectFactory.GetInstance<SessionHolder>();
            }
        }
    }
}
