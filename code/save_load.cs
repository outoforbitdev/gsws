////////////////////////////////////////////////////////////////////////////////
//                                                                            //
//                                save_load.cs                                //
//                         File Interaction Functions                         //
//             Created by: Jarett (Jay) Mirecki, February 28, 2019            //
//              Modified by: Jarett (Jay) Mirecki, March 1, 2019              //
//                                                                            //
////////////////////////////////////////////////////////////////////////////////

using System;
using System.IO;
using System.Text;

namespace GSWS {
    static class Parse {
        public static void Save() {
            string output = "{\"game\": " + Game.Encode() + "}";
            File.WriteAllText("test.gsws", output);
        }
        public static bool Load(string saveName) {
            string filename = saveName + ".gsws";
            string info = File.ReadAllText(filename);
            string key, value, remainder;
            bool keySuccess = FirstKey(info, out key);
            bool valueSuccess = FirstValue(info, out value);
            bool remainderSuccess = RemoveFirstPair(info, out remainder);
            if (keySuccess && valueSuccess && remainderSuccess)
                return Game.Decode(value);
            Game.GiveError("Corrupt Save. Failed on Game. Key: " 
                           + keySuccess.ToString() + "; Value: " 
                           + valueSuccess.ToString() + "; Remainder: "
                           + remainderSuccess.ToString());
            return false;
        }
        public static bool FirstKey(string input, out string output) {
            StringBuilder parsed = new StringBuilder(input);
            if (parsed[0] != '{') {
                Game.GiveError("Corrupt Save. Expected '{' but found " + parsed[0]);
                output = default(string);
                return false;
            }
            parsed.Remove(0, 1);
            if (parsed[0] != '\"') {
                Game.GiveError("Corrupt Save. Expected '\"' but found " + parsed[0]);
                output = default(string);
                return false;
            }
            parsed.Remove(0, 1);
            output = parsed.ToString().Split(new char[] { '\"' }, 2)[0];
            return true;
        }
        public static bool FirstValue(string input, out string output) {
            StringBuilder parsed = new StringBuilder(input.Split(" ".ToCharArray(), 2)[1]);
            int length = parsed.Length;
            if (parsed[0] == '{') {
                int braceCounter = 1;
                for (int i = 1; i < length; i++) {
                    if (parsed[i] == '{')
                        braceCounter++;
                    else if (parsed[i] == '}')
                        braceCounter--;
                    if (braceCounter == 0) {
                        output = input[0] + parsed.Remove(i + 1, length - i - 1).Remove(0, 1).ToString();
                        return true;
                    }
                }
            } else if (parsed[0] == '[') {
                int bracketCounter = 1;
                for (int i = 1; i < length; i++) {
                    if (parsed[i] == '[')
                        bracketCounter++;
                    else if (parsed[i] == ']')
                        bracketCounter--;
                    if (bracketCounter == 0) {
                        output = parsed.Remove(i + 1, length - i - 1).ToString();
                        return true;
                    }
                }
            } else if (parsed[0] == '\"') {
                for (int i = 1; i < length; i++) {
                    if (parsed[i] == '\"') {
                        output = parsed.Remove(i, length - i).Remove(0, 1).ToString();
                        return true;
                    }
                }
            }
            output = parsed[0].ToString();
            return false;
        }
        public static string[] ArrayValue(string input) {
            StringBuilder parsed = new StringBuilder(input);
            parsed.Remove(0, 1).Remove(parsed.Length - 1, 1);
            string[] delim = new string[1];
            if (parsed[0] == '{') delim[0] = "},";
            else if (parsed[0] == '[') delim[0] = "],";
            else delim[0] = ",";
            string[] output = parsed.ToString().Split(delim, 
                                                      StringSplitOptions.None);
            for (int i = 0; i < output.Length; i++) {
                if (output[i][0] == ' ')
                    output[i] = (new StringBuilder(output[i])).Remove(0, 1).ToString();
                if (delim[0] == "},") output[i] += "}";
                else if (delim[0] == "],") output[i] += "]";
            }
            return output;
        }
        public static string[] ArrayValue(string input, string type) {
            string[] output = ArrayValue(input);
            string[] strOutput = new string[output.Length];
            for (int i = 0; i < output.Length; i++) {
                strOutput[i] = (new StringBuilder(output[i])).Remove(output[i].Length - 1, 1).Remove(0, 1).ToString();
            }
            return strOutput;
        }
        public static int[] ArrayValue(string input, int type) {
            string[] output = ArrayValue(input, "hey");
            int[] intOutput = new int[output.Length];
            for (int i = 0; i < output.Length; i++)
                Int32.TryParse(output[i], out intOutput[i]);
            return intOutput;
        }
        public static bool RemoveFirstPair(string input, out string output) {
            StringBuilder parsed = new StringBuilder(input.Split(" ".ToCharArray(), 2)[1]);
            if (parsed[0] == '{') {
                int braceCounter = 1;
                for (int i = 1; i < parsed.Length; i++) {
                    if (parsed[i] == '{')
                        braceCounter++;
                    else if (parsed[i] == '}')
                        braceCounter--;
                    if (braceCounter == 0) {
                        int index;
                        if (parsed[i + 1] == ',') index = i + 3; else index = i+1;
                        output = input[0] + parsed.Remove(0, index).ToString();
                        return true;
                    }
                }
            } else if (parsed[0] == '[') {
                int bracketCounter = 1;
                for (int i = 1; i < parsed.Length; i++) {
                    if (parsed[i] == '[')
                        bracketCounter++;
                    else if (parsed[i] == ']')
                        bracketCounter--;
                    if (bracketCounter == 0) {
                        int index;
                        if (parsed[i + 1] == ',') index = i + 3; else index = i+1;
                        output = input[0] + parsed.Remove(0, index).ToString();
                        return true;
                    }
                }
            } else if (parsed[0] == '\"') {
                for (int i = 1; i < parsed.Length; i++) {
                    if (parsed[i] == '\"') {
                        int index;
                        if (parsed[i + 1] == ',') index = i + 3; else index = i+1;
                        output = input[0] + parsed.Remove(0, index).ToString();
                        return true;
                    }
                }
            }
            output = parsed[0].ToString();
            return false;

        }
        public static bool FirstPair(string input, string expectedKey, out string value, out string remainder) {
            string key = value = remainder = default(string);
            if (!FirstKey(input, out key)) return false;
            if (key != expectedKey) {
                Game.GiveError("Corrupt Save. Expected " + expectedKey 
                               + " but found " + key);
                return false;
            }
            if (!FirstValue(input, out value)) return false;
            if (!RemoveFirstPair(input, out remainder)) return false;
            return true;
        }
    }
}