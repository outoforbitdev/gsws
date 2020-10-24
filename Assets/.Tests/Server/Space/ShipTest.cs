using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GSWS.Assets.Server;
using System.Collections.Generic;

namespace GSWS.Assets.Tests.Server
{
    [TestClass]
    public class ShipTest
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
        private static Ship _testShip()
        {
            ShipModel testModel = new ShipModel()
            {
                Shields = 10,
                HullStrength = 20,
                OffensiveWeapons = new List<WeaponModel>() { new WeaponModel() { ID = "offense", ReloadTimer = 2 } },
                DefensiveWeapons = new List<WeaponModel>() { new WeaponModel() { ID = "defense", ReloadTimer = 2 } }
            };
            return new Ship() { Model = testModel };
        }
        [TestMethod]
        public void Reset__()
        {
            Ship test = _testShip();
            test.Reset();
            Assert.AreEqual(test.Shields, 10);
            Assert.AreEqual(test.HullStrength, 20);
            Assert.AreEqual(test.OffensiveWeapons[0].Model.ID, "offense");
            Assert.AreEqual(test.DefensiveWeapons[0].Model.ID, "defense");
        }
        [TestMethod]
        public void Reload__()
        {
            Ship test = _testShip();
            test.Reset();
            test.Shields = 0;
            test.OffensiveWeapons[0].Fire();
            test.DefensiveWeapons[0].Fire();
            test.Reload();
            Assert.AreEqual(test.Shields, 1);
            Assert.AreEqual(test.OffensiveWeapons[0].ReloadTimer, 1);
            Assert.AreEqual(test.DefensiveWeapons[0].ReloadTimer, 1);
        }
    }
}
