////////////////////////////////////////////////////////////////////////////////
//                                                                            //
//                                 Weapon.cs                                  //
//                                Weapon class                                //
//            Created by: Jarett (Jay) Mirecki, September 02, 2019            //
//            Modified by: Jarett (Jay) Mirecki, October 09, 2019             //
//                                                                            //
////////////////////////////////////////////////////////////////////////////////

using System;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace GSWS.Assets.Server
{
    [Serializable]
    public class WeaponModel : Object
    {
        #region Object Methods
        public override void VerifySubGroups() { }
        public override void UpdateValues(Database db) { }
        public override string DatapadDescription() 
        {
            return Name;
        }
        public override void UpdateKeys() { }
        public override void UpdateSuperGroups() { }
        public override string ToString()
        {
            return Name;
        }
        #endregion
        #region Properties
        public string Name { get; set; }
        private float _damage;
        public float Damage
        {
            get
            {
                return _damage;
            }
            set
            {
                if (value >= 0)
                {
                    _damage = value;
                }
            }
        }
        private float _accuracy;
        public float Accuracy
        {
            get
            {
                return _accuracy;
            }
            set
            {
                if (value <= 1 && value >=0)
                    _accuracy = value;
            }
        }
        private int _capacity;
        public int Capacity { 
            get
            {
                return _capacity;
            }
            set
            {
                if (value >= 0)
                {
                    _capacity = value;
                }
            }
        }
        #endregion
        #region Constructors
        public WeaponModel() : this("", "", 0, 0, 0) { }
        public WeaponModel(string id, string name, float damage, float accuracy, int capacity)
        {
            ID = id;
            Name = name;
            Damage = damage;
            Accuracy= accuracy;
            Capacity = capacity;
        }
        #endregion
    }
}