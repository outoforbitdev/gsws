using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSWS.Assets.Database
{
    class Lock
    {
        private LockCollection Locks;

        public Lock(LockCollection locks)
        {
            Locks = locks;
        }
    }
}
