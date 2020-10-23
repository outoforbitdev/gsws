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
    abstract class Weapon
    {
        [XmlIgnore]
        public WeaponModel Model { get; set; }
        public string kModel { get; set; }
    }
}
