using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSWS.Assets.Database
{
    internal class LockCollection
    {
        private List<Lock> ReadExclusive;
        private List<Lock> ReadShared;
        private List<Lock> EditShared;
        private Lock EditExclusive;

        public LockCollection()
        {
            ReadExclusive = new List<Lock>();
            ReadShared = new List<Lock>();
            EditShared = new List<Lock>();
            EditExclusive = null;
        }
        public bool IsEmpty()
        {
            return
                EditShared.Count == 0 &&
                EditExclusive == null &&
                ReadExclusive.Count == 0 &&
                ReadShared.Count == 0;
        }
        #region Has Locks
        public bool HasEditLock()
        {
            return (EditShared.Count > 0) || HasEditExclusiveLock();
        }
        public bool HasEditExclusiveLock()
        {
            return EditExclusive != null;
        }
        public bool HasReadExclusiveLock()
        {
            return ReadExclusive.Count > 0;
        }
        #endregion
        #region Get Locks
        private string _GenerateLockId(string id)
        {
            return id + "*" + Guid.NewGuid().ToString();
        }
        public bool TryGetReadExclusiveLock(string id, out Lock objectLock)
        {
            if (HasEditLock())
            {
                objectLock = null;
                return false;
            }
            objectLock = new Lock(this, LockType.ReadExclusive);
            ReadExclusive.Add(objectLock);
            return true;
        }
        public bool TryGetReadSharedLock(string id, out Lock objectLock)
        {
            objectLock = new Lock(this, LockType.ReadShared);
            ReadShared.Add(objectLock);
            return true;
        }
        public bool TryGetEditExclusiveLock(string id, out Lock objectLock)
        {
            if (HasReadExclusiveLock() || HasEditLock())
            {
                objectLock = null;
                return false;
            }
            objectLock = new Lock(this, LockType.EditExclusive);
            EditExclusive = objectLock;
            return true;
        }
        public bool TryGetEditSharedLock(string id, out Lock objectLock)
        {
            if (HasReadExclusiveLock() || HasEditExclusiveLock())
            {
                objectLock = null;
                return false;
            }
            objectLock = new Lock(this, LockType.EditShared);
            EditShared.Add(objectLock);
            return true;
        }
        #endregion
        #region Release Locks
        private bool _releaseLock(Lock objectLock, List<Lock> locks)
        {
            return locks.RemoveAll((Lock value) => value == objectLock) > 0;
        }
        public bool ReleaseLock(Lock objectLock)
        {
            return
                ReleaseEditExclusiveLock(objectLock) ||
                ReleaseEditSharedLock(objectLock) ||
                ReleaseReadExclusiveLock(objectLock) ||
                ReleaseReadSharedLock(objectLock);
        }
        public bool ReleaseReadExclusiveLock(Lock objectLock)
        {
            return _releaseLock(objectLock, ReadExclusive);
        }
        public bool ReleaseReadSharedLock(Lock objectLock)
        {
            return _releaseLock(objectLock, ReadShared);
        }
        public bool ReleaseEditExclusiveLock(Lock objectLock)
        {
            if (objectLock == EditExclusive)
            {
                EditExclusive = null;
                return true;
            }
            return false;
        }
        public bool ReleaseEditSharedLock(Lock objectLock)
        {
            return _releaseLock(objectLock, EditShared);
        }
        #endregion
    }
}
