////////////////////////////////////////////////////////////////////////////////
//                                                                            //
//                            EmplacementWeapon.cs                            //
//                          EmplacementWeapon class                           //
//            Created by: Jarett (Jay) Mirecki, October 07, 2020              //
//            Modified by: Jarett (Jay) Mirecki, October 07, 2020             //
//                                                                            //
////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GSWS.Assets.Server
{
    class EmplacementWeaponModel : WeaponModel
    {
        public bool Independent { get; set; }

        public EmplacementWeaponModel() : this("", "", 0, 0, 0, false) { }
        public EmplacementWeaponModel(string id, string name, float damage, float accuracy, int capacity, bool independent): base(id, name, damage, accuracy, capacity)
        {
            Independent = independent;
        }
    }
}
