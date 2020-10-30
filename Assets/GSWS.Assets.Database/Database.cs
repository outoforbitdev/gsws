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

        //public bool TryGetItem(string collectionName, string itemId, IItem item)
        //{
        //    Collection<IItem, IItem> collection;
        //    if (TryGetCollection(collectionName, out collection))
        //    {
        //        return collection.
        //    }
        //}
    }
}
