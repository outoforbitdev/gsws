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

namespace GSWS
{
    class EmplacementWeapon : Weapon
    {
        public bool Independent { get; set; }

        private new void InitInstance()
        {
            Independent = false;
            base.InitInstance();
        }
    }
}
