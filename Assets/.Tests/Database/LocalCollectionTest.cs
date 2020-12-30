using Microsoft.VisualStudio.TestTools.UnitTesting;
using GSWS.Assets.Database;
using System.IO;

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
        public void Save_TestItems_ThreeItems()
        {
            string filename = Directory.GetCurrentDirectory().Split("bin")[0] + "test_database_file.xml";
            //Assert.AreEqual("C:\\Users\\jmorr\\Documents\\GitHub\\gsws\\Assets\\.Tests\\Database\\test_database_file.xml", filename);
            Assert.IsTrue(ExampleCollection().Save(filename));
        }
        #region Add
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
        #endregion
        #region ReadExclusive
        [TestMethod]
        public void ReadExclusive_NoLocks_Success()
        {
            ReadTestItem item;
            TestCollection collection = ExampleCollection();
            Assert.IsTrue(collection.TryGetReadExclusive("zero", out item));
            Assert.AreEqual(item.ID, "zero");
            Assert.AreEqual(item.Field, 0);
        }
        [TestMethod]
        public void ReadExclusive_RELocks_Success()
        {
            ReadTestItem itemOne;
            ReadTestItem itemTwo;
            TestCollection collection = ExampleCollection();
            Assert.IsTrue(collection.TryGetReadExclusive("zero", out itemOne));
            Assert.IsTrue(collection.TryGetReadExclusive("zero", out itemTwo));
            Assert.AreEqual(itemOne.ID, "zero");
            Assert.AreEqual(itemOne.Field, 0);
            Assert.AreEqual(itemTwo.ID, "zero");
            Assert.AreEqual(itemTwo.Field, 0);
        }
        [TestMethod]
        public void ReadExclusive_ReadMixedLocks_Success()
        {
            ReadTestItem itemOne;
            ReadTestItem itemTwo;
            ReadTestItem itemThree;
            TestCollection collection = ExampleCollection();
            Assert.IsTrue(collection.TryGetReadShared("zero", out itemOne));
            Assert.IsTrue(collection.TryGetReadExclusive("zero", out itemTwo));
            Assert.IsTrue(collection.TryGetReadExclusive("zero", out itemThree));
            Assert.AreEqual(itemOne.ID, "zero");
            Assert.AreEqual(itemOne.Field, 0);
            Assert.AreEqual(itemTwo.ID, "zero");
            Assert.AreEqual(itemTwo.Field, 0);
            Assert.AreEqual(itemThree.ID, "zero");
            Assert.AreEqual(itemThree.Field, 0);
        }
        [TestMethod]
        public void ReadExclusive_EditSharedLocks_Failure()
        {
            EditItem<TestItem> editItem;
            ReadTestItem item;
            TestCollection collection = ExampleCollection();
            Assert.IsTrue(collection.TryGetEditShared("zero", out editItem));
            Assert.IsFalse(collection.TryGetReadExclusive("zero", out item));
        }
        public void ReadExclusive_EditExclusiveLock_Failure()
        {
            EditItem<TestItem> editItem;
            ReadTestItem item;
            TestCollection collection = ExampleCollection();
            Assert.IsTrue(collection.TryGetEditExclusive("zero", out editItem));
            Assert.IsFalse(collection.TryGetReadExclusive("zero", out item));
        }
        #endregion
        #region ReadShared
        [TestMethod]
        public void ReadShared_NoLocks_Success()
        {
            ReadTestItem item;
            TestCollection collection = ExampleCollection();
            Assert.IsTrue(collection.TryGetReadShared("zero", out item));
            Assert.AreEqual(item.ID, "zero");
            Assert.AreEqual(item.Field, 0);
        }
        [TestMethod]
        public void ReadShared_RSLocks_Success()
        {
            ReadTestItem itemOne;
            ReadTestItem itemTwo;
            TestCollection collection = ExampleCollection();
            Assert.IsTrue(collection.TryGetReadShared("zero", out itemOne));
            Assert.IsTrue(collection.TryGetReadShared("zero", out itemTwo));
            Assert.AreEqual(itemOne.ID, "zero");
            Assert.AreEqual(itemOne.Field, 0);
            Assert.AreEqual(itemTwo.ID, "zero");
            Assert.AreEqual(itemTwo.Field, 0);
        }
        [TestMethod]
        public void ReadShared_ReadMixedLocks_Success()
        {
            ReadTestItem itemOne;
            ReadTestItem itemTwo;
            ReadTestItem itemThree;
            TestCollection collection = ExampleCollection();
            Assert.IsTrue(collection.TryGetReadExclusive("zero", out itemOne));
            Assert.IsTrue(collection.TryGetReadShared("zero", out itemTwo));
            Assert.IsTrue(collection.TryGetReadShared("zero", out itemThree));
            Assert.AreEqual(itemOne.ID, "zero");
            Assert.AreEqual(itemOne.Field, 0);
            Assert.AreEqual(itemTwo.ID, "zero");
            Assert.AreEqual(itemTwo.Field, 0);
            Assert.AreEqual(itemThree.ID, "zero");
            Assert.AreEqual(itemThree.Field, 0);
        }
        [TestMethod]
        public void ReadShared_EditSharedLocks_Success()
        {
            EditItem<TestItem> editItem;
            ReadTestItem item;
            TestCollection collection = ExampleCollection();
            Assert.IsTrue(collection.TryGetEditShared("zero", out editItem));
            Assert.IsTrue(collection.TryGetReadShared("zero", out item));
            Assert.AreEqual(editItem.Original.Field, item.Field);
            editItem.Original.Field = editItem.Original.Field++;
            Assert.AreEqual(editItem.Original.Field, item.Field);
        }
        public void ReadShared_EditExclusiveLock_Success()
        {
            EditItem<TestItem> editItem;
            ReadTestItem item;
            TestCollection collection = ExampleCollection();
            Assert.IsTrue(collection.TryGetEditExclusive("zero", out editItem));
            Assert.IsTrue(collection.TryGetReadShared("zero", out item));
            Assert.AreEqual(editItem.Original.Field, item.Field);
            editItem.Original.Field = editItem.Original.Field++;
            Assert.AreEqual(editItem.Original.Field, item.Field);
        }
        #endregion
    }
}
