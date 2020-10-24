using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GSWS.Assets.Server;

namespace GSWS.Assets.Tests.Server
{
    [TestClass]
    public class WeaponModelTest
    {
        [TestMethod]
        public void ID_SetWhenNull_NewValue()
        {
            var testWM = new WeaponModel();
            testWM.ID = "test";
            Assert.AreEqual("test", testWM.ID);
        }
        [TestMethod]
        public void ID_SetWhenNotNull_OldValue()
        {
            var testWM = new WeaponModel();
            testWM.ID = "test";
            testWM.ID = "new test";
            Assert.AreEqual("test", testWM.ID);
        }
        [TestMethod]
        public void Accuracy_SetValidValue_NewValue()
        {
            var testWM = new WeaponModel();
            testWM.Accuracy = .5f;
            Assert.AreEqual(.5f, testWM.Accuracy);
        }
        [TestMethod]
        public void Accuracy_SetInvalidLargeValue_OldValue()
        {
            var testWM = new WeaponModel();
            testWM.Accuracy = 1.2f;
            Assert.AreEqual(0, testWM.Accuracy);
        }
        [TestMethod]
        public void Accuracy_SetInvalidSmallValue_OldValue()
        {
            var testWM = new WeaponModel();
            testWM.Accuracy = -.2f;
            Assert.AreEqual(0, testWM.Accuracy);
        }
        [TestMethod]
        public void Damage_SetValidValue_OldValue()
        {
            var testWM = new WeaponModel();
            testWM.Damage = 1;
            Assert.AreEqual(1, testWM.Damage);
        }
        [TestMethod]
        public void Damage_SetInvalidValue_OldValue()
        {
            var testWM = new WeaponModel();
            testWM.Damage = -1;
            Assert.AreEqual(0, testWM.Damage);
        }
        [TestMethod]
        public void Capacity_SetValidValue_OldValue()
        {
            var testWM = new WeaponModel();
            testWM.Capacity = 1;
            Assert.AreEqual(1, testWM.Capacity);
        }
        [TestMethod]
        public void Capacity_SetInvalidValue_OldValue()
        {
            var testWM = new WeaponModel();
            testWM.Capacity = -1;
            Assert.AreEqual(0, testWM.Capacity);
        }
    }
}
