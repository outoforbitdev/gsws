////////////////////////////////////////////////////////////////////////////////
//                                                                            //
//                                   game.cs                                  //
//          Implementation of the details specific to a game session          //
//             Created by: Jarett (Jay) Mirecki, February 21, 2019            //
//              Modified by: Jarett (Jay) Mirecki, March 02, 2019             //
//                                                                            //
// The Game class holds the state of game session. These details include the  //
// Player, Faction, FactionInfo, Date, and some functions to make sure the UI //
// reflects the current state of the game.                                    //
//                                                                            //
////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.IO;

namespace GSWS {
    class Game {
        public static Player Player { get; set; }
        public static Faction Faction { get; set; }
        public static FactionInfo FactionInfo;
        public static int Date;
        public enum DateSystem { ABY };
        public static string Error;

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
            Error = "";
            JMSuite.Collections.Graph<string, Planet> example = new JMSuite.Collections.Graph<string, Planet>();
            
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
        public static void Save() {
            Parse.Save();
        }
        public static void Load(string saveName) {
            Parse.Load(saveName);
        }
        public static string Encode() {
            string output = "{\"faction\": "
                          + "\"" + (int)Faction + "\""
                          + ", \"player\": " 
                          + Player.Encode()
                          + ", \"factioninfo\": "
                          + "" + FactionInfo.Encode()
                          + ", \"date\": "
                          + "\"" + Date.ToString() + "\""
                          + "}";
            return output;
        }
        public static bool Decode(string encodedFaction) {
            string label, encodedPlayer, encodedDate, faction, player, factionInfo, date;
            if (!Parse.FirstPair(encodedFaction, "faction", out faction, out encodedPlayer)) return false;
            Faction = (Faction)Int32.Parse(faction);

            if (!Parse.FirstPair(encodedPlayer, "player", out player, out encodedFaction)) return false;
            Player = new Player(player);

            if (!Parse.FirstPair(encodedFaction, "factioninfo", out factionInfo, out encodedDate)) return false;
            FactionInfo = new FactionInfo(factionInfo);

            if (!Parse.FirstPair(encodedDate, "date", out date, out label)) return false;
            Date = ConvertYear(Int32.Parse(date), DateSystem.ABY);

            return true;
        }
        public static void GiveError(string message) {
            Error = message;
            GSWS.MainPool.Open("error");
        }
    }
}