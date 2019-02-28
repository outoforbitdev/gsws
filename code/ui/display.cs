////////////////////////////////////////////////////////////////////////////////
//                                                                            //
//                                  display.cs                                //
//              Formats and displays text to the terminal/console             //
//             Created by: Jarett (Jay) Mirecki, February 20, 2019            //
//             Modified by: Jarett (Jay) Mirecki February 27, 2019            //
//                                                                            //
////////////////////////////////////////////////////////////////////////////////

using System;
using System.Text;

namespace JMSuite.UI {
    class ConsoleDisplay {
        public static string[] Title = {""};
        public static string Version = "";
        // maxLength
        // Finds the length of the longest string in an array of strings
        // Parameters: string array to find the longest string in
        // Returns: integer maximum length
        private static int maxLength(string[] output) {
            int max = 0;
            foreach (string o in output) {
                if (o.Length > max)
                    max = o.Length;
            }
            return max;
        }
        // maxLength
        // Finds the length of the longest string in a subarray of strings
        // Parameters: string array to find the longest string in
        //            integer start index of the subarray
        //            integer index after the last index of the subarray
        // Returns: integer maximum length
        private static int maxLength(string[] content, int start, int end) {
            int max = 0;
            for (int i = start; i < end; i++) {
                if (content[i].Length > max)
                    max = content[i].Length;
            }
            return max;
        }
        // Blank
        // Returns a string with the specified number of newlines
        // Parameters: integer number of blank lines
        // Returns: StringBuilder
        private static StringBuilder Blank(int lines) {
            StringBuilder output = new StringBuilder("");
            for (int i = 0; i < lines; i++)
                output = output.Append("\n");
            return output;
        }
        // Center
        // Creates a string the width of the window with the specified string 
        //     centered
        // Parameters: string to center
        // Returns: StringBuilder
        private static StringBuilder Center(string content) {
            int width = Console.WindowWidth;
            int length = content.Length;
            int padding = (width - length) / 2 + length;
            StringBuilder print = new StringBuilder(content.PadLeft(padding));
            return print;
        }
        // Center
        // Creates a string the width of the window  with the specified string 
        //     centered and selected
        // Parameters: string to center
        //             integer maximum length of other strings (for selector 
        //                 padding)
        // Returns: StringBuilder
        private static StringBuilder Center(string content, int maxLength) {
            StringBuilder output = Center(content);
            int width = Console.WindowWidth;
            int padding = (width - maxLength) / 2;

            output[padding - 2] = '>';
            output[padding - 3] = '-';
            output[padding - 4] = '-';
            return output;
            }
        // Right
        // Creates a string the width of the window with the specified string 
        //     right aligned
        // Parameters: string to right align
        // Returns: StringBuilder
        private static StringBuilder Right(string content) {
            int width = Console.WindowWidth;
            StringBuilder output = new StringBuilder(content.PadLeft(width));

            return output;
        }
        // AddSelection
        // Adds the selection marker to the desired string in an array
        // Parameters: string array
        //             integer index of the string to add the selection marker
        // Returns: StringBuilder
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
        // AddArrayCentered
        // Adds an array of strings to a StringBuilder, centered and separated 
        //     by newline characters
        // Parameters: StringBuilder
        //             string array to add to StrinBuilder
        // Returns: StringBuilder
        private static StringBuilder AddArrayCentered(StringBuilder output, string[] content) {
            foreach (string c in content)
                output = output.Append(Center(c)).Append("\n");
            return output;
        }
        // PrintMiddle
        // Print an array of strings into the middle of the terminal
        // Parameters: string array
        // Returns: void
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
        // PrintMiddle
        // Print an array of strings into the middle of the terminal and adds 
        //     the selection marker to the desired string
        // Parameters: string array
        //             integer index of the string to select
        // Returns: void
        public static void PrintMiddle(string [] content, int select) {
            
            PrintMiddle(AddSelection(content, select));
        }
        // AddTitle
        // Adds a title to the front of an array of strings
        // Parameters: string title
        //             string array to be added to
        // Returns: string array
        private static string[] AddTitle(string title, string [] content) {
            string[] newContent = new string[content.Length + 2];
            newContent[0] = title.ToUpper();
            newContent[1] = "";
            for (int i = 0; i < content.Length; i++)
                newContent[i + 2] = content[i];
            return newContent;
        }
        // AddTitleBox
        // Adds a title array to the front of an array of strings
        // Parameters: string array title array
        //             string array to be added to
        // Returns: string array
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
        // AddSubtitle
        // Adds a title and subtitle to the front of an array of strings
        // Parameters: string title
        //             string subtitle
        //             string array to be added to
        // Returns: string array
        private static string[] AddSubtitle(string title, string subtitle, string[] content) {
            string[] newContent = new string[content.Length + 3];
            newContent[0] = title.ToUpper();
            newContent[1] = subtitle;
            newContent[2] = "";
            for (int i = 0; i < content.Length; i++)
                newContent[i + 3] = content[i];
            return newContent;
        }
        // PrintMiddle
        // Prints two arrays to the middle of the terminal and selects the 
        //     desired string in the second array
        // Parameters: string array title array
        //             string array of content
        //             integer index to select
        // Returns: void
        public static void PrintMiddle(string[] titleBox, string[] content, int select) {
            PrintMiddle(AddTitleBox(titleBox, AddSelection(content, select)));
        }
        // PrintMiddle
        // Prints a title and an array to the middle of the terminal and 
        //     selects the desired string in the array
        // Parameters: string array title array
        //             string array of content
        //             integer index to select
        // Returns: void
        public static void PrintMiddle(string title, string [] content, int select) {
            PrintMiddle(AddTitle(title, content), select + 2);
        }
        // PrintMiddle
        // Prints a title, subtitle, and an array to the middle of the terminal 
        //     and selects the desired string in the array
        // Parameters: string title
        //             string subtitle
        //             string array of content
        //             integer index to select
        // Returns: void
        public static void PrintMiddle(string title, string subtitle, string [] content, int select) {
            PrintMiddle(AddSubtitle(title, subtitle, content), select + 3);
        }
        // PrintMiddle
        // Prints a title, subtitle, and an array to the middle of the terminal
        // Parameters: string title
        //             string subtitle
        //             string array of content
        // Returns: void
        public static void PrintMiddle(string title, string subtitle, string [] content) {
            PrintMiddle(AddSubtitle(title, subtitle, content));
        }
        // PrintMiddle
        // Prints two arrays to the middle of the terminal
        // Parameters: string array title array
        //             string array of content
        // Returns: void
        public static void PrintMiddle(string[] title, string [] content) {
            PrintMiddle(AddTitleBox(title, content));
        }
    }
}