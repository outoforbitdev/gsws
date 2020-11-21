using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSWS.Assets.Database
{
    internal enum LockType { ReadExclusive, ReadShared, EditExclusive, EditShared };
    internal class Lock
    {
        private LockCollection Locks;
        private LockType Type;

        public Lock(LockCollection locks, LockType type)
        {
            Locks = locks;
            Type = type;
        }

        public void Release()
        {
            switch(Type)
            {
                case LockType.ReadExclusive:
                    Locks.ReleaseReadExclusiveLock(this);
                    break;
                case LockType.ReadShared:
                    Locks.ReleaseReadSharedLock(this);
                    break;
                case LockType.EditExclusive:
                    Locks.ReleaseEditExclusiveLock(this);
                    break;
                case LockType.EditShared:
                    Locks.ReleaseEditSharedLock(this);
                    break;
            }
        }
    }
}
