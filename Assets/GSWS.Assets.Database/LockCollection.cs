using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSWS.Assets.Database
{
    internal class LockCollection
    {
        private List<string> ReadExclusive;
        private List<string> ReadShared;
        private List<string> EditShared;
        private string EditExclusive;

        public LockCollection()
        {
            ReadExclusive = new List<string>();
            ReadShared = new List<string>();
            EditShared = new List<string>();
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
        public bool TryGetReadExclusiveLock(string id, out string lockId)
        {
            lockId = null;
            if (!HasEditLock())
            {
                lockId = _GenerateLockId(id);
                ReadExclusive.Add(lockId);
                return true;
            }
            return false;
        }
        public bool TryGetReadSharedLock(string id, out string lockId)
        {
            lockId = _GenerateLockId(id);
            ReadShared.Add(lockId);
            return true;
        }
        public bool TryGetEditExclusiveLock(string id, out string lockId)
        {
            lockId = null;
            if (!HasReadExclusiveLock())
            {
                lockId = _GenerateLockId(id);
                EditExclusive = lockId;
                return true;
            }
            return false;
        }
        public bool TryGetEditSharedLock(string id, out string lockId)
        {
            lockId = null;
            if (!(HasReadExclusiveLock() || HasEditExclusiveLock()))
            {
                lockId = _GenerateLockId(id);
                EditShared.Add(lockId);
                return true;
            }
            return false;
        }
        #endregion
        #region Release Locks
        private bool _releaseLock(string lockId, List<string> locks)
        {
            return locks.RemoveAll((string value) => value == lockId) > 0;
        }
        public bool ReleaseLock(string lockId)
        {
            return
                ReleaseEditExclusiveLock(lockId) ||
                ReleaseEditSharedLock(lockId) ||
                ReleaseReadExclusiveLock(lockId) ||
                ReleaseReadSharedLock(lockId);
        }
        public bool ReleaseReadExclusiveLock(string lockId)
        {
            return _releaseLock(lockId, ReadExclusive);
        }
        public bool ReleaseReadSharedLock(string lockId)
        {
            return _releaseLock(lockId, ReadShared);
        }
        public bool ReleaseEditExclusiveLock(string lockId)
        {
            if (lockId == EditExclusive)
            {
                EditExclusive = null;
                return true;
            }
            return false;
        }
        public bool ReleaseEditSharedLock(string lockId)
        {
            return _releaseLock(lockId, EditShared);
        }
        #endregion
    }
}
