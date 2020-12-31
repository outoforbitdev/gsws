using System;
using System.Collections.Generic;
using System.Text;

namespace GSWS.Assets.Database
{
    public class LinkedItem<T> where T: Item
    {
        public string ItemID;
        public string Collection;

        public LinkedItem()
        {

        }

        public bool TryGetClone(Database database, out Item item)
        {
            item = null;
            Collection<Item, ReadItem<Item>> collection;

            if (database.TryGetCollection(Collection, out collection))
            {
                return collection.TryGetClone(ItemID, out item);
            }
            return false;
        }
        public bool TryGetEditExclusive(Database database, out EditItem<Item> item)
        {
            item = null;
            Collection<Item, ReadItem<Item>> collection;

            if (database.TryGetCollection(Collection, out collection))
            {
                return collection.TryGetEditExclusive(ItemID, out item);
            }
            return false;
        }
        public bool TryGetEditShared(Database database, out EditItem<Item> item)
        {
            item = null;
            Collection<Item, ReadItem<Item>> collection;

            if (database.TryGetCollection(Collection, out collection))
            {
                return collection.TryGetEditShared(ItemID, out item);
            }
            return false;
        }
        public bool TryGetReadExclusive(Database database, out ReadItem<Item> item)
        {
            item = null;
            Collection<Item, ReadItem<Item>> collection;

            if (database.TryGetCollection(Collection, out collection))
            {
                return collection.TryGetReadExclusive(ItemID, out item);
            }
            return false;
        }
        public bool TryGetReadShared(Database database, out ReadItem<Item> item)
        {
            item = null;
            Collection<Item, ReadItem<Item>> collection;

            if (database.TryGetCollection(Collection, out collection))
            {
                return collection.TryGetReadShared(ItemID, out item);
            }
            return false;
        }
    }
}
