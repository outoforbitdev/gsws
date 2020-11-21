using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSWS.Assets.Database
{
    abstract public class Collection<T, ReadT>
        where T: Item
        where ReadT : ReadItem<T>
    {
        internal Dictionary<string, LockCollection> Locks;
        protected Database DB;

        public Collection(Database db)
        {
            DB = db;
            Locks = new Dictionary<string, LockCollection>();
        }
        abstract public bool TryAdd(T item);
        abstract public bool TryGetReadExclusive(string id, out ReadT item);
        abstract public bool TryGetReadShared(string id, out ReadT item);
        abstract public bool TryGetEditExclusive(string id, out EditItem<T> item);
        abstract public bool TryGetEditShared(string id, out EditItem<T> item);
        abstract public bool TryGetClone(string id, out T item);
        private void _EnsureLockCollection(string id)
        {
            if (!Locks.ContainsKey(id))
            {
                Locks.Add(id, new LockCollection());
            }
        }
        internal bool TryGetReadExclusiveLock(string id, out Lock objectLock)
        {
            _EnsureLockCollection(id);
            return Locks[id].TryGetReadExclusiveLock(id, out objectLock);
        }
        internal bool TryGetReadSharedLock(string id, out Lock objectLock)
        {
            _EnsureLockCollection(id);
            return Locks[id].TryGetReadSharedLock(id, out objectLock);
        }
        internal bool TryGetEditExclusiveLock(string id, out Lock objectLock)
        {
            _EnsureLockCollection(id);
            return Locks[id].TryGetEditExclusiveLock(id, out objectLock);
        }
        internal bool TryGetEditSharedLock(string id, out Lock objectLock)
        {
            _EnsureLockCollection(id);
            return Locks[id].TryGetEditSharedLock(id, out objectLock);
        }
    }
}
