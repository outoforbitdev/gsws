////////////////////////////////////////////////////////////////////////////////
//                                                                            //
//                                   gsws.cs                                  //
//                  Implements main and launches the program                  //
//             Created by: Jarett (Jay) Mirecki, February 20, 2019            //
//             Modified by: Jarett (Jay) Mirecki Febrary 28, 2019             //
//                                                                            //
////////////////////////////////////////////////////////////////////////////////

using System;

namespace GSWS {
    public partial class GSWS {
        // Versioning constants
        public const int major = 0;
        public const int minor = 1;
        public const int patch = 1;
        public const string prerelease = "-alpha.";
        public const int prereleaseversion = 3;
        // The menu pool to store and open all 
        // menus used by the core game files
        public static UI.MenuPool MainPool = new UI.MenuPool();

        static public void Main() {
            GSWS main = new GSWS();
            main.Run();
        }
        public GSWS() {
            // Intialize everything
            Init();
            // Set the version number for the display
            JMSuite.UI.ConsoleDisplay.Version = "v" + major.ToString() + "." 
                                                + minor.ToString() + "." 
                                                + patch.ToString() 
                                                + prerelease 
                                                + prereleaseversion.ToString();
            JMSuite.UI.ConsoleDisplay.Title[0] = "GSWS";
        }
        public void Run() {
            // Open the main menu
            MainPool.Open("mainmenu");
            // Print a closing message to console
            string[] closing = {"GSWS", "", "Thank you for playing GSWS!"};
            JMSuite.UI.ConsoleDisplay.PrintMiddle(closing);
        }
    }
}