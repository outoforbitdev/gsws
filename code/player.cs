////////////////////////////////////////////////////////////////////////////////
//                                                                            //
//                                  player.cs                                 //
//                                 Player class                               //
//             Created by: Jarett (Jay) Mirecki, February 21, 2019            //
//            Modified by: Jarett (Jay) Mirecki, February 27, 2019            //
//                                                                            //
////////////////////////////////////////////////////////////////////////////////

using System;

namespace GSWS {
    class Player {
        public string Name;
        public Faction Faction;

        public Player(string name, Faction faction) {
            this.Name = name;
            this.Faction = faction;
        }
    }
}