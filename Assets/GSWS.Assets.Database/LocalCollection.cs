using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSWS.Assets.Database
{
    public class LocalCollection<EditT, ReadT>: Collection<EditT, ReadT>
        where EditT: Item
        where ReadT: ReadItem<EditT>, new()
    {
        private Dictionary<string, EditT> Items;
        public LocalCollection(Database db) : base(db) { }

        public override bool TryAdd(EditT item)
        {
            if (Items.ContainsKey(item.ID))
            {
                Items.Add(item.ID, item);
                return true;
            }
            return false;
        }
        public override bool TryGetReadExclusive(string id, out ReadT item, out string lockId)
        {
            item = null;
            lockId = null;
            if (Items.ContainsKey(id))
            {
                if (Locks[id].TryGetReadExclusiveLock(id, out lockId))
                {
                    item = new ReadT();
                    item.SetOriginal(Items[id]);
                    return true;
                }
            }
            return false;
        }
        public override bool TryGetReadShared(string id, out ReadT item, out string lockId)
        {
            item = null;
            lockId = null;
            if (Items.ContainsKey(id))
            {
                if (Locks[id].TryGetReadSharedLock(id, out lockId))
                {
                    item = new ReadT();
                    item.SetOriginal(Items[id]);
                    return true;
                }
            }
            return false;
        }
        public override bool TryGetEditExclusive(string id, out EditT item, out string lockId)
        {
            item = null;
            lockId = null;
            if (Items.ContainsKey(id))
            {
                if (Locks[id].TryGetEditExclusiveLock(id, out lockId))
                {
                    item = Items[id];
                    return true;
                }
            }
            return false;
        }
        public override bool TryGetEditShared(string id, out EditT item, out string lockId)
        {
            item = null;
            lockId = null;
            if (Items.ContainsKey(id))
            {
                if (Locks[id].TryGetEditSharedLock(id, out lockId))
                {
                    item = Items[id];
                    return true;
                }
            }
            return false;
        }
    }
}
