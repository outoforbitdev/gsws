using System;

namespace GSWS {
    public partial class GSWS {
        public const int version = 0;
        public const int subversion = 1;
        public const int patch = 1;
        public const string prerelease = "-alpha.1";
        public static UI.MenuPool MainPool = new UI.MenuPool();

        static public void Main() {
            GSWS main = new GSWS();
            main.Run();
        }
        public GSWS() {
            Init();
            JMSuite.UI.ConsoleDisplay.Version = "v" + version.ToString() + "." + subversion.ToString() + "." + patch.ToString() + prerelease;
            JMSuite.UI.ConsoleDisplay.Title[0] = "GSWS";
        }
        public void Run() {
            MainPool.Open("mainmenu");
            string[] closing = {"GSWS", "", "Thank you for playing GSWS!"};
            JMSuite.UI.ConsoleDisplay.PrintMiddle(closing);
        }
    }
}