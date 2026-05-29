
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace WinApp.Common
{
    
    /// <summary>
    /// Provides extended string manipulation functionalities.
    /// </summary>
    /// <developer>HaiTN</developer>
    /// <version>1.0.0</version>
    /// <creationDate>20/09/2025</creationDate>
    public class ExtString : IDisposable
    {
        public const string CRLF = "\r\n";
        private readonly Encoding _shiftJis = Encoding.GetEncoding("Shift_JIS");

        static ExtString()
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
        }

        public ExtString()
        {
            _shiftJis = Encoding.GetEncoding("Shift_JIS");
        }

        /// <summary>
        /// Calculates the length of a string in bytes using Shift_JIS encoding.
        /// </summary>
        /// <param name="s">The string to measure.</param>
        /// <returns>The length of the string in bytes.</returns>
        public int Klen(string s)
        {
            if (string.IsNullOrEmpty(s)) return 0;
            return _shiftJis.GetByteCount(s);
        }

        /// <summary>
        /// Determines if a character is a multi-byte character (e.g., Japanese character) based on Shift_JIS encoding.
        /// </summary>
        /// <param name="c">The character to check.</param>
        /// <returns>True if the character is multi-byte, false otherwise.</returns>
        public bool Ktype(char c)
        {
            byte[] bytes = _shiftJis.GetBytes(new[] { c });
            return bytes.Length > 1;
        }

        /// <summary>
        /// Gets the byte count of a single character using Shift_JIS encoding.
        /// </summary>
        /// <param name="c">The character to measure.</param>
        /// <returns>The byte count of the character.</returns>
        public int Kbyte(char c)
        {
            return _shiftJis.GetByteCount(new[] { c });
        }

        /// <summary>
        /// Extracts a double-precision floating-point number from a string starting at a specified index.
        /// </summary>
        /// <param name="s">The input string.</param>
        /// <param name="iSt">A 1-based index indicating where to start parsing. Updated to the position after the parsed number.</param>
        /// <returns>The parsed double value, or 0 if no valid number is found.</returns>
        public double StrnDbl(string ss, ref int iSt)
        {
            int iEr, iEp, iLn, iMx;
            double result = 0;

            iMx = ss.Length;
            iLn = iMx + 1;
            iEr = iLn;

            do
            {
                if (iEr == 1 || iLn == iEr - 1)
                {
                    iSt += iEr;
                    if (iSt > iMx)
                    {
                        iSt = 0;
                        return 0;
                    }
                    iLn = iMx;
                }
                else
                {
                    iLn = iEr - 1;
                    iEp = iSt + iLn - 1;
                    if (iEp >= 1 && iEp <= iMx && ss[iEp - 1] == '.')
                        iLn--;
                }

                string sub = ss.Substring(iSt - 1, Math.Min(iLn, ss.Length - (iSt - 1)));
                bool success = double.TryParse(sub, out result);
                iEr = success ? 0 : sub.Length;
            }
            while (iEr != 0);

            iSt += iLn;
            if (iSt > iMx)
                iSt = 0;

            return result;
        }

        /// <summary>
        /// Converts a string representation of a number to a double-precision floating-point number.
        /// Handles removal of thousand separators.
        /// </summary>
        /// <param name="s">The string to convert.</param>
        /// <returns>The parsed double value, or 0 if conversion fails.</returns>
        public double StrDbl(string s)
        {
            if (string.IsNullOrWhiteSpace(s)) return 0;
            s = Regex.Replace(s, @",(\d{{3}})", "$1"); // Remove thousand separators
            int startIndex = 1;
            return StrnDbl(s, ref startIndex);
        }

        /// <summary>
        /// Extracts an integer from a string starting at a specified index.
        /// </summary>
        /// <param name="s">The input string.</param>
        /// <param name="startIndex">A 1-based index indicating where to start parsing. Updated to the position after the parsed integer.</param>
        /// <returns>The parsed integer value, or 0 if no valid integer is found.</returns>
        public int StrnInt(string s, ref int startIndex)
        {
            return (int)Math.Truncate(StrnDbl(s, ref startIndex));
        }

        /// <summary>
        /// Converts a string representation of a number to an integer.
        /// </summary>
        /// <param name="s">The string to convert.</param>
        /// <returns>The parsed integer value, or 0 if conversion fails.</returns>
        public int StrInt(string s)
        {
            int startIndex = 1;
            return StrnInt(s, ref startIndex);
        }

        /// <summary>
        /// Extracts a hexadecimal integer from a string starting at a specified index.
        /// Expects a '$' prefix for the hexadecimal number.
        /// </summary>
        /// <param name="s">The input string.</param>
        /// <param name="startIndex">A 1-based index indicating where to start parsing. Updated to the position after the parsed hexadecimal number.</param>
        /// <returns>The parsed hexadecimal integer value, or 0 if no valid hexadecimal number is found.</returns>
        public int StrnHex(string s, ref int startIndex)
        {
            if (string.IsNullOrWhiteSpace(s)) return 0;

            int currentPos = startIndex - 1;
            int hexStart = -1;
            int hexLen = 0;

            // Find '$' prefix
            while (currentPos < s.Length)
            {
                if (s[currentPos] == '$')
                {
                    hexStart = currentPos + 1;
                    break;
                }
                currentPos++;
            }

            if (hexStart == -1) return 0;

            currentPos = hexStart;
            while (currentPos < s.Length && Uri.IsHexDigit(s[currentPos]))
            {
                currentPos++;
                hexLen++;
            }

            if (hexLen == 0) return 0;

            string hexStr = s.Substring(hexStart, hexLen);
            startIndex = currentPos + 1;

            int result;
            int.TryParse(hexStr, NumberStyles.HexNumber, CultureInfo.InvariantCulture, out result);
            return result;
        }

        /// <summary>
        /// Converts a string representation of a hexadecimal number to an integer.
        /// </summary>
        /// <param name="s">The string to convert.</param>
        /// <returns>The parsed hexadecimal integer value, or 0 if conversion fails.</returns>
        public int StrHex(string s)
        {
            int startIndex = 1;
            return StrnHex(s, ref startIndex);
        }

        /// <summary>
        /// Converts a 5-character string encoded in a custom 128-base format to an integer.
        /// </summary>
        /// <param name="s128">The 5-character string to convert.</param>
        /// <returns>The decoded integer value.</returns>
        public int From128(string s128)
        {
            int result = 0;
            for (int i = 0; i < 5 && i < s128.Length; i++)
            {
                result = (result << 7) + (s128[i] & 0x7F);
            }
            return result;
        }

        /// <summary>
        /// Converts a 10-character string encoded in a custom 128-base format to a double-precision floating-point number.
        /// This method assumes a specific byte order and double representation, translating from a Delphi-like pointer manipulation.
        /// </summary>
        /// <param name="s128">The 10-character string to convert.</param>
        /// <returns>The decoded double value.</returns>
        public double From128D(string s128)
        {
            if (s128.Length < 10) return 0;

            int part1 = From128(s128.Substring(0, 5));
            int part2 = From128(s128.Substring(5, 5));

            byte[] bytes = new byte[8];
            Array.Copy(BitConverter.GetBytes(part1), 0, bytes, 0, 4);
            Array.Copy(BitConverter.GetBytes(part2), 0, bytes, 4, 4);

            return BitConverter.ToDouble(bytes, 0);
        }

        /// <summary>
        /// Converts an integer to a 5-character string encoded in a custom 128-base format.
        /// </summary>
        /// <param name="i10">The integer to convert.</param>
        /// <returns>The 5-character string representation.</returns>
        public string To128(int i10)
        {
            char[] result = new char[5];
            for (int i = 4; i >= 0; i--)
            {
                result[i] = (char)((i10 & 0x7F) | 0x80);
                i10 >>= 7;
            }
            return new string(result);
        }

        /// <summary>
        /// Converts a double-precision floating-point number to a 10-character string encoded in a custom 128-base format.
        /// </summary>
        /// <param name="d10">The double to convert.</param>
        /// <returns>The 10-character string representation.</returns>
        public string To128D(double d10)
        {
            byte[] bytes = BitConverter.GetBytes(d10);
            int part1 = BitConverter.ToInt32(bytes, 0);
            int part2 = BitConverter.ToInt32(bytes, 4);

            return To128(part1) + To128(part2);
        }

        /// <summary>
        /// Formats an integer with leading zeros to a specified number of digits.
        /// </summary>
        /// <param name="iNum">The integer to format.</param>
        /// <param name="iDig">The desired number of digits.</param>
        /// <returns>The formatted string with leading zeros.</returns>
        public string IntTo00n(int iNum, int iDig)
        {
            return Right(Strings(iDig - 1, "0") + iNum.ToString(), iDig);
        }

        /// <summary>
        /// Removes trailing carriage returns, line feeds, and spaces from a string.
        /// </summary>
        /// <param name="sStr">The string to trim.</param>
        public void CRCut(ref string sStr)
        {
            sStr = sStr.TrimEnd('\r', '\n', ' ');
        }

        /// <summary>
        /// Removes all comma characters from a string.
        /// </summary>
        /// <param name="sData">The input string.</param>
        /// <returns>The string with commas removed.</returns>
        public string RemoveCamma(string sData)
        {
            return sData.Replace(",", "");
        }

        /// <summary>
        /// Escapes the ampersand character ('&') in a string by replacing it with '&&'.
        /// This is a simplified version of Delphi's AnsiQuotedStr for the ampersand character.
        /// </summary>
        /// <param name="sStr">The input string.</param>
        /// <returns>The string with ampersands escaped.</returns>
        public string AndAnd(string sStr)
        {
            // AnsiQuotedStr in Delphi adds quotes and escapes existing ones.
            // This is a simplified version for '&' character.
            return sStr.Replace("&", "&&");
        }

        /// <summary>
        /// Repeats a given string a specified number of times.
        /// </summary>
        /// <param name="count">The number of times to repeat the string.</param>
        /// <param name="sStr">The string to repeat.</param>
        /// <returns>A new string consisting of the original string repeated 'count' times.</returns>
        public string Strings(int count, string sStr)
        {
            if (count <= 0) return "";
            return new StringBuilder(sStr.Length * count).Insert(0, sStr, count).ToString();
        }

        /// <summary>
        /// Returns a string containing a specified number of characters from the left side of a string.
        /// </summary>
        /// <param name="sStr">The source string.</param>
        /// <param name="iLen">The number of characters to return.</param>
        /// <returns>A string containing 'iLen' characters from the left of 'sStr'.</returns>
        public string Left(string sStr, int iLen)
        {
            if (string.IsNullOrEmpty(sStr) || iLen <= 0) return "";
            return sStr.Length > iLen ? sStr.Substring(0, iLen) : sStr;
        }

        /// <summary>
        /// Returns a string containing a specified number of characters from the right side of a string.
        /// </summary>
        /// <param name="sStr">The source string.</param>
        /// <param name="iLen">The number of characters to return.</param>
        /// <returns>A string containing 'iLen' characters from the right of 'sStr'.</returns>
        public string Right(string sStr, int iLen)
        {
            if (string.IsNullOrEmpty(sStr) || iLen <= 0) return "";
            return sStr.Length > iLen ? sStr.Substring(sStr.Length - iLen) : sStr;
        }

        /// <summary>
        /// Returns the substring of a string that follows a specified 1-based position.
        /// </summary>
        /// <param name="sStr">The source string.</param>
        /// <param name="iPos">The 1-based starting position of the substring to return.</param>
        /// <returns>The substring after the specified position, or an empty string if the position is invalid.</returns>
        public string After(string sStr, int iPos) // 1-based index
        {
            if (string.IsNullOrEmpty(sStr) || iPos <= 0 || iPos > sStr.Length) return "";
            return sStr.Substring(iPos - 1);
        }

        /// <summary>
        /// Replaces a portion of a string with another string, similar to a mid-replacement function.
        /// </summary>
        /// <param name="sStr">The original string.</param>
        /// <param name="sPt">The string to insert.</param>
        /// <param name="iPos">The 1-based starting position for the replacement.</param>
        /// <param name="iLen">The number of characters to remove from the original string before inserting 'sPt'.</param>
        /// <returns>The modified string.</returns>
        public string ExcMid(string sStr, string sPt, int iPos, int iLen) // 1-based index
        {
            if (string.IsNullOrEmpty(sStr)) return sPt;
            if (iPos < 1) iPos = 1;
            if (iPos > sStr.Length + 1) iPos = sStr.Length + 1;
            if (iLen < 0) iLen = 0;

            string before = sStr.Substring(0, iPos - 1);
            string after = "";
            if (iPos - 1 + iLen < sStr.Length)
            {
                after = sStr.Substring(iPos - 1 + iLen);
            }
            return before + sPt + after;
        }

        /// <summary>
        /// Formats a string and then removes trailing zeros and decimal points if they are redundant.
        /// </summary>
        /// <param name="fmtString">The format string.</param>
        /// <param name="args">An array of objects to format.</param>
        /// <returns>The formatted string with redundant trailing zeros and decimal points removed.</returns>
        public string RSpFormat(string fmtString, params object[] args)
        {
            string sDat = string.Format(fmtString, args);
            if (sDat.Contains("."))
            {
                int lastNonZero = sDat.Length - 1;
                while (lastNonZero >= 0 && (sDat[lastNonZero] == '0' || sDat[lastNonZero] == '.'))
                {
                    lastNonZero--;
                }
                if (lastNonZero < 0) return "";
                return sDat.Substring(0, lastNonZero + 1);
            }
            return sDat;
        }

        // TextSize and AveWidth would require P/Invoke to GDI32.dll, which is outside the scope of direct C# conversion without platform-specific dependencies.
        // Leaving them as placeholders or omitting them.

        /// <summary>
        /// Counts the number of lines in a string, considering various line ending conventions.
        /// </summary>
        /// <param name="sDat">The input string.</param>
        /// <returns>The number of lines in the string.</returns>
        public int Count(string sDat)
        {
            if (string.IsNullOrEmpty(sDat)) return 1;
            return sDat.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None).Length;
        }

        /// <summary>
        /// Retrieves a specific line from a multi-line string.
        /// </summary>
        /// <param name="sDat">The multi-line input string.</param>
        /// <param name="iRow">The 0-based index of the line to retrieve.</param>
        /// <returns>The specified line, with trailing carriage returns, line feeds, and spaces removed.</returns>
        public string GetString(string sDat, int iRow) // 0-based row index
        {
            if (string.IsNullOrEmpty(sDat) || iRow < 0) return "";
            var lines = sDat.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);
            string result = iRow < lines.Length ? lines[iRow] : "";
            CRCut(ref result);
            return result;
        }

        /// <summary>
        /// Sets a specific line in a multi-line string. If the row index is beyond the current number of lines,
        /// empty lines are added until the specified row can be set.
        /// </summary>
        /// <param name="sDat">The multi-line string to modify (passed by reference).</param>
        /// <param name="iRow">The 0-based index of the line to set.</param>
        /// <param name="sRow">The new content for the specified line.</param>
        public void SetString(ref string sDat, int iRow, string sRow) // 0-based row index
        {
            var lines = new List<string>(sDat.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None));
            while (lines.Count <= iRow)
            {
                lines.Add("");
            }
            lines[iRow] = sRow;
            sDat = string.Join(CRLF, lines);
            CRCut(ref sDat);
        }

        /// <summary>
        /// Splits a string into tokens based on space delimiters and populates a list with the resulting tokens.
        /// </summary>
        /// <param name="value">The input string to tokenize.</param>
        /// <param name="strs">The list to populate with tokens. It will be cleared before adding new tokens.</param>
        public void MakeToken(string value, List<string> strs)
        {
            strs.Clear();
            if (string.IsNullOrWhiteSpace(value)) return;
            strs.AddRange(value.Trim().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries));
        }

        // BinRead, BinWrite, BStrRead, BStrWrite would require custom binary serialization logic.
        // For now, leaving them as placeholders or simplified.

        /// <summary>
        /// Reads a string from a file stream, optionally decoding it.
        /// This is a simplified implementation for binary serialization.
        /// </summary>
        /// <param name="fHandle">The file stream to read from.</param>
        /// <param name="bEnCodeF">A boolean indicating whether to decode the string.</param>
        /// <returns>The read and optionally decoded string.</returns>
        public string BinRead(FileStream fHandle, bool bEnCodeF)
        {
            using (var reader = new BinaryReader(fHandle, _shiftJis, leaveOpen: true))
            {
                int size = reader.ReadInt32();
                byte[] bytes = reader.ReadBytes(size);

                if (bEnCodeF)
                {
                    for (int i = 0; i < bytes.Length; i++)
                    {
                        bytes[i] = RotateRight(bytes[i], 2);
                    }
                }

                string sData = _shiftJis.GetString(bytes);
               
                int idx = sData.IndexOf('\0');
                if (idx >= 0) sData = sData.Substring(0, idx);
                return sData;
            }
        }
        /// <summary>
        /// Reads a string from a binary stream, with optional decoding.
        /// </summary>
        /// <param name="br">BinaryReader used to read data from the stream.</param>
        /// <param name="bEnCodeF">Flag indicating whether the string should be decoded.</param>
        /// <returns>The decoded or raw string read from the stream.</returns>
        public string BinRead(BinaryReader br, bool bEnCodeF)
        {
            // Read the length of the string (number of bytes)
            int size = br.ReadInt32();

            // Read the string data as a byte array
            byte[] buffer = br.ReadBytes(size);

            // Convert the byte array to an ASCII string
            string sData = Encoding.ASCII.GetString(buffer);

            // If decoding is enabled, apply a transformation to each character
            if (bEnCodeF)
            {
                char[] chars = sData.ToCharArray();
                for (int i = 0; i < chars.Length; i++)
                {
                    // Decode each character using a bit-shifting algorithm
                    int ibshift = chars[i] & 0xFF;
                    ibshift = (ibshift << 2) + (ibshift >> 6);
                    chars[i] = (char)ibshift;
                }

                // Reconstruct the decoded string
                sData = new string(chars);
            }

            // Return the final string
            return sData;
        }

        private static byte RotateLeft(byte b, int n)
        {
            return (byte)((((int)b << n) | ((int)b >> (8 - n))) & 0xFF);
        }
        private static byte RotateRight(byte b, int n)
        {
            return (byte)((((int)b >> n) | ((int)b << (8 - n))) & 0xFF);
        }

        /// <summary>
        /// Writes a string to a file stream, optionally encoding it.
        /// This is a simplified implementation for binary serialization.
        /// </summary>
        /// <param name="fHandle">The file stream to write to.</param>
        /// <param name="sData">The string data to write.</param>
        /// <param name="bEnCodeF">A boolean indicating whether to encode the string.</param>
        public void BinWrite(FileStream fHandle, string sData, bool bEnCodeF)
        {
            // writer leaveOpen 
            using (var writer = new BinaryWriter(fHandle, _shiftJis, leaveOpen: true))
            {
              
                byte[] bytes = _shiftJis.GetBytes(sData + '\0');

                if (bEnCodeF)
                {
                    for (int i = 0; i < bytes.Length; i++)
                    {
                        bytes[i] = RotateLeft(bytes[i], 2); 
                    }
                }

                writer.Write(bytes.Length);
                writer.Write(bytes);
                writer.Flush();
            }
        }

        /// <summary>
        /// Writes a single string to a binary file, with optional encoding.
        /// </summary>
        /// <param name="bw">BinaryWriter used to write data.</param>
        /// <param name="sData">The string to write.</param>
        /// <param name="bEnCodeF">Flag indicating whether to encode the string.</param>

        public void BinWrite(BinaryWriter bw, string sData, bool bEnCodeF)
        {
            if (bEnCodeF)
            {
                char[] chars = sData.ToCharArray();
                for (int i = 0; i < chars.Length; i++)
                {
                    int ibshift = chars[i] & 0xFF;
                    ibshift = (ibshift << 6) + (ibshift >> 2);
                    chars[i] = (char)ibshift;
                }
                sData = new string(chars);
            }

            byte[] buffer = Encoding.ASCII.GetBytes(sData);
            int size = buffer.Length;

            bw.Write(size);         // Ghi độ dài chuỗi
            bw.Write(buffer);       // Ghi nội dung chuỗi
        }

        /// <summary>
        /// Reads a string from a file stream without decoding.
        /// </summary>
        /// <param name="fHandle">The file stream to read from.</param>
        /// <returns>The read string.</returns>
        public string BStrRead(FileStream fHandle) => BinRead(fHandle, false);
        /// <summary>
        /// Writes a string to a file stream without encoding.
        /// </summary>
        /// <param name="fHandle">The file stream to write to.</param>
        /// <param name="sData">The string data to write.</param>
        public void BStrWrite(FileStream fHandle, string sData) => BinWrite(fHandle, sData, false);

        /// <summary>
        /// Copies the contents of one list of strings to another.
        /// The destination list will be cleared before copying.
        /// </summary>
        /// <param name="sl1">The destination list of strings.</param>
        /// <param name="sl2">The source list of strings.</param>
        public void SLCopy(List<string> sl1, List<string> sl2)
        {
            sl1.Clear();
            sl1.AddRange(sl2);
        }

        /// <summary>
        /// Extracts the file name without its extension from a given path.
        /// </summary>
        /// <param name="sStr">The full path or file name.</param>
        /// <returns>The file name without the extension.</returns>
        public string ExtractFileFront(string sStr)
        {
            return Path.GetFileNameWithoutExtension(sStr);
        }

        /// <summary>
        /// Adds a '+' sign to the beginning of a positive numeric string, padding it to the original length.
        /// </summary>
        /// <param name="sStr">The input string.</param>
        /// <param name="mode">An integer parameter (currently unused in this implementation).</param>
        /// <returns>The modified string with a leading '+' for positive numbers, or the original string.</returns>
        public string AddPls(string sStr, int mode)
        {
            if (sStr == null) return string.Empty;
            string result = sStr;
            string ss = sStr.Trim();

            if (!string.IsNullOrEmpty(ss) && double.TryParse(ss, out double val) && val > 0)
            {
                result = ("+" + ss).PadLeft(sStr.Length);
            }

            return result;
        }

    
        
        /// <summary>
        /// Disposes of resources used by the ExtString instance.
        /// </summary>
        public void Dispose()
        {

        }
    }
    /// <summary>
    /// Provides static helper methods for string manipulation.
    /// </summary>
    /// <developer>HaiTN</developer>
    /// <version>1.0.0</version>
    /// <creationDate>24/09/2025</creationDate>
    public static class ExtStringHelper
    {
        /// <summary>
        /// Static instance of KString for extended string operations.
        /// </summary>
        public static KString FKStr = new KString();
        /// <summary>
        /// Gets the singleton instance of KString, creating it if it doesn't already exist.
        /// </summary>
        /// <returns>The singleton instance of KString.</returns>
        public static KString KStr()
        {
            if (FKStr == null)
                FKStr = new KString();
            return FKStr;
        }
        /// <summary>
        /// Trims leading and trailing whitespace characters from a string, including full-width spaces.
        /// </summary>
        /// <param name="s">The string to trim.</param>
        /// <returns>The trimmed string.</returns>
        public static string ExTrim(string s)
        {
            if (string.IsNullOrEmpty(s)) return "";

            int L = s.Length;
            int i = 0;
            while (i < L)
            {
                char c = s[i];
                if (!IsWhiteSpaceDelphi(c))
                    break;
                i++;
            }

            if (i >= L) return "";


            int end = L - 1;
            while (end >= 0)
            {
                char c = s[end];
                if (!IsWhiteSpaceDelphi(c))
                    break;
                end--;
            }

            s = s.Substring(i, end - i + 1);
            return s.Trim();
        }
        /// <summary>
        /// Determines if a character is a whitespace character, including the full-width space character.
        /// This mimics Delphi's whitespace behavior.
        /// </summary>
        /// <param name="c">The character to check.</param>
        /// <returns>True if the character is a whitespace character, false otherwise.</returns>
        private static bool IsWhiteSpaceDelphi(char c)
        {
            return char.IsWhiteSpace(c) || c == '　'; // 'e' = full-width space
        }
        /// <summary>
        /// Finds the 1-based starting position of the first occurrence of a substring within a string,
        /// starting the search from a specified 1-based index.
        /// </summary>
        /// <param name="iSt">The 1-based index to start the search from.</param>
        /// <param name="substr">The substring to search for.</param>
        /// <param name="s">The string to search within.</param>
        /// <returns>The 1-based starting position of the substring if found; otherwise, 0.</returns>
        public static int PosSt(int iSt, string substr, string s)
        {
            if (iSt < 1) iSt = 1;
            int pos = s.IndexOf(substr, iSt - 1, StringComparison.Ordinal);
            return pos >= 0 ? pos + 1 : 0;
        }

        /// <summary>
        /// Replaces the first occurrence of a specified substring with another string, starting the search from a given 1-based index.
        /// </summary>
        /// <param name="iSt">The 1-based index to start the search from.</param>
        /// <param name="sStr">The original string.</param>
        /// <param name="befStr">The substring to replace.</param>
        /// <param name="aftStr">The string to replace with.</param>
        /// <returns>The modified string.</returns>
        public static string ReplaceWordSt(int iSt, string sStr, string befStr, string aftStr)
        {
            int pos = PosSt(iSt, befStr, sStr);
            if (pos < iSt) return sStr;
            return sStr.Substring(0, pos - 1) + aftStr + sStr.Substring(pos - 1 + befStr.Length);
        }
        /// <summary>
        /// Replaces the first occurrence of a specified substring with another string, starting the search from the beginning of the string.
        /// </summary>
        /// <param name="sStr">The original string.</param>
        /// <param name="befStr">The substring to replace.</param>
        /// <param name="aftStr">The string to replace with.</param>
        /// <returns>The modified string.</returns>
        public static string ReplaceWord(string sStr, string befStr, string aftStr)
        {
            return ReplaceWordSt(1, sStr, befStr, aftStr);
        }

        /// <summary>
        /// Replaces all occurrences of a specified substring with another string within the entire string.
        /// </summary>
        /// <param name="sStr">The original string.</param>
        /// <param name="befStr">The substring to replace.</param>
        /// <param name="aftStr">The string to replace with.</param>
        /// <returns>The modified string with all occurrences replaced.</returns>
        public static string ReplaceWordAll(string sStr, string befStr, string aftStr)
        {
            int iSt = 1;
            string result = sStr;

            while (PosSt(iSt, befStr, result) > 0)
            {
                result = ReplaceWordSt(iSt, result, befStr, aftStr);
                iSt += aftStr.Length;
            }

            return result;
        }

    }
}
