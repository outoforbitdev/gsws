using System;
using System.Collections.Generic;
using System.Text;

namespace GSWS.Assets.Database
{
    public class LinkedItem
    {
        public string ItemID;
        public string Collection;

        public LinkedItem()
        {

        }

        public LinkedItem(string collection, string itemID)
        {
            ItemID = itemID;
            Collection = collection;
        }

        public bool TryGetClone(Database database, out Item item)
        {
            return database.TryGetItemClone(Collection, ItemID, out item);
        }
        public bool TryGetEditExclusive(Database database, out EditItem<Item> item)
        {
            return database.TryGetItemEditExclusive(Collection, ItemID, out item);
        }
        public bool TryGetEditShared(Database database, out EditItem<Item> item)
        {
            return database.TryGetItemEditShared(Collection, ItemID, out item);
        }
        public bool TryGetReadExclusive(Database database, out ReadItem<Item> item)
        {
            return database.TryGetItemReadExclusive(Collection, ItemID, out item);
        }
        public bool TryGetReadShared(Database database, out ReadItem<Item> item)
        {
            return database.TryGetItemReadShared(Collection, ItemID, out item);
        }
    }
}
