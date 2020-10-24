////////////////////////////////////////////////////////////////////////////////
//                                                                            //
//                                  Weapon.cs                                 //
//                                Weapon class                                //
//            Created by: Jarett (Jay) Mirecki, October 22, 2020              //
//            Modified by: Jarett (Jay) Mirecki, October 22, 2020             //
//                                                                            //
////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace GSWS.Assets.Server
{
    [Serializable]
    public class Weapon
    {
        [XmlIgnore]
        public WeaponModel Model { get; set; }
        public string kModel { get; set; }
        public float ReloadTimer { get; set; }
        public int Capacity { get; set; }

        public Weapon(WeaponModel model)
        {
            Model = model;
            ReloadTimer = 0;
            Capacity = Model.Capacity;
        }

        public void Reload()
        {
            ReloadTimer--;
            ReloadTimer = Math.Max(ReloadTimer, 0);
        }
        public int Fire()
        {
            if (ReloadTimer == 0)
            {
                ReloadTimer = Model.ReloadTimer;
                Capacity--;
                return Model.Damage;
            }
            return 0;
        }
    }
}
