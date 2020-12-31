using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSWS.Assets.Database
{
    public class Database
    {
        private Dictionary<string, Collection<Item, ReadItem<Item>>> Collections;

        public Database()
        {
            Collections = new Dictionary<string, Collection<Item, ReadItem<Item>>>();
        }

        public bool TryGetCollection(string collectionName, out Collection<Item, ReadItem<Item>> collection)
        {
            return Collections.TryGetValue(collectionName, out collection);
        }
        public bool TryGetItemEditExclusive(string collectionName, string itemID, out EditItem<Item> item)
        {
            item = null;
            Collection<Item, ReadItem<Item>> collection;
            if (TryGetCollection(collectionName, out collection))
            {
                return collection.TryGetEditExclusive(itemID, out item);
            }
            return false;
        }
        public bool TryGetItemEditShared(string collectionName, string itemID, out EditItem<Item> item)
        {
            item = null;
            Collection<Item, ReadItem<Item>> collection;
            if (TryGetCollection(collectionName, out collection))
            {
                return collection.TryGetEditShared(itemID, out item);
            }
            return false;
        }
        public bool TryGetItemReadExclusive(string collectionName, string itemID, out ReadItem<Item> item)
        {
            item = null;
            Collection<Item, ReadItem<Item>> collection;
            if (TryGetCollection(collectionName, out collection))
            {
                return collection.TryGetReadExclusive(itemID, out item);
            }
            return false;
        }
        public bool TryGetItemReadShared(string collectionName, string itemID, out ReadItem<Item> item)
        {
            item = null;
            Collection<Item, ReadItem<Item>> collection;
            if (TryGetCollection(collectionName, out collection))
            {
                return collection.TryGetReadShared(itemID, out item);
            }
            return false;
        }
        public bool TryGetItemClone(string collectionName, string itemID, out Item item)
        {
            item = null;
            Collection<Item, ReadItem<Item>> collection;
            if (TryGetCollection(collectionName, out collection))
            {
                return collection.TryGetClone(itemID, out item);
            }
            return false;
        }
    }
}
