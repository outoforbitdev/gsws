using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GSWS.Assets.Server;

namespace GSWS.Assets.Tests.Server
{
    [TestClass]
    public class WeaponTest
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
        private Weapon _testWeapon()
        {
            WeaponModel model =  new WeaponModel()
            {
                ID = "test",
                ReloadTimer = 2,
                Capacity = 2,
                Damage = 10
            };
            return new Weapon(model);
        }
        [TestMethod]
        public void Fire_CapacityWeapon_TimerCapacity()
        {
            Weapon test = _testWeapon();
            Assert.AreEqual(test.Fire(), 10);
            Assert.AreEqual(test.ReloadTimer, 2);
            Assert.AreEqual(test.Capacity, 1);
        }
        [TestMethod]
        public void Fire_NoCapacityWeapon_TimerCapacity()
        {
            Weapon test = _testWeapon();
            test.Model.Capacity = 0;
            test.Capacity = 0;
            Assert.AreEqual(test.Fire(), 10);
            Assert.AreEqual(test.ReloadTimer, 2);
            Assert.AreEqual(test.Capacity, 0);
        }
        [TestMethod]
        public void Fire_EmptyWeapon_NoDamage()
        {
            Weapon test = _testWeapon();
            test.Capacity = 0;
            Assert.AreEqual(test.Fire(), 0);
        }
        [TestMethod]
        public void Reload__()
        {
            Weapon test = _testWeapon();
            test.Fire();
            test.Reload();
            Assert.AreEqual(test.ReloadTimer, 1);
        }
    }
}
