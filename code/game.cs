////////////////////////////////////////////////////////////////////////////////
//                                                                            //
//                                   game.cs                                  //
//          Implementation of the details specific to a game session          //
//             Created by: Jarett (Jay) Mirecki, February 21, 2019            //
//            Modified by: Jarett (Jay) Mirecki, February 27, 2019            //
//                                                                            //
// The Game class holds the state of game session. These details include the  //
// Player, Faction, FactionInfo, Date, and some functions to make sure the UI //
// reflects the current state of the game.                                    //
//                                                                            //
////////////////////////////////////////////////////////////////////////////////

using System;

namespace GSWS {
    static class Game {
        public static Player Player { get; set; }
        public static Faction Faction { get; set; }
        public static FactionInfo FactionInfo;
        public static int Date;
        public enum DateSystem { ABY };

        // Init
        // Essentially functions as a constructor, but for the elements in the 
        //     static class
        // Parameters: None
        // Returns: void
        public static void Init() {
            Faction = Faction.GA;
            Player = new Player("", Faction);
            Date = 0;
            FactionInfo = new FactionInfo();
        }
        // UpdateMenus
        // Updates the display header with the current state of the game
        // Parameters: None
        // Returns: void
        public static void UpdateMenus() {
            JMSuite.UI.ConsoleDisplay.Title = new string[] { "GSWS", "Player: " + Player.Name, "Faction: " + FactionInfo.GetName(Faction), "Date: " 
                                                            + ConvertYear(Date, DateSystem.ABY), "Funds: ₹" + String.Format("{0:n0}", FactionInfo.GetFunds(Faction)) };
        }
        // ConvertYear
        // Converts from the integer date to the current year
        // Parameters: integer date
        //             DateSystem system being used
        // Returns: integer year
        public static int ConvertYear(int date, DateSystem system) {
            if (system == DateSystem.ABY) {
                if (date > 0)
                    return date / 365;
            }
            return 0;
        }
    }
}