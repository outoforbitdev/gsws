using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSWS.Assets.Database
{
    abstract public class Collection<EditT, ReadT>
        where EditT: Item
        where ReadT : ReadItem<EditT>
    {
        internal Dictionary<string, LockCollection> Locks;
        protected Database DB;

        public Collection(Database db)
        {
            DB = db;
            Locks = new Dictionary<string, LockCollection>();
        }
        abstract public bool TryAdd(EditT item);
        abstract public bool TryGetReadExclusive(string id, out ReadT item, out string lockId);
        abstract public bool TryGetReadShared(string id, out ReadT item, out string lockId);
        abstract public bool TryGetEditExclusive(string id, out EditT item, out string lockId);
        abstract public bool TryGetEditShared(string id, out EditT item, out string lockId);
        abstract public bool TryGetClone(string id, out EditT item);
        private void _EnsureLockCollection(string id)
        {
            if (!Locks.ContainsKey(id))
            {
                Locks.Add(id, new LockCollection());
            }
        }
        protected bool TryGetReadExclusiveLock(string id, out string lockId)
        {
            _EnsureLockCollection(id);
            return Locks[id].TryGetReadExclusiveLock(id, out lockId);
        }
        protected bool TryGetReadSharedLock(string id, out string lockId)
        {
            _EnsureLockCollection(id);
            return Locks[id].TryGetReadSharedLock(id, out lockId);
        }
        protected bool TryGetEditExclusiveLock(string id, out string lockId)
        {
            _EnsureLockCollection(id);
            return Locks[id].TryGetEditExclusiveLock(id, out lockId);
        }
        protected bool TryGetEditSharedLock(string id, out string lockId)
        {
            _EnsureLockCollection(id);
            return Locks[id].TryGetEditSharedLock(id, out lockId);
        }
        public bool ReleaseLock(string lockId)
        {
            bool success = false;
            string id = lockId.Split('*')[0];
            LockCollection locks;
            if (Locks.TryGetValue(id, out locks))
            {
                success = locks.ReleaseLock(lockId);
                if (locks.IsEmpty())
                {
                    Locks.Remove(id);
                }
            }
            return false;
        }
    }
}
