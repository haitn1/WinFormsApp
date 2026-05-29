
using System.Drawing;
using System.Text;

namespace WinApp.Common
{

    /// <summary>
    /// Provides extended string manipulation functionalities.
    /// </summary>
    /// <developer>HaiTN</developer>
    /// <version>1.0.0</version>
    /// <creationDate>20/09/2025</creationDate>
    public class KString 
    {
        /// <summary>
        /// The actual string content.
        /// </summary>
        private string _sStr = string.Empty;
        /// <summary>
        /// Maps character index (1-based) to byte index (0-based) in _sStr.
        /// </summary>
        private List<int> _sAdr = new List<int>();
        /// <summary>
        /// Stores character type for each byte: 1 for single-byte, 2 for lead byte, 3 for trail byte.
        /// </summary>
        private List<int> _sTyp = new List<int>();

        /// <summary>
        /// Start byte index of last extracted value.
        /// </summary>
        private int _iScu;
        /// <summary>
        /// Next byte index after last extracted value.
        /// </summary>
        private int _iNcu;
        /// <summary>
        /// Byte count of last extracted value.
        /// </summary>
        private int _iBcu;

        /// <summary>
        /// The Shift_JIS encoding used for byte operations.
        /// </summary>
        private static readonly Encoding _shiftJis = Encoding.GetEncoding("Shift_JIS");

        /// <summary>
        /// Gets the character length of the string.
        /// </summary>
        public int Klen => _sAdr.Count;
        /// <summary>
        /// Gets the byte length of the string using Shift_JIS encoding.
        /// </summary>
        public int Blen => _sStr == null ? 0 : _shiftJis.GetByteCount(_sStr);

        private ExtString _ext = new ExtString();
        /// <summary>
        /// Gets or sets the text content of the KString.
        /// </summary>
        public string Text
        {
            get { return _sStr; }
            set { SetText(value); }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="KString"/> class with the specified text.
        /// </summary>
        /// <param name="text">The initial text content. Defaults to an empty string.</param>
        public KString(string text = "")
        {
            SetText(text);
        }

        /// <summary>
        /// Sets the text content of the KString and re-calculates internal byte and character mappings.
        /// </summary>
        /// <param name="text">The text to set.</param>
        private void SetText(string text)
        {
            _sStr = text ?? "";
            _sAdr = new List<int>();
            _sTyp = new List<int>();

            if (string.IsNullOrEmpty(_sStr))
            {
                _iScu = 0;
                _iNcu = 1;
                _iBcu = 0;
                return;
            }

            byte[] bytes = _shiftJis.GetBytes(_sStr);
            int byteIndex = 0;
            for (int i = 0; i < _sStr.Length; i++)
            {
                _sAdr.Add(byteIndex + 1); // Delphi uses 1-based indexing
                char c = _sStr[i];
                int byteCount = _shiftJis.GetByteCount(new[] { c });

                if (byteCount > 1)
                {
                    _sTyp.Add(2); // Lead byte
                    _sTyp.Add(3); // Trail byte
                    byteIndex += 2;
                }
                else
                {
                    _sTyp.Add(1); // Single byte
                    byteIndex++;
                }
            }

            _iScu = 0;
            _iNcu = 1;
            _iBcu = 0;
        }
        /// <summary>
        /// Gets the character type (single-byte, lead byte, or trail byte) for a given 1-based character index.
        /// </summary>
        /// <param name="index">The 1-based character index.</param>
        /// <returns>The character type (1, 2, or 3), or 0 if the index is out of bounds.</returns>

        public int GetBtyp(int index) // 1-based byte index
        {
            if (index < 1 || index > Blen) return 0;
            return _sTyp[index - 1];
        }

        /// <summary>
        /// Gets the character type (single-byte, lead byte, or trail byte) for a given 1-based character index.
        /// </summary>
        /// <param name="index">The 1-based character index.</param>
        /// <returns>The character type (1, 2, or 3), or 0 if the index is out of bounds.</returns>
        public int GetKtyp(int index) // 1-based character index
        {
            if (index < 1 || index > Klen) return 0;
            int byteIndex = _sAdr[index - 1];
            return _sTyp[byteIndex - 1]; // Convert to 0-based for List access
        }

        /// <summary>
        /// Gets the 0-based byte index corresponding to a given 1-based character index.
        /// </summary>
        /// <param name="index">The 1-based character index.</param>
        /// <returns>The 0-based byte index, or 0 if the character index is out of bounds.</returns>
        public int GetKadr(int index) // 1-based character index
        {
            if (index < 1 || index > Klen) return 0;
            return _sAdr[index - 1];
        }

        /// <summary>
        /// Extracts a substring based on 1-based byte indices.
        /// </summary>
        /// <param name="startByteIndex">The 1-based starting byte index.</param>
        /// <param name="length">The number of bytes to extract.</param>
        /// <returns>The extracted substring.</returns>
       public string GetBmid(int startByteIndex, int length) // 1-based byte index
        {
            if (Blen < startByteIndex || length < 1) 
                return ""; 
            _iScu = startByteIndex; 
            
            if (_iScu < 1)
                _iScu = 1; 
            
            byte[] bytes = _shiftJis.GetBytes(_sStr);
            int bLen = bytes.Length; 
            if (_iScu > bLen) 
                return "";

            int endByteIndex = _iScu + length - 1;
            if (bLen < endByteIndex) endByteIndex = bLen;

            int start = _iScu - 1;
            int len = endByteIndex - start;

            string temp = _shiftJis.GetString(bytes, start, len);
            KString kTemp = new KString(temp);

            if (kTemp.GetBtyp(1) == 3) {
                start++;
                len--;
            }
            if (kTemp.GetBtyp(kTemp.Blen) == 2) {
                len--;
            }

            _iBcu = len;
            if (_iBcu < 0) _iBcu = 0;

            _iNcu = start + len + 1;

            return _shiftJis.GetString(bytes, start, _iBcu);
        }

        /// <summary>
        /// Extracts a substring from the beginning of the string based on byte length.
        /// </summary>
        /// <param name="length">The number of bytes to extract.</param>
        /// <returns>The extracted substring.</returns>
        public string GetBlef(int length) => GetBmid(1, length);
        /// <summary>
        /// Extracts a substring from the end of the string based on byte length.
        /// </summary>
        /// <param name="length">The number of bytes to extract.</param>
        /// <returns>The extracted substring.</returns>
        public string GetBrig(int length)
        {
            int startByteIndex = Blen - length + 1;
            if (startByteIndex < 1) startByteIndex = 1;
            return GetBmid(startByteIndex, length);
        }
        /// <summary>
        /// Extracts a substring from a specified 1-based byte index to the end of the string.
        /// </summary>
        /// <param name="startByteIndex">The 1-based starting byte index.</param>
        /// <returns>The extracted substring.</returns>
        public string GetBaft(int startByteIndex) => GetBmid(startByteIndex, Blen - startByteIndex + 1);

        /// <summary>
        /// Extracts a substring based on 1-based character indices.
        /// </summary>
        /// <param name="startCharIndex">The 1-based starting character index.</param>
        /// <param name="length">The number of characters to extract.</param>
        /// <returns>The extracted substring.</returns>
        public string GetKmid(int startCharIndex, int length) // 1-based character index
        {
            if (Klen < startCharIndex || length < 1) return "";

            _iScu = startCharIndex;
            if (_iScu < 1) _iScu = 1;

            int endCharIndex = _iScu + length - 1;
            if (Klen < endCharIndex) endCharIndex = Klen;

            length = endCharIndex - _iScu + 1;

            _iNcu = endCharIndex + 1;

            if (_iScu > _sStr.Length) return "";
            return _sStr.Substring(_iScu - 1, length);
        }

        /// <summary>
        /// Extracts a substring from the beginning of the string based on character length.
        /// </summary>
        /// <param name="length">The number of characters to extract.</param>
        /// <returns>The extracted substring.</returns>
        public string GetKlef(int length) => GetKmid(1, length);
        /// <summary>
        /// Extracts a substring from the end of the string based on character length.
        /// </summary>
        /// <param name="length">The number of characters to extract.</param>
        /// <returns>The extracted substring.</returns>
        public string GetKrig(int length)
        {
            int start = Klen - length + 1;
            if (start < 1) start = 1;
            return GetKmid(start, length);
        }
        /// <summary>
        /// Extracts a substring from a specified 1-based character index to the end of the string.
        /// </summary>
        /// <param name="startCharIndex">The 1-based starting character index.</param>
        /// <returns>The extracted substring.</returns>
        public string GetKaft(int startCharIndex) => GetKmid(startCharIndex, Klen - startCharIndex + 1);

        /// <summary>
        /// Extracts an integer value from the string at the current position.
        /// </summary>
        /// <returns>The extracted integer value.</returns>
        public int GetInt()
        {
            _iScu = _iNcu;
            int result = _ext.StrnInt(_sStr, ref _iNcu);
            _iBcu = _iNcu - _iScu;
            return result;
        }

        /// <summary>
        /// Extracts a hexadecimal integer value from the string at the current position.
        /// </summary>
        /// <returns>The extracted hexadecimal integer value.</returns>
        public int GetHex()
        {
            _iScu = _iNcu;
            int result = _ext.StrnHex(_sStr, ref _iNcu);
            _iBcu = _iNcu - _iScu;
            return result;
        }

        /// <summary>
        /// Extracts a double-precision floating-point value from the string at the current position.
        /// </summary>
        /// <returns>The extracted double value.</returns>
        public double GetDbl()
        {
            _iScu = _iNcu;
            double result = _ext.StrnDbl(_sStr, ref _iNcu);
            _iBcu = _iNcu - _iScu;
            return result;
        }

        /// <summary>
        /// Extracts a quoted string from the current position.
        /// </summary>
        /// <returns>The extracted string, with escaped quotes unescaped.</returns>
        public string GetStr()
        {
            try
            {
                int IncCount(int index)
                {
                    return _sTyp[index] == 2 ? 2 : 1;
                }

                string result = "";
                if (_iNcu < 1) return result;

                int iSt = _iNcu;
                while (iSt < _sStr.Length && _sStr[iSt] != '\'' && _sStr[iSt] != '"')
                    iSt += IncCount(iSt);

                if (iSt < _sStr.Length)
                {
                    char chDl = _sStr[iSt];
                    int iEd = iSt + 1;

                    while (iEd < _sStr.Length &&
                          (_sStr[iEd] != chDl ||
                          (_sStr[iEd] == chDl && iEd < _sStr.Length && _sStr[iEd + 1] == chDl)))
                    {
                        iEd += IncCount(iEd) + (_sStr[iEd] == chDl ? 1 : 0);
                    }

                    if (iEd < _sStr.Length)
                    {
                        int iPo = 1;
                        _iScu = iSt;
                        _iNcu = iEd + 1;
                        _iBcu = _iNcu - _iScu;

                        iSt++;
                        result = _sStr.Substring(iSt, _iBcu - 2);

                        while (iSt < iEd)
                        {
                            if (_sStr[iSt] == chDl && _sStr[iSt + 1] == chDl)
                            {
                                result = result.Substring(0, iPo) + result.Substring(iPo + 2);
                                iPo++;
                                iSt += 2;
                            }
                            else
                            {
                                iPo += IncCount(iSt);
                                iSt += IncCount(iSt);
                            }
                        }
                    }
                }

                return result;
            }
            catch(Exception exp)
            {
                Console.WriteLine("Error in GetStr: " + exp.Message);
                return "";
            }

            
        }


        /// <summary>
        /// Extracts a 128-bit integer from the string at the current position.
        /// </summary>
        /// <returns>The extracted 128-bit integer.</returns>
        public int Get128()
        {
            _iScu = _iNcu;
            while (_iScu <= _sStr.Length && (_sStr[_iScu - 1] & 0x80) == 0)
            {
                _iScu++;
            }

            if (_sStr.Length < _iScu)
            {
                _iBcu = 0;
                _iNcu = 0;
                return 0;
            }
            else
            {
                _iBcu = 5;
                if (_sStr.Length < _iScu + _iBcu - 1) return 0;
                _iNcu = _iScu + _iBcu;
                return _ext.From128(_sStr.Substring(_iScu - 1, _iBcu));
            }
        }

        /// <summary>
        /// Extracts a 128-bit double-precision floating-point value from the string at the current position.
        /// </summary>
        /// <returns>The extracted 128-bit double value.</returns>
        public double Get128D()
        {
            _iScu = _iNcu;

            while (_iScu <= Blen && (_sStr[_iScu - 1] & 0x80) == 0)
            {
                _iScu++;
            }

            if (Blen < _iScu)
            {
                _iBcu = 0;
                _iNcu = 0;
                return 0;
            }
            else
            {
                _iBcu = 10;
                _iNcu = _iScu + _iBcu;

                string encoded = _sStr.Substring(_iScu - 1, _iBcu);
                return _ext.From128D(encoded);
            }
        }

        /// <summary>
        /// Gets the color from the string.
        /// </summary>
        /// <returns>The color.</returns>
        public Color GetColor()
        {
            int val = GetHex();
            byte r = (byte)(val & 0xFF);
            byte g = (byte)((val >> 8) & 0xFF);
            byte b = (byte)((val >> 16) & 0xFF);
            return Color.FromArgb(r, g, b);
        }
    }
}
