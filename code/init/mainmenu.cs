////////////////////////////////////////////////////////////////////////////////
//                                                                            //
//                                 mainmenu.cs                                //
//                         Create the opening main menu                       //
//             Created by: Jarett (Jay) Mirecki, February 20, 2019            //
//              Modified by: Jarett (Jay) Mirecki, March 03, 2019             //
//                                                                            //
////////////////////////////////////////////////////////////////////////////////

using System;

namespace GSWS.Initialize {
    partial class Menus {
        // MainMenu()
        // Creates the opening main menu and adds it to the MainPool
        // Parameters: None
        // Returns: void
        private static void MainMenu() {
            UI.Menu mainmenu = new UI.Menu("GSWS", "Please choose an option to begin:");
            mainmenu.Add("New Game");
            mainmenu.Add("Load Game");
            mainmenu.Add("Delete Game");
            mainmenu.Add("Quit Game");

            mainmenu.onSelect = 
                delegate(int i) {
                    switch(i) {
                        case 0:
                            GSWS.MainPool.Open("newgame");
                            mainmenu.ResetSelect();
                            break;
                        case 1:
                            Game.Load("test");
                            // Game.Init();
                            // Game.Player.Name = "Avan Ardele";
                            // Game.Faction = Game.Player.Faction = Faction.Extra1;
                            // Game.FactionInfo.SetName(Game.Faction, "IMF");
                            // Game.Date = 41 * 365;
                            // Game.FactionInfo.SetFunds(Game.Faction, 1191876720);
                            // Gov newGov = new Gov("IMF", 0, 0);
                            // newGov.Population = 327167434;
                            // newGov.Wealth = 30000;
                            // newGov.Industry = 162637000;
                            // newGov.Productivity = 126050;
                            // newGov.Capacity = 400000000;
                            // newGov.TaxResidential = 0.09;
                            // newGov.TaxCommercial = 0.2;
                            // Game.FactionInfo.SetGovernment(Game.Faction, newGov);
                            Game.UpdateMenus();
                            GSWS.MainPool.Open("gamemenu");
                            mainmenu.ResetSelect();
                            break;
                        case 2:
                            GSWS.MainPool.Open("notimplemented");
                            break;
                        case 3:
                            mainmenu.Quit();
                            break;
                        default:
                            break;
                    }
                };

            GSWS.MainPool.Add("mainmenu", mainmenu);
        }
        // NotImplemented()
        // Creates the "not implemented" screen and adds it to the MainPool
        // Parameters: None
        // Returns: void
        private static void NotImplemented() {
            UI.Menu menu = new UI.Menu("This feature is not implemented yet", "Hopefully it will be added soon");
            menu.Add("OK");
            menu.onSelect =
                delegate(int i) {
                    menu.Quit();
                };
            GSWS.MainPool.Add("notimplemented", menu);
        }
        private static void Error() {
            UI.Menu menu = new UI.Menu("Error");
            menu.Add("OK");
            menu.onSelect =
                delegate(int i) {
                    menu.Quit();
                };
            menu.onLoad =
                delegate() {
                    menu.UpdateToolTip(new string[] { Game.Error });
                };
            GSWS.MainPool.Add("error", menu);
        }
        private static void TestGraph() {
            JMSuite.Collections.Graph<int, int> graph 
                                    = new JMSuite.Collections.Graph<int, int>();
            graph.Add(1, 1, new int[] { 2, 3 });
            graph.Add(2, 2, new int[] { 1, 4 });
            graph.Add(3, 3, new int[] { 1, 4 });
            graph.Add(4, 4, new int[] { 2, 3 });
            Game.GiveError("Distance from 1 to 4 = " + graph.DistanceTo(1, 4));
            
            JMSuite.Collections.Graph<string, string> graph2
                                    = new JMSuite.Collections.Graph<string, string>();
            graph2.Add("Coruscant", "Coruscant", 
                       new string[] { "Corellia", "Brentaal", "Ord Mantel"});
            graph2.Add("Corellia", "Corellia", 
                       new string[] { "Coruscant"});
            graph2.Add("Brentaal", "Brentaal", 
                       new string[] { "Coruscant", "Bandomeer", "Taanab"});
            graph2.Add("Ord Mantel", "Ord Mantel", 
                       new string[] { "Coruscant", "Bastion"});
            graph2.Add("Bandomeer", "Bandomeer", 
                       new string[] { "Brentaal", "Mandalore"});
            graph2.Add("Taanab", "Taanab", 
                       new string[] { "Hapes", "Brentaal"});
            graph2.Add("Bastion", "Bastion", 
                       new string[] { "Ord Mantel"});
            graph2.Add("Mandalore", "Mandalore", 
                       new string[] { "Bandomeer"});
            graph2.Add("Hapes", "Hapes", 
                       new string[] { "Taanab"});
            graph2.Add("Hapes", "Hapes", 
                       new string[] { "Taanab"});
            Game.GiveError("Distance from Coruscant to Corellia = " + graph2.DistanceTo("Coruscant", "Corellia"));
            Game.GiveError("Distance from Coruscant to Hapes = " + graph2.DistanceTo("Coruscant", "Hapes"));
            
        }
    }
}