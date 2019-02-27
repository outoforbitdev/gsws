using System;
using System.Text;

namespace JMSuite.UI {
    class ConsoleDisplay {
        public static string[] Title = {""};
        public static string Version = "";
        private static int maxLength(string[] output) {
            int max = 0;
            foreach (string o in output) {
                if (o.Length > max)
                    max = o.Length;
            }
            return max;
        }
        private static int maxLength(string[] content, int start, int end) {
            int max = 0;
            for (int i = start; i < end; i++) {
                if (content[i].Length > max)
                    max = content[i].Length;
            }
            return max;
        }
        private static StringBuilder Blank(int lines) {
            StringBuilder output = new StringBuilder("");
            for (int i = 0; i < lines; i++)
                output = output.Append("\n");
            return output;
        }
        private static StringBuilder Center(string content) {
            int width = Console.WindowWidth;
            int length = content.Length;
            int padding = (width - length) / 2 + length;
            StringBuilder print = new StringBuilder(content.PadLeft(padding));
            return print;
        }
        private static StringBuilder Center(string content, int maxLength) {
            StringBuilder output = Center(content);
            int width = Console.WindowWidth;
            int padding = (width - maxLength) / 2;

            output[padding - 2] = '>';
            output[padding - 3] = '-';
            output[padding - 4] = '-';
            return output;
            }
        private static StringBuilder Right(string content) {
            int width = Console.WindowWidth;
            StringBuilder output = new StringBuilder(content.PadLeft(width));

            return output;
        }
        private static string[] AddSelection(string[] content, int select) {
            string arrowAndPadding = "--> ";                                        // ASCII for the current selection
            string optionAndPadding = content[select];
            int padding = (maxLength(content, 0, content.Length) - content[select].Length) / 2;

            for (int i = 0; i < padding; i++) {                                     // Add padding so the selected option is still centered
                arrowAndPadding = arrowAndPadding + " ";
                optionAndPadding = optionAndPadding + " ";
            }
            content[select] = arrowAndPadding + optionAndPadding + "    ";
            return content;
        }
        private static StringBuilder AddArrayCentered(StringBuilder output, string[] content) {
            foreach (string c in content)
                output = output.Append(Center(c)).Append("\n");
            return output;
        }
        public static void PrintMiddle(string [] output) {
            int totalPadding = Console.WindowHeight - (output.Length + Title.Length + 2);
            int upperPadding = totalPadding / 2;
            int lowerPadding = upperPadding + totalPadding % 2;
            
            StringBuilder final = new StringBuilder("\n");
            final = AddArrayCentered(final, Title);            // Title
            final = final.Append(Blank(upperPadding));         // Space before menu
            final = AddArrayCentered(final, output);           // Add menu content
            final = final.Append(Blank(lowerPadding));         // Space after menu
            final = final.Append(Right(Version)).Append("\n"); // Version in bottom right
            Console.Write(final.ToString());
        }
        public static void PrintMiddle(string [] content, int select) {
            
            PrintMiddle(AddSelection(content, select));
        }
        private static string[] AddTitle(string title, string [] content) {
            string[] newContent = new string[content.Length + 2];
            newContent[0] = title.ToUpper();
            newContent[1] = "";
            for (int i = 0; i < content.Length; i++)
                newContent[i + 2] = content[i];
            return newContent;
        }
        private static string[] AddTitleBox(string[] titleBox, string[] content) {
            int newLength = titleBox.Length + content.Length + 1;
            string[] newContent = new string[titleBox.Length + content.Length+ 1];
            for (int i = 0; i < titleBox.Length; i++)
                newContent[i] = titleBox[i];
            newContent[titleBox.Length] = "";
            for (int i = 0; i < content.Length; i++)
                newContent[titleBox.Length + 1 + i] = content[i];
            
            return newContent;

        }
        private static string[] AddSubtitle(string title, string subtitle, string[] content) {
            string[] newContent = new string[content.Length + 3];
            newContent[0] = title.ToUpper();
            newContent[1] = subtitle;
            newContent[2] = "";
            for (int i = 0; i < content.Length; i++)
                newContent[i + 3] = content[i];
            return newContent;
        }
        public static void PrintMiddle(string[] titleBox, string[] content, int select) {
            PrintMiddle(AddTitleBox(titleBox, AddSelection(content, select)));
        }
        public static void PrintMiddle(string title, string [] content, int select) {
            PrintMiddle(AddTitle(title, content), select + 2);
        }
        public static void PrintMiddle(string title, string subtitle, string [] content, int select) {
            PrintMiddle(AddSubtitle(title, subtitle, content), select + 3);
        }
        public static void PrintMiddle(string title, string subtitle, string [] content) {
            PrintMiddle(AddSubtitle(title, subtitle, content));
        }
        public static void PrintMiddle(string[] title, string [] content) {
            PrintMiddle(AddTitleBox(title, content));
        }
    }
}