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
    abstract public class WeaponModel
    {
        [XmlAttribute] public string ID { get; set; }
        public string Name { get; set; }
        public float Damage { get; set; }
        public float Accuracy { get; set; }
        public int Capacity { get; set; }

        public WeaponModel() : this("", "", 0, 0, 0) { }
        public WeaponModel(string id, string name, float damage, float accuracy, int capacity)
        {
            ID = id;
            Name = name;
            Damage = damage;
            Accuracy= accuracy;
            Capacity = capacity;
        }
    }
}