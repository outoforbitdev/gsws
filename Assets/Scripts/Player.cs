////////////////////////////////////////////////////////////////////////////////
//                                                                            //
//                                  Player.cs                                 //
//                                 Player class                               //
//              Created by: Jarett (Jay) Mirecki, July 27, 2019               //
//              Modified by: Jarett (Jay) Mirecki, July 27, 2019              //
//                                                                            //
////////////////////////////////////////////////////////////////////////////////

using System;

public class Player {
    public Character Character { get; }

    public Player(string name) {
        this.Character = new Character(name);
    }
}