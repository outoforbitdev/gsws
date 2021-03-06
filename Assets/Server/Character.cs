////////////////////////////////////////////////////////////////////////////////
//                                                                            //
//                                Character.cs                                //
//                               Character class                              //
//              Created by: Jarett (Jay) Mirecki, July 27, 2019               //
//            Modified by: Jarett (Jay) Mirecki, February 06, 2020            //
//                                                                            //
////////////////////////////////////////////////////////////////////////////////

using System;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace GSWS.Assets.Server
{

[Serializable] public class Character {
    [XmlAttribute] public string ID;
    public string Name, Species, Homeworld;
    public List<string> Governments, Factions, Militaries, Units;
    public bool IsPlayer;

    private void InitInstance() {
        ID = Name = Species = Homeworld = "";
        IsPlayer = false;
        Governments = new List<string>();
        Factions = new List<string>();
        Militaries = new List<string>();
        Units = new List<string>();
    }
    public Character() {
        InitInstance();
    }
    public Character(string name) {
        InitInstance();
        this.Name = name;
    }
    public string DatapadDescription() {
        string description = 
            Name + "\n" + Species + " from " + Homeworld;
        return description;
    }
}
}