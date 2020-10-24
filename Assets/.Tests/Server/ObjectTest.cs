using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GSWS.Assets.Server;

namespace GSWS.Assets.Tests.Server
{
    [TestClass]
    public class ObjectTest
    {
        [TestMethod]
        public void ID_SetWhenNull_NewValue()
        {
            var test = new Ship();
            test.ID = "test";
            Assert.AreEqual("test", test.ID);
        }
        [TestMethod]
        public void ID_SetWhenNotNull_OldValue()
        {
            var test = new Ship();
            test.ID = "test";
            test.ID = "new test";
            Assert.AreEqual("test", test.ID);
        }
    }
}
