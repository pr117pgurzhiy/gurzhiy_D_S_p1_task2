using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Florist
{
    class Instances
    {
        private static user8Entities1 _db = new user8Entities1();
        public static user8Entities1 db // создание элемента bd
        {
            get
            {
                if (_db == null)
                    _db = new user8Entities1(); 
                return _db;
            }
        }
    }
}
