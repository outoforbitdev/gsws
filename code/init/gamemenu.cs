////////////////////////////////////////////////////////////////////////////////
//                                                                            //
//                                 gamemenu.cs                                //
//              Initialize menus and create the session game menu             //
//             Created by: Jarett (Jay) Mirecki, February 21, 2019            //
//            Modified by: Jarett (Jay) Mirecki, February 27, 2019            //
//                                                                            //
////////////////////////////////////////////////////////////////////////////////

using System;

namespace GSWS.Initialize {
    partial class Menus {
        // Init()
        // Creates instances of all required menus
        // Parameters: None
        // Returns: void
        public static void Init() {
            MainMenu();
            NewGame();
            GameMenu();
            GovMenu();
            NotImplemented();
        }
        // GameMenu()
        // Creates the session game menu and adds it to the MainPool
        // Parameters: None
        // Returns: void
        private static void GameMenu() {
            UI.Menu gamemenu = new UI.Menu("GSWS", "Please choose an option");
            gamemenu.Add("Administration");
            gamemenu.Add("War Room");
            gamemenu.Add("Holonet News Network");
            gamemenu.Add("Save");
            gamemenu.Add("Save & Exit");
            gamemenu.Add("Exit Session");
            gamemenu.onSelect =
                delegate(int i) {
                    switch(i) {
                        case 0:
                            GSWS.MainPool.Open("govmenu");
                            break;
                        case 1:
                            GSWS.MainPool.Open("notimplemented");
                            break;
                        case 2:
                            GSWS.MainPool.Open("notimplemented");
                            break;
                        case 3:
                            GSWS.MainPool.Open("notimplemented");
                            break;
                        case 4:
                            GSWS.MainPool.Open("notimplemented");
                            break;
                        case 5:
                             JMSuite.UI.ConsoleDisplay.Title = new string[] {"GSWS"};
                            gamemenu.Quit();
                            break;
                        default:
                            break;
                    }
                };
            GSWS.MainPool.Add("gamemenu", gamemenu);
        }
    }
}