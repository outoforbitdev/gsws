using Microsoft.VisualStudio.TestTools.UnitTesting;
using GSWS.Assets.Database;

namespace GSWS.Assets.Tests.Database
{
    using TestCollection = LocalCollection<TestItem, ReadTestItem>;
    [TestClass]
    public class LocalCollectionTest
    {
        private TestCollection EmptyCollection()
        {
            Assets.Database.Database db = new Assets.Database.Database();
            return new TestCollection(db);
        }
        private TestCollection ExampleCollection()
        {
            TestCollection collection = EmptyCollection();
            collection.TryAdd(new TestItem("zero", 0));
            collection.TryAdd(new TestItem("one", 1));
            collection.TryAdd(new TestItem("two", 2));
            return collection;
        }
        [TestMethod]
        public void Constructor_TestItems_Success()
        {
            EmptyCollection();
            Assert.IsTrue(true);
        }
        [TestMethod]
        public void Add_UniqueItems_Success()
        {
            TestCollection collection = EmptyCollection();
            Assert.IsTrue(collection.TryAdd(new TestItem("zero", 0)));
            Assert.IsTrue(collection.TryAdd(new TestItem("one", 1)));
            Assert.IsTrue(collection.TryAdd(new TestItem("two", 2)));
        }
        [TestMethod]
        public void Add_DuplicateItems_Failure()
        {
            TestCollection collection = EmptyCollection();
            Assert.IsTrue(collection.TryAdd(new TestItem("zero", 0)));
            Assert.IsFalse(collection.TryAdd(new TestItem("zero", 0)));
            Assert.IsFalse(collection.TryAdd(new TestItem("zero", 1)));
        }
        [TestMethod]
        public void ReadExclusive_NoLocks_Success()
        {
            ReadTestItem item;
            string lockId;
            TestCollection collection = ExampleCollection();
            Assert.IsTrue(collection.TryGetReadExclusive("zero", out item, out lockId));
        }
    }
}
